using LumexUI.Common;

namespace LumexUI.Docs.Client.Pages.Home.Examples;

public partial class UserTable : ExampleComponentBase
{
	private IQueryable<User> FilteredUsers
	{
		get
		{
			var result = _users;

			if( !string.IsNullOrEmpty( _nameFilter ) )
			{
				result = result.Where( u => u.Name.Contains( _nameFilter, StringComparison.CurrentCultureIgnoreCase ) );
			}

			return result;
		}
	}

	private readonly IQueryable<User> _users = new List<User>()
	{
		new User(1, "Pepper Potts", "Head of Product", "pepper.potts@example.com", "Owner", "Active"),
		new User(2, "Peter Parker", "Front-end Developer", "peter.parker@example.com", "Member", "Paused"),
		new User(3, "Hope van Dyne", "Designer", "hope.van.dyne@example.com", "Member", "Inactive"),
		new User(4, "Stephen Strange", "Principal Designer", "stephen.strange@example.com", "Admin", "Active"),
		new User(5, "Tony Stark", "Director", "tony.stark@example.com", "Owner", "Vacation")
	}.AsQueryable();

	private readonly Dictionary<string, ThemeColor> _statusMap = new()
	{
		["Active"] = ThemeColor.Success,
		["Paused"] = ThemeColor.Warning,
		["Vacation"] = ThemeColor.Secondary,
		["Inactive"] = ThemeColor.Danger
	};

	private readonly string[] _columns =
	[
		nameof( User.Id ),
		nameof( User.Name ),
		nameof( User.Title ),
		nameof( User.Role ),
		nameof( User.Status )
	];

	private ICollection<User> _selectedUsers = [];
	private ICollection<string> _selectedColumns =
	[
		nameof( User.Name ),
		nameof( User.Role ),
		nameof( User.Status )
	];

	private string? _nameFilter;

	private bool IsColumnVisible( string column ) => _selectedColumns.Contains( column );

	private record User( int Id, string Name, string Title, string Email, string Role, string Status );
}