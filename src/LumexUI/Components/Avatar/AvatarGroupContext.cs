using LumexUI.Common;

namespace LumexUI;

internal class AvatarGroupContext( LumexAvatarGroup owner ) : IComponentContext<LumexAvatarGroup>
{
	private bool _collecting;

	public LumexAvatarGroup Owner { get; } = owner;
	public List<LumexAvatar> Items { get; } = [];

	public void Register( LumexAvatar avatar )
	{
		if( !_collecting )
		{
			return;
		}

		Items.Add( avatar );
	}

	public void StartCollecting()
	{
		Items.Clear();
		_collecting = true;
	}

	public void StopCollecting()
	{
		_collecting = false;
	}

	public bool IsWithinMaxLimit( LumexAvatar item )
		=> Items.IndexOf( item ) < Owner.Max;
}
