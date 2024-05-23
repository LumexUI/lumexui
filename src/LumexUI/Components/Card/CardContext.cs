namespace LumexUI;

internal class CardContext( LumexCard owner )
{
    public LumexCard Owner { get; } = owner;

    public static void ThrowMissingParentComponentException( string componentName )
    {
        throw new InvalidOperationException( 
            $"<{componentName} /> component must be used within a <{nameof( LumexCard )} /> component." );
    }
}
