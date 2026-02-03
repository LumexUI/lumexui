// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

using TailwindMerge;

namespace BlazorApp2.Components;

public class CompBase : ComponentBase
{
	[Parameter( CaptureUnmatchedValues = true )]
	public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

	[Parameter] public string? Class { get; set; }

	[Inject] public TwMerge TwMerge { get; set; } = default!;
}
