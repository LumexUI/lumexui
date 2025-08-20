// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI.Docs.Client.Services;

public class DocsThemeService
{
	private ThemeColor _themeColor = ThemeColor.Default;

	public event Action? OnChanged;

	public void SetThemeColor( ThemeColor themeColor )
	{
		_themeColor = themeColor;
		NotifyThemeColorChanged();
	}

	public ThemeColor GetThemeColor() => _themeColor;

	public void NotifyThemeColorChanged() => OnChanged?.Invoke();
}
