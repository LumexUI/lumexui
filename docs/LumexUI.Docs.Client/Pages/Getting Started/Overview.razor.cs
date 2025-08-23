using LumexUI.Docs.Client.Common;
using LumexUI.Docs.Client.Components;
using LumexUI.Shared.Icons;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Client.Pages.Getting_Started;

public partial class Overview
{
	private readonly Feature[] _features =
	[
		new Feature()
		{
			Title = "Tailwind CSS integration",
			Description = "Every component is crafted using Tailwind CSS, offering the full power of this utility-first CSS framework."
		},
		new Feature()
		{
			Title = "Beautiful design",
			Description = "Components are designed with attention to detail, providing a clean and professional look out of the box."
		},
		new Feature()
		{
			Title = "Highly customizable",
			Description = "With extensive customization options, components can be adapted to match any branding and design preferences."
		},
		new Feature()
		{
			Title = "Performance-optimized",
			Description = "Every component in LumexUI is designed with performance in mind, ensuring applications load quickly and run smoothly, even at scale."
		},
		new Feature()
		{
			Title = "Conflict-free styling",
			Description = "Under the hood, LumexUI uses TailwindMerge.NET, a utility for resolving Tailwind CSS class conflicts."
		}
	];

	private readonly QuickLink[] _quickLinks =
	[
		new QuickLink()
		{
			Icon = typeof( MonitorDownIcon ),
			Link = "docs/getting-started/installation",
			Title = "Installation",
			Description = "Add LumexUI to a Blazor project with simple installation steps."
		},
		new QuickLink()
		{
			Icon = typeof( ComponentIcon ),
			Link = "docs/components/accordion",
			Title = "Component library",
			Description = "Explore the full collection of components and learn how to use them."
		},
		new QuickLink()
		{
			Icon = typeof( PaletteIcon ),
			Link = "docs/theming/customization",
			Title = "Customization",
			Description = "Explore the customization options to tailor components to specific needs."
		},
		new QuickLink()
		{
			Icon = typeof( MoonIcon ),
			Link = "docs/theming/dark-mode",
			Title = "Dark mode",
			Description = "Learn how to switch between light, dark, and system modes."
		},
	];

	[CascadingParameter] private DocsContentLayout Layout { get; set; } = default!;

	private readonly Heading[] _headings = [
		new("Introduction"),
		new("Advantages of LumexUI"),
		new("What to read next"),
		new("Community")
	];

	protected override void OnInitialized()
	{
		Layout.Initialize(
			title: "Get started with LumexUI",
			category: "Getting started",
			description: "LumexUI makes building modern UIs in Blazor simple, offering a collection of beautifully designed components powered by Tailwind CSS.",
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
		public required Type Icon { get; init; }
		public required string Link { get; init; }
		public required string Title { get; init; }
		public required string Description { get; init; }
	}
}
