// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Common;

/// <summary>
/// Specifies the layout behavior for a table, determining how the table and its columns are sized.
/// </summary>
/// <remarks>
/// See <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout" />
/// </remarks>
public enum Layout
{
    /// <summary>
    /// Automatically sizes columns based on content, allowing for flexible widths.
    /// </summary>
    /// <remarks>
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout" />
    /// </remarks>
    Auto,

    /// <summary>
    /// Fixes the width of columns, preventing them from adjusting based on content.
    /// </summary>
    /// <remarks>
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout" />
    /// </remarks>
    Fixed
}
