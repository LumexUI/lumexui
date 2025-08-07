using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LumexUI.Shared.Icons;

public class DynamicIcon : IComponent
{
	[Parameter, EditorRequired] public Type Type { get; set; } = default!;

	[Parameter] public string Size { get; set; } = "24";

	private RenderHandle _renderHandle;
	private readonly RenderFragment _render;
	private readonly Dictionary<string, object> _attributes = [];

	public DynamicIcon()
	{
		_render = Render;
	}

	public void Attach( RenderHandle renderHandle )
	{
		_renderHandle = renderHandle;
	}

	public Task SetParametersAsync( ParameterView parameters )
	{
		// This manual parameter assignment logic will be marginally faster than calling
		// ComponentProperties.SetProperties.
		foreach( var entry in parameters )
		{
			if( entry.Name.Equals( nameof( Type ), StringComparison.OrdinalIgnoreCase ) )
			{
				Type = (Type)entry.Value;
			}
			else if( entry.Name.Equals( nameof( Size ), StringComparison.OrdinalIgnoreCase ) )
			{
				Size = (string)entry.Value;
			}
			else
			{
				_attributes.TryAdd( entry.Name, entry.Value );
			}
		}

		if( Type is null )
		{
			throw new InvalidOperationException( $"{GetType()} requires a non-null value for the parameter {nameof( Type )}." );
		}

		_renderHandle.Render( _render );
		return Task.CompletedTask;
	}

	void Render( RenderTreeBuilder builder )
	{
		builder.OpenComponent( 0, Type );
		builder.AddComponentParameter( 1, nameof( Size ), Size );
		builder.AddMultipleAttributes( 2, _attributes );
		builder.CloseComponent();
	}
}
