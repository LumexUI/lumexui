// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Docs.Client.Components;

public partial class CodeSnippetCollapsible : CodeSnippet
{
	private bool _isExpanded;

	private void Expand()
	{
		_isExpanded = true;
	}
}
