namespace LumexUI;

internal class AccordionContext( LumexAccordion owner )
{
    public LumexAccordion Owner { get; } = owner;

    public static void ThrowMissingParentComponentException( AccordionContext context, string componentName )
    {
        if( context is null )
        {
            throw new InvalidOperationException(
                $"<{componentName} /> component must be used within a <{nameof( LumexAccordion )} /> component." );
        }       
    }
}
