namespace LumexUI.Motion.Types;

internal class PresenceContext
{
    private bool _collecting = false;

    public List<Motion> PresentChildren { get; } = [];
    public List<Motion> RenderedChildren { get; set; } = [];
    public List<Motion> DiffChildren { get; set; } = [];
    public List<object?> PresentKeys => PresentChildren.Select( c => c.Key ).ToList();
    public bool PresenceHasChanged => !PresentChildren.SequenceEqual( DiffChildren );

    public void Register( Motion m )
    {
        if( _collecting )
        {
            PresentChildren.Add( m );
        }
    }

    public void StartCollecting()
    {
        PresentChildren.Clear();
        _collecting = true;
    }

    public void StopCollecting()
    {
        _collecting = false;
    }
}
