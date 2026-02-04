// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class ToastProvider
{
	public static string Style()
	{
		return new ElementClass()
			.Add( "[--normal-bg:var(--lumex-surface1)]!" )
			.Add( "[--normal-text:var(--lumex-surface1-foreground)]!" )
			.Add( "[--normal-border:var(--lumex-default-200)]!" )
			.Add( "[--border-radius:var(--lumex-radius-medium)]!" )
			.Add( "dark:[--normal-border:var(--lumex-default-100)]!" );
	}
}
