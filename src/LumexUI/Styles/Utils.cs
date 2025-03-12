using LumexUI.Utilities;

namespace LumexUI.Styles;

internal class Utils
{
	public readonly static string VisuallyHidden = new ElementClass( "sr-only" );
	public readonly static string ReduceMotion = new ElementClass( "reduce-motion:transition-none" );

	public readonly static string Disabled = new ElementClass()
		.Add( "opacity-disabled" )
		.Add( "pointer-events-none" );

	public readonly static string FocusVisible = new ElementClass()
		.Add( "outline-hidden" )
		.Add( "focus-visible:z-10" )
		.Add( "focus-visible:outline-2" )
		.Add( "focus-visible:outline-focus" )
		.Add( "focus-visible:outline-offset-2" );

	public readonly static string GroupFocusVisible = new ElementClass()
		.Add( "outline-hidden" )
		.Add( "group-focus-visible:z-10" )
		.Add( "group-focus-visible:ring-2" )
		.Add( "group-focus-visible:ring-focus" )
		.Add( "group-focus-visible:ring-offset-2" )
		.Add( "group-focus-visible:ring-offset-background" );
}
