// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Extensions;

using Microsoft.JSInterop;

namespace LumexUI.Services;

/// <summary>
/// Provides functionality to manage and persist theme settings.
/// </summary>
public sealed class ThemeService : IAsyncDisposable
{
	private const string JavaScriptPrefix = "theme";

	private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

	/// <summary>
	/// Occurs when the theme has changed.
	/// </summary>
	public event Action<Theme>? ThemeChanged;

	/// <summary>
	/// Gets the current theme.
	/// </summary>
	public Theme CurrentTheme { get; private set; } = Theme.System;

	/// <summary>
	/// Gets a value indicating whether dark mode is currently active.
	/// </summary>
	public bool IsDarkMode { get; private set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="ThemeService"/>.
	/// </summary>
	/// <param name="jsRuntime">The JavaScript runtime used for interop calls.</param>
	public ThemeService( IJSRuntime jsRuntime )
	{
		_moduleTask = new( () => jsRuntime.InvokeAsync<IJSObjectReference>(
			"import", "./_content/LumexUI/js/utils/theme.js" ).AsTask() );
	}

	/// <summary>
	/// Initializes the theme service asynchronously.
	/// </summary>
	/// <returns></returns>
	public async ValueTask InitializeAsync()
	{
		var module = await _moduleTask.Value;
		var theme = await module.InvokeAsync<string>( $"{JavaScriptPrefix}.initialize" );

		CurrentTheme = TryParseTheme( theme );
		await UpdateIsDarkModeAsync( CurrentTheme );
		ThemeChanged?.Invoke( CurrentTheme );
	}

	/// <summary>
	/// Sets the specified theme asynchronously.
	/// </summary>
	/// <param name="theme">The theme to apply.</param>
	/// <returns>The <see cref="ValueTask"/> representing the asynchronous theme set operation.</returns>
	public async ValueTask SetThemeAsync( Theme theme )
	{
		if( CurrentTheme == theme )
		{
			return;
		}

		var module = await _moduleTask.Value;
		await module.InvokeVoidAsync( $"{JavaScriptPrefix}.set", theme.ToDescription() );

		CurrentTheme = theme;
		await UpdateIsDarkModeAsync( theme );
		ThemeChanged?.Invoke( theme );
	}

	/// <summary>
	/// Asynchronously toggles between light and dark themes.
	/// </summary>
	/// <returns>The <see cref="Theme"/> representing the updated theme after toggling.</returns>
	public async ValueTask<Theme> ToggleThemeAsync()
	{
		var module = await _moduleTask.Value;
		var value = await module.InvokeAsync<string>( $"{JavaScriptPrefix}.toggle" );

		if( Enum.TryParse<Theme>( value, ignoreCase: true, out var theme ) )
		{
			CurrentTheme = theme;
			await UpdateIsDarkModeAsync( theme );
			ThemeChanged?.Invoke( theme );
		}

		return CurrentTheme;
	}

	private async ValueTask UpdateIsDarkModeAsync( Theme theme )
	{
		if( theme is Theme.Dark )
		{
			IsDarkMode = true;
		}
		else if( theme is Theme.Light )
		{
			IsDarkMode = false;
		}
		else
		{
			var module = await _moduleTask.Value;
			IsDarkMode = await module.InvokeAsync<bool>( $"{JavaScriptPrefix}.prefersDark" );
		}
	}

	private static Theme TryParseTheme( string? theme )
	{
		return Enum.TryParse<Theme>( theme, ignoreCase: true, out var value )
			? value
			: Theme.System;
	}

	/// <inheritdoc />
	async ValueTask IAsyncDisposable.DisposeAsync()
	{
		if( _moduleTask.IsValueCreated )
		{
			var module = await _moduleTask.Value;
			await module.DisposeAsync();
		}
	}
}