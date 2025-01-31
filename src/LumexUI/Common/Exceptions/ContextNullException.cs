// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

namespace LumexUI.Common;

[ExcludeFromCodeCoverage]
internal class ContextNullException : Exception
{
	internal ContextNullException( string? message )
		: base( message ) { }

	internal ContextNullException( string? message, Exception? innerException )
		: base( message, innerException ) { }

	internal static void ThrowIfNull<T>( [NotNull] IComponentContext<T>? context, string descendant )
		where T : LumexComponentBase
	{
		if( context is null )
		{
			var owner = typeof( T ).Name;
			Throw( owner, descendant );
		}
	}

	[DoesNotReturn]
	private static void Throw( string owner, string descendant )
	{
		throw new ContextNullException(
			$"The '<{descendant} />' component can only be used inside a '<{owner} />' component. " +
			$"Please ensure that '<{descendant} />' is a child of '<{owner} />' in component tree." );
	}
}
