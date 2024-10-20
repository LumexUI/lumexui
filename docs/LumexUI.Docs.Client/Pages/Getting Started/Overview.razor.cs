using LumexUI.Docs.Client.Common;
using LumexUI.Docs.Client.Components;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Client.Pages.Getting_Started;

public partial class Overview
{
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    private readonly Feature[] _features =
    [
        new Feature()
        {
            Title = "Tailwind CSS Integration",
            Description = "Every component is crafted using Tailwind CSS, offering you the full power of this utility-first CSS framework. This ensures that your designs are modern, flexible, and in line with best practices."
        },
        new Feature()
        {
            Title = "Beautiful Design",
            Description = "Our components are designed with attention to detail, providing a clean and professional look out of the box. You can trust that they will enhance the visual appeal of your application."
        },
        new Feature()
        {
            Title = "Highly Customizable",
            Description = "With extensive customization options, you can easily adapt the components to match your branding and design preferences. The flexibility of Tailwind CSS is fully leveraged to give you control over every aspect of your UI."
        },
        new Feature()
        {
            Title = "Performance-Optimized",
            Description = "We prioritize performance in all our components. LumexUI is built to ensure that your applications load quickly and run smoothly, even as they scale."
        },
        new Feature()
        {
            Title = "Conflict-Free Styling",
            Description = "Our additional utility library automatically handles Tailwind CSS class conflicts. This ensures that your custom styles override defaults as expected, eliminating potential issues and simplifying the development process."
        }
    ];

    private readonly QuickLink[] _quickLinks =
    [
        new QuickLink()
        {
            Icon = Icons.Rounded.InstallDesktop,
            Link = "docs/getting-started/installation",
            Title = "Installation",
            Description = "Add LumexUI to your Blazor project with simple installation steps."
        },
        //new QuickLink()
        //{
        //    Icon = Icons.Rounded.Draw,
        //    Link = "docs/getting-started/usage",
        //    Title = "Usage",
        //    Description = "Learn the basics about using LumexUI components in your projects."
        //},
        new QuickLink()
        {
            Icon = Icons.Rounded.Joystick,
            Link = "docs/components",
            Title = "Components library",
            Description = "Browse the full collection of components and learn how to use them."
        },
        new QuickLink()
        {
            Icon = Icons.Rounded.DesignServices,
            Link = "docs/customization",
            Title = "Customizing components",
            Description = "Explore the customization options to tailor components to your needs."
        }
    ];

    [CascadingParameter] private DocsContentLayout Layout { get; set; } = default!;

    private readonly Heading[] _headings = [
        new("Introduction"),
        new("Advantages of LumexUI"),
        new("Pick Your Learning Path"),
        new("Get involved")
    ];

    protected override void OnInitialized()
    {
        if( !NavigationManager!.Uri.Contains( "/docs/getting-started/overview" ) )
        {
            NavigationManager.NavigateTo( "/docs/getting-started/overview" );
        }

        Layout.Initialize(
            title: "Get Started with LumexUI",
            category: "Getting started",
            description: "LumexUI simplifies the process of building modern, responsive UIs in Blazor by providing a comprehensive set of components styled with Tailwind CSS.",
            _headings
        );
    }

    private class Feature
    {
        public required string Title { get; init; }
        public required string Description { get; init; }
    }

    private class QuickLink
    {
        public required string Icon { get; init; }
        public required string Link { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
    }
}
