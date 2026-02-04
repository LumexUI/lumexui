// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using Blazor.Sonner.Common;

using LumexUI.Common;
using LumexUI.Services;
using LumexUI.Styles;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that provides toast notifications functionality.
/// </summary>
[ExcludeFromCodeCoverage]
public partial class LumexToastProvider : LumexComponentBase, IDisposable
{
	/// <summary>
	/// Gets or sets the unique identifier for the toast provider.
	/// </summary>
	[Parameter] public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the position where toasts are displayed on the screen.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ToastPosition.BottomRight"/>
	/// </remarks>
	[Parameter] public ToastPosition Position { get; set; } = ToastPosition.BottomRight;

	/// <summary>
	/// Gets or sets the offset of the toasts from the edges of the screen.
	/// </summary>
	[Parameter] public Offset? Offset { get; set; }

	/// <summary>
	/// Gets or sets the offset of the toasts from the edges of the screen on mobile devices.
	/// </summary>
	[Parameter] public Offset? MobileOffset { get; set; }

	/// <summary>
	/// Gets or sets the maximum number of toasts visible at the same time.
	/// </summary>
	/// <remarks>
	/// The default value is 3
	/// </remarks>
	[Parameter] public int VisibleToasts { get; set; } = 3;

	/// <summary>
	/// Gets or sets the gap between toasts, in pixels.
	/// </summary>
	/// <remarks>
	/// The default value is 14
	/// </remarks>
	[Parameter] public int Gap { get; set; } = 14;

	/// <summary>
	/// Gets or sets the duration for which a toast is displayed before being automatically dismissed.
	/// </summary>
	/// <remarks>
	/// The default value is 4000 milliseconds
	/// </remarks>
	[Parameter] public TimeSpan Duration { get; set; } = TimeSpan.FromMilliseconds( 4000 );

	/// <summary>
	/// Gets or sets a value indicating whether toasts should be expanded by default.
	/// </summary>
	[Parameter] public bool Expand { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether toasts should display a close button.
	/// </summary>
	[Parameter] public bool CloseButton { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether toasts should use rich colors for different toast types.
	/// </summary>
	[Parameter] public bool RichColors { get; set; }

	/// <summary>
	/// Gets or sets the text direction of the toasts.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="DocumentDirection.Auto"/>
	/// </remarks>
	[Parameter] public DocumentDirection Dir { get; set; } = DocumentDirection.Auto;

	[Inject] private ThemeService ThemeService { get; set; } = default!;

	private string? ClassNames => new ElementClass()
		.Add( ToastProvider.Style() )
		.Add( Class );

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ThemeService.ThemeChanged += OnThemeChanged;
	}

	private void OnThemeChanged( Theme theme )
	{
		StateHasChanged();
	}

	/// <inheritdoc />
	public void Dispose()
	{
		ThemeService.ThemeChanged -= OnThemeChanged;
	}
}