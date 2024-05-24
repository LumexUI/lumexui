namespace LumexUI;

internal class CardContext( LumexCard owner )
{
    public LumexCard Owner { get; } = owner;

    public static void ThrowMissingParentComponentException( CardContext context, string componentName )
    {
        if( context is null )
        {
            throw new InvalidOperationException(
                $"<{componentName} /> component must be used within a <{nameof( LumexCard )} /> component." );
        }       
    }
}
