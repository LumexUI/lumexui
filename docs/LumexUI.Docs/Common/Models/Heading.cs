namespace LumexUI.Docs.Common;

public class Heading
{
    public string Title { get; init; }
    public Heading[]? Children { get; init; }

    public Heading( string title )
    {
        Title = title;
    }

    public Heading( string title, Heading[] children ) : this( title )
    {
        Children = children;
    }
}
