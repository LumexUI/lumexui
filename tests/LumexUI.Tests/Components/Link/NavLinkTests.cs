// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Bunit.TestDoubles;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class NavLinkTests : TestContext
{
    public NavLinkTests()
    {
        Services.AddSingleton<TwMerge>();
    }

    [Fact]
    public void NavLink_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexNavLink>();

        action.Should().NotThrow();
    }

    [Fact]
    public void NavLink_IfUrlEqualsHref_ShouldBeActive()
    {
        var navMan = Services.GetRequiredService<FakeNavigationManager>();
        var cut = RenderComponent<LumexNavLink>( p => p
            .Add( p => p.Href, "some-url" )
        );

        navMan.NavigateTo( "some-url" );

        // faking re-render on location change (NavLink base implementation)
        cut.Render();

        cut.Find( "a" ).GetAttribute( "data-active" ).Should().Be( "true" );
    }
}