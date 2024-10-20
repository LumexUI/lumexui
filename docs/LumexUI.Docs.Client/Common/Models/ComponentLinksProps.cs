namespace LumexUI.Docs.Client.Common;

public class ComponentLinksProps( string componentName, bool isServer )
{
    public string ComponentName { get; } = componentName;
    public bool IsServer { get; } = isServer;
}
