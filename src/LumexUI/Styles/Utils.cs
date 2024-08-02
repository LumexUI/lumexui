using LumexUI.Utilities;

namespace LumexUI.Styles;

internal class Utils
{
    public readonly static string VisuallyHidden = ElementClass.Empty()
        .Add( "sr-only" )
        .ToString();

    public readonly static string FocusVisible = ElementClass.Empty()
        .Add( "outline-none" )
        .Add( "focus-visible:z-10" )
        .Add( "focus-visible:outline-2" )
        .Add( "focus-visible:outline-focus" )
        .Add( "focus-visible:outline-offset-2" )
        .ToString();

    public readonly static string GroupFocusVisible = ElementClass.Empty()
        .Add( "outline-none" )
        .Add( "group-focus-visible:z-10" )
        .Add( "group-focus-visible:ring-2" )
        .Add( "group-focus-visible:ring-focus" )
        .Add( "group-focus-visible:ring-offset-2" )
        .Add( "group-focus-visible:ring-offset-background" )
        .ToString();

    //public readonly static string GroupDataFocusVisible = ElementClass.Empty()
    //    .Add( "outline-none" )
    //    .Add( "group-data-[focus-visible=true]:z-10" )
    //    .Add( "group-data-[focus-visible=true]:ring-2" )
    //    .Add( "group-data-[focus-visible=true]:ring-focus" )
    //    .Add( "group-data-[focus-visible=true]:ring-offset-2" )
    //    .Add( "group-data-[focus-visible=true]:ring-offset-background" )
    //    .ToString();
}
