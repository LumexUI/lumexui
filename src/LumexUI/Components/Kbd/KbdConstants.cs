// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI;

internal static class KbdConstants
{
	public static readonly Dictionary<KeyboardKey, string> KeyboardKeys = new()
	{
		[KeyboardKey.Command] = "⌘",
		[KeyboardKey.Shift] = "⇧",
		[KeyboardKey.Control] = "⌃",
		[KeyboardKey.Option] = "⌥",
		[KeyboardKey.Alt] = "⎇",
		[KeyboardKey.Win] = "⊞",
		[KeyboardKey.Fn] = "fn",
		[KeyboardKey.Enter] = "↵",
		[KeyboardKey.Delete] = "⌫",
		[KeyboardKey.Escape] = "⎋",
		[KeyboardKey.Tab] = "⇥",
		[KeyboardKey.CapsLock] = "⇪",
		[KeyboardKey.Up] = "↑",
		[KeyboardKey.Right] = "→",
		[KeyboardKey.Down] = "↓",
		[KeyboardKey.Left] = "←",
		[KeyboardKey.PageUp] = "⇞",
		[KeyboardKey.PageDown] = "⇟",
		[KeyboardKey.Home] = "↖",
		[KeyboardKey.End] = "↘",
		[KeyboardKey.Help] = "?",
		[KeyboardKey.Space] = "␣",
	};
}
