// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Reflection;

using LumexUI.Common;
using LumexUI.Services;

using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;

namespace LumexUI.Tests.Services;

public class ThemeServiceTests : TestContext
{
	[Fact]
	public async Task InitializeAsync_ShouldSetDarkTheme_WhenJsReturnsDark()
	{
		// Arrange
		var mockJsRuntime = new Mock<IJSRuntime>();
		var mockModule = new Mock<IJSObjectReference>();

		mockModule
			.Setup( m => m.InvokeAsync<string>( "theme.initialize", It.IsAny<object[]>() ) )
			.ReturnsAsync( "dark" );

		mockModule
			.Setup( m => m.InvokeAsync<bool>( "theme.prefersDark", It.IsAny<object[]>() ) )
			.ReturnsAsync( true );

		var service = new ThemeService( mockJsRuntime.Object );
		InjectModule( Task.FromResult( mockModule.Object ), service );

		// Act
		await service.InitializeAsync();

		// Assert
		Assert.True( service.IsDarkMode );
	}

	[Fact]
	public async Task SetThemeAsync_ShouldCallSet_AndUpdateDarkMode()
	{
		// Arrange
		var mockJsRuntime = new Mock<IJSRuntime>();
		var mockModule = new Mock<IJSObjectReference>();

		mockModule
			.Setup( m => m.InvokeAsync<IJSVoidResult>( "theme.set", CancellationToken.None, It.Is<object[]>( args => (string)args[0] == "dark" ) ) )
			.Returns( new ValueTask<IJSVoidResult>() );

		mockModule
			.Setup( m => m.InvokeAsync<bool>( "theme.prefersDark", It.IsAny<object[]>() ) )
			.ReturnsAsync( true );

		var service = new ThemeService( mockJsRuntime.Object );
		InjectModule( Task.FromResult( mockModule.Object ), service );

		// Act
		await service.SetThemeAsync( Theme.Dark );

		// Assert
		Assert.True( service.IsDarkMode );
	}

	[Fact]
	public async Task SetThemeAsync_ShouldCallSetOnlyOnce_WhenSameThemeIsSetTwice()
	{
		// Arrange
		var mockJsRuntime = new Mock<IJSRuntime>();
		var mockModule = new Mock<IJSObjectReference>();

		mockModule
			.Setup( m => m.InvokeAsync<IJSVoidResult>( "theme.set", CancellationToken.None, It.Is<object[]>( args => (string)args[0] == "dark" ) ) )
			.Returns( new ValueTask<IJSVoidResult>() );

		mockModule
			.Setup( m => m.InvokeAsync<bool>( "theme.prefersDark", It.IsAny<object[]>() ) )
			.ReturnsAsync( true );

		var service = new ThemeService( mockJsRuntime.Object );
		InjectModule( Task.FromResult( mockModule.Object ), service );

		// Act
		await service.SetThemeAsync( Theme.Dark ); // First call — should invoke JS
		await service.SetThemeAsync( Theme.Dark ); // Second call — should skip JS

		// Assert
		mockModule.Verify( m => m.InvokeAsync<IJSVoidResult>( "theme.set", It.Is<object[]>( args => (string)args[0] == "dark" ) ), Times.Once );
		Assert.True( service.IsDarkMode );
	}

	[Fact]
	public async Task SetThemeAsync_ShouldRaiseThemeChanged()
	{
		// Arrange
		var mockJsRuntime = new Mock<IJSRuntime>();
		var mockModule = new Mock<IJSObjectReference>();

		mockModule
			.Setup( m => m.InvokeAsync<IJSVoidResult>( "theme.set", CancellationToken.None, It.IsAny<object[]>() ) )
			.Returns( new ValueTask<IJSVoidResult>() );

		var service = new ThemeService( mockJsRuntime.Object );
		InjectModule( Task.FromResult( mockModule.Object ), service );

		Theme? raisedTheme = null;
		service.ThemeChanged += theme => raisedTheme = theme;

		// Act
		await service.SetThemeAsync( Theme.Dark );

		// Assert
		Assert.Equal( Theme.Dark, raisedTheme );
	}

