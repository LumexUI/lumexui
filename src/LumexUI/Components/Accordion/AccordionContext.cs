using LumexUI.Common;
﻿namespace LumexUI;

namespace LumexUI;

internal sealed class AccordionContext( LumexAccordion owner ) : IComponentContext<LumexAccordion>
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
