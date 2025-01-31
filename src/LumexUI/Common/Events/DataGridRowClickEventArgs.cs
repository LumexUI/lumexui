// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Common;

/// <summary>
/// Provides data for the row click event in the <see cref="LumexDataGrid{T}"/>.
/// </summary>
/// <typeparam name="T">The type of the data item associated with the clicked row.</typeparam>
[ExcludeFromCodeCoverage]
public class DataGridRowClickEventArgs<T> : EventArgs
{
	/// <summary>
	/// Gets the data item associated with the clicked row.
	/// </summary>
	public T Item { get; }

	/// <summary>
	/// Gets the zero-based index of the clicked row.
	/// </summary>
	public int Index { get; }

	/// <summary>
	/// Initializes a new instance of the <see cref="DataGridRowClickEventArgs{T}"/> class.
	/// </summary>
	/// <param name="item">The data item associated with the clicked row.</param>
	/// <param name="index">The zero-based index of the clicked row.</param>
	public DataGridRowClickEventArgs( T item, int index )
	{
		Item = item;
		Index = index;
	}
}
