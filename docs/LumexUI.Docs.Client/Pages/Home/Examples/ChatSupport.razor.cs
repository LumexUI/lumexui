// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class ChatSupport : ExampleComponentBase
{
	[SupplyParameterFromForm]
	private ChatMessage MessageToSend { get; set; } = new()
	{
		SenderId = "Me"
	};

	private readonly List<ChatMessage> _messages =
	[
		new ChatMessage() { SenderId = "Pepper Potts", Content = "Hey, you free tomorrow evening?" },
		new ChatMessage() { SenderId = "Me", Content = "Yeah, after 6. What’s up?" },
		new ChatMessage() { SenderId = "Pepper Potts", Content = "Thinking coffee at that new place downtown..." },
		new ChatMessage() { SenderId = "Me", Content = "Sounds good! 7pm?" }
	];

	private readonly Dictionary<ThemeColor, string> _colorMap = new()
	{
		[ThemeColor.Default] = "bg-surface3 text-surface3-foreground",
		[ThemeColor.Primary] = "bg-primary text-primary-foreground",
		[ThemeColor.Secondary] = "bg-secondary text-secondary-foreground",
		[ThemeColor.Success] = "bg-success text-success-foreground",
		[ThemeColor.Warning] = "bg-warning text-warning-foreground",
		[ThemeColor.Danger] = "bg-danger text-danger-foreground",
		[ThemeColor.Info] = "bg-info text-info-foreground",
	};

	private readonly RenderFragment _renderMessages;

	public ChatSupport()
	{
		_renderMessages = RenderMessages;
	}

	private void SendMessage()
	{
		if( MessageToSend is null )
		{
			return;
		}

		if( string.IsNullOrWhiteSpace( MessageToSend.Content ) )
		{
			return;
		}

		_messages.Add( new ChatMessage
		{
			SenderId = MessageToSend.SenderId,
			Content = MessageToSend.Content
		} );

		MessageToSend.Content = null;
	}

	private sealed record ChatMessage
	{
		public Guid Id { get; } = Guid.NewGuid();
		public DateTimeOffset Timestamp { get; } = DateTimeOffset.Now;

		public string? SenderId { get; set; }
		public string? Content { get; set; }
	}
}