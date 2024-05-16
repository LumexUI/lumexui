using LumexUI.Common;

namespace LumexUI.Styles;

internal record ColorVariants
{
    public readonly static Dictionary<ThemeColor, string> Solid = new()
    {
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
        [ThemeColor.Default] = "border-default text-foreground",
        [ThemeColor.Primary] = "border-primary text-primary",
        [ThemeColor.Secondary] = "border-secondary text-secondary",
        [ThemeColor.Success] = "border-success text-success",
        [ThemeColor.Warning] = "border-warning text-warning",
        [ThemeColor.Danger] = "border-danger text-danger",
        [ThemeColor.Info] = "border-info text-info"
    };

    public readonly static Dictionary<ThemeColor, string> Flat = new()
    {
        [ThemeColor.Default] = "bg-default-100 text-default-foreground",
        [ThemeColor.Primary] = "bg-primary-50 text-primary",
        [ThemeColor.Secondary] = "bg-secondary-50 text-secondary",
        [ThemeColor.Success] = "bg-success-50 text-success-600",
        [ThemeColor.Warning] = "bg-warning-50 text-warning-600",
        [ThemeColor.Danger] = "bg-danger-50 text-danger-600",
        [ThemeColor.Info] = "bg-info-50 text-info"
    };

    public readonly static Dictionary<ThemeColor, string> Shadow = new()
    {
        [ThemeColor.Default] = "shadow-lg shadow-default/40 bg-default text-default-foreground",
        [ThemeColor.Primary] = "shadow-lg shadow-primary/40 bg-primary text-primary-foreground",
        [ThemeColor.Secondary] = "shadow-lg shadow-secondary/40 bg-secondary text-secondary-foreground",
        [ThemeColor.Success] = "shadow-lg shadow-success/40 bg-success text-success-foreground",
        [ThemeColor.Warning] = "shadow-lg shadow-warning/40 bg-warning text-warning-foreground",
        [ThemeColor.Danger] = "shadow-lg shadow-danger/40 bg-danger text-danger-foreground",
        [ThemeColor.Info] = "shadow-lg shadow-info/40 bg-info text-info-foreground"
    };

    public readonly static Dictionary<ThemeColor, string> Ghost = new()
    {
        [ThemeColor.Default] = "borde-default text-default-foreground hover:bg-default",
        [ThemeColor.Primary] = "border-primary text-primary hover:text-primary-foreground hover:bg-primary",
        [ThemeColor.Secondary] = "border-secondary text-secondary hover:text-secondary-foreground hover:bg-secondary",
        [ThemeColor.Success] = "border-success text-success hover:text-success-foreground hover:bg-success",
        [ThemeColor.Warning] = "border-warning text-warning hover:text-warning-foreground hover:bg-warning",
        [ThemeColor.Danger] = "border-danger text-danger hover:text-danger-foreground hover:bg-danger",
        [ThemeColor.Info] = "border-info text-info hover:text-info-foreground hover:bg-info"
    };

    public readonly static Dictionary<ThemeColor, string> Light = new()
    {
        [ThemeColor.Default] = "text-default-foreground",
        [ThemeColor.Primary] = "text-primary",
        [ThemeColor.Secondary] = "text-secondary",
        [ThemeColor.Success] = "text-success",
        [ThemeColor.Warning] = "text-warning",
        [ThemeColor.Danger] = "text-danger",
        [ThemeColor.Info] = "text-info"
    };
}
