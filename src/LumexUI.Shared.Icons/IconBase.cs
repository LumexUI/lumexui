// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using Microsoft.AspNetCore.Components;

namespace LumexUI.Shared.Icons;

public abstract class IconBase : ComponentBase
{
	[Parameter] public string? Size { get; set; }

	[Parameter] public bool AbsoluteStrokeWidth { get; set; } = true;

	[Parameter( CaptureUnmatchedValues = true )]
	public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

	protected string Width => Size ?? "24";
	protected string Height => Size ?? "24";
	protected double StrokeWidth
	{
		get
		{
			if ( Size is null || !AbsoluteStrokeWidth )
			{
				return _baseStrokeWidth;
			}

			if ( double.TryParse( Size, out var size ) && size > _baseSize )
			{
				return _baseSize / size * _baseStrokeWidth;
			}

			return _baseStrokeWidth;
		}
	}

	private readonly int _baseSize = 24;
	private readonly int _baseStrokeWidth = 2;
}
