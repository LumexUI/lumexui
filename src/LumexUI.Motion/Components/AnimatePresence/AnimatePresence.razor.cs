using LumexUI.Motion.Types;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Motion;

/// <summary>
/// 
/// </summary>
public partial class AnimatePresence : ComponentBase
{
    /// <summary>
    /// 
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    private readonly PresenceContext _context;
    private readonly RenderFragment _render;

    /// <summary>
    /// 
    /// </summary>
    public AnimatePresence()
    {
        _context = new PresenceContext();
        _render = Render;
    }
}