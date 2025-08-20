namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class TeamMembers : ExampleComponentBase
{
	private readonly Dictionary<string, string> _roles = new()
	{
		["Viewer"] = "Can view and comment",
		["Developer"] = "Can view, comment and edit",
		["Billing"] = "Can view, comment and manage billing",
		["Owner"] = "Admin-level access to all resources",
	};

	private readonly List<Member> _members =
	[
		new Member("Pepper Potts", "pepper.potts@example.com", "https://d2u8k2ocievbld.cloudfront.net/memojis/female/4.png", "Owner"),
		new Member("Peter Parker", "peter.parker@example.com", "https://d2u8k2ocievbld.cloudfront.net/memojis/male/5.png", "Developer"),
		new Member("Stephen Strange", "stephen.strange@example.com", "https://d2u8k2ocievbld.cloudfront.net/memojis/male/6.png", "Viewer")
	];

	private record Member( string Name, string Email, string Avatar, string Role );
}