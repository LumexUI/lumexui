// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Extensions;

[ExcludeFromCodeCoverage]
internal static class ParameterViewExtensions
{
	public static TParam GetParameterProperty<TParam>( this ParameterView parameters, string name, TParam fallback )
	{
		return parameters.TryGetValue<TParam>( name, out var value ) ? value : fallback;
	}
}