	[Fact]
	public async Task SetThemeAsync_ShouldNotRaiseThemeChanged_WhenSameTheme()
	{
		// Arrange
		var mockJsRuntime = new Mock<IJSRuntime>();
		var mockModule = new Mock<IJSObjectReference>();

		mockModule
			.Setup( m => m.InvokeAsync<IJSVoidResult>( "theme.set", CancellationToken.None, It.IsAny<object[]>() ) )
			.Returns( new ValueTask<IJSVoidResult>() );

		var service = new ThemeService( mockJsRuntime.Object );
		InjectModule( Task.FromResult( mockModule.Object ), service );

		await service.SetThemeAsync( Theme.Dark );

		var eventRaised = false;
		service.ThemeChanged += _ => eventRaised = true;

		// Act
		await service.SetThemeAsync( Theme.Dark );

		// Assert
		Assert.False( eventRaised );
	}

	[Fact]
	public async Task ToggleThemeAsync_ShouldUpdateThemeAndDarkMode()
	{
		// Arrange
		var mockJsRuntime = new Mock<IJSRuntime>();
		var mockModule = new Mock<IJSObjectReference>();

		mockModule
			.Setup( m => m.InvokeAsync<string>( "theme.toggle", It.IsAny<object[]>() ) )
			.ReturnsAsync( "light" );

		mockModule
			.Setup( m => m.InvokeAsync<bool>( "theme.prefersDark", It.IsAny<object[]>() ) )
			.ReturnsAsync( false );

		var service = new ThemeService( mockJsRuntime.Object );
		InjectModule( Task.FromResult( mockModule.Object ), service );

		// Act
		var result = await service.ToggleThemeAsync();

		// Assert
		Assert.Equal( Theme.Light, result );
		Assert.Equal( Theme.Light, service.CurrentTheme );
		Assert.False( service.IsDarkMode );
	}

	[Fact]
	public async Task ToggleThemeAsync_ShouldRaiseThemeChanged()
	{
		// Arrange
		var mockJsRuntime = new Mock<IJSRuntime>();
		var mockModule = new Mock<IJSObjectReference>();

		mockModule
			.Setup( m => m.InvokeAsync<string>( "theme.toggle", It.IsAny<object[]>() ) )
			.ReturnsAsync( "dark" );

		var service = new ThemeService( mockJsRuntime.Object );
		InjectModule( Task.FromResult( mockModule.Object ), service );

		Theme? raisedTheme = null;
		service.ThemeChanged += theme => raisedTheme = theme;

		// Act
		await service.ToggleThemeAsync();

		// Assert
		Assert.Equal( Theme.Dark, raisedTheme );
	}

	[Fact]
	public async Task DisposeAsync_ShouldDisposeModule_WhenCreated()
	{
		// Arrange
		var mockJsRuntime = new Mock<IJSRuntime>();
		var mockModule = new Mock<IJSObjectReference>();

		mockModule
			.Setup( m => m.InvokeAsync<string>( "theme.initialize", It.IsAny<object[]>() ) )
			.ReturnsAsync( "dark" );

		mockModule.Setup( m => m.DisposeAsync() ).Returns( ValueTask.CompletedTask );

		var service = new ThemeService( mockJsRuntime.Object );
		InjectModule( Task.FromResult( mockModule.Object ), service );

		await service.InitializeAsync();

		// Act
		await ( (IAsyncDisposable)service ).DisposeAsync();

		// Assert
		mockModule.Verify( m => m.DisposeAsync(), Times.Once );
	}

	private static void InjectModule( Task<IJSObjectReference> moduleTask, ThemeService service )
	{
		var field = typeof( ThemeService ).GetField( "_moduleTask", BindingFlags.NonPublic | BindingFlags.Instance );
		field?.SetValue( service, new Lazy<Task<IJSObjectReference>>( () => moduleTask ) );
	}
}
