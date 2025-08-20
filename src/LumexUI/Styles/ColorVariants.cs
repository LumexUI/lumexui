using LumexUI.Common;

namespace LumexUI.Styles;

internal class ColorVariants
{
    public readonly static Dictionary<ThemeColor, string> Solid = new()
    {
        [ThemeColor.None] = "",
        [ThemeColor.Default] = "bg-default text-default-foreground",
        [ThemeColor.Primary] = "bg-primary text-primary-foreground",
        [ThemeColor.Secondary] = "bg-secondary text-secondary-foreground",
        [ThemeColor.Success] = "bg-success text-success-foreground",
        [ThemeColor.Warning] = "bg-warning text-warning-foreground",
        [ThemeColor.Danger] = "bg-danger text-danger-foreground",
        [ThemeColor.Info] = "bg-info text-info-foreground"
    };

    public readonly static Dictionary<ThemeColor, string> Outlined = new()
    {
        [ThemeColor.None] = "",
        [ThemeColor.Default] = "bg-transparent border-default text-foreground",
        [ThemeColor.Primary] = "bg-transparent border-primary text-primary",
        [ThemeColor.Secondary] = "bg-transparent border-secondary text-secondary",
        [ThemeColor.Success] = "bg-transparent border-success text-success",
        [ThemeColor.Warning] = "bg-transparent border-warning text-warning",
        [ThemeColor.Danger] = "bg-transparent border-danger text-danger",
        [ThemeColor.Info] = "bg-transparent border-info text-info"
    };

    public readonly static Dictionary<ThemeColor, string> Flat = new()
    {
        [ThemeColor.None] = "",
        [ThemeColor.Default] = "bg-default/40 text-default-700",
        [ThemeColor.Primary] = "bg-primary/20 text-primary-600",
        [ThemeColor.Secondary] = "bg-secondary/20 text-secondary-600",
        [ThemeColor.Success] = "bg-success/20 text-success-700 dark:text-success-600",
        [ThemeColor.Warning] = "bg-warning/20 text-warning-800 dark:text-warning-700",
        [ThemeColor.Danger] = "bg-danger/20 text-danger-600",
        [ThemeColor.Info] = "bg-info/20 text-info-600"
	};

    public readonly static Dictionary<ThemeColor, string> Shadow = new()
    {
        [ThemeColor.None] = "",
        [ThemeColor.Default] = "shadow-md shadow-default/40 bg-default text-default-foreground",
        [ThemeColor.Primary] = "shadow-md shadow-primary/40 bg-primary text-primary-foreground",
        [ThemeColor.Secondary] = "shadow-md shadow-secondary/40 bg-secondary text-secondary-foreground",
        [ThemeColor.Success] = "shadow-md shadow-success/40 bg-success text-success-foreground",
        [ThemeColor.Warning] = "shadow-md shadow-warning/40 bg-warning text-warning-foreground",
        [ThemeColor.Danger] = "shadow-md shadow-danger/40 bg-danger text-danger-foreground",
        [ThemeColor.Info] = "shadow-md shadow-info/40 bg-info text-info-foreground"
    };

    public readonly static Dictionary<ThemeColor, string> Ghost = new()
    {
        [ThemeColor.None] = "",
        [ThemeColor.Default] = "border-default text-default-foreground",
        [ThemeColor.Primary] = "border-primary text-primary",
        [ThemeColor.Secondary] = "border-secondary text-secondary",
        [ThemeColor.Success] = "border-success text-success",
        [ThemeColor.Warning] = "border-warning text-warning",
        [ThemeColor.Danger] = "border-danger text-danger",
        [ThemeColor.Info] = "border-info text-info"
    };

    public readonly static Dictionary<ThemeColor, string> Light = new()
    {
        [ThemeColor.None] = "",
        [ThemeColor.Default] = "bg-transparent text-default-foreground",
        [ThemeColor.Primary] = "bg-transparent text-primary",
        [ThemeColor.Secondary] = "bg-transparent text-secondary",
        [ThemeColor.Success] = "bg-transparent text-success",
        [ThemeColor.Warning] = "bg-transparent text-warning",
        [ThemeColor.Danger] = "bg-transparenttext-danger",
        [ThemeColor.Info] = "bg-transparent text-info"
    };
}
