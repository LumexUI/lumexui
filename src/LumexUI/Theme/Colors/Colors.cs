// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI.Theme;

/// <summary>
/// Provides predefined colors and color scales for themes.
/// </summary>
public static class Colors
{
    /// <summary>
    /// The white color.
    /// </summary>
    public const string White = "#FFFFFF";

    /// <summary>
    /// The black color.
    /// </summary>
    public const string Black = "#000000";

    /// <summary>
    /// The scale of pink colors.
    /// </summary>
    public readonly static Dictionary<string, string> Pink = new()
    {
        ["50"] = "#FFF0F8",
        ["100"] = "#FFD6EB",
        ["200"] = "#FAA8D1",
        ["300"] = "#F47BB2",
        ["400"] = "#F3599C",
        ["500"] = "#E24084",
        ["600"] = "#C4175F",
        ["700"] = "#9D174D",
        ["800"] = "#810E3C",
        ["900"] = "#4A0722"
    };

    /// <summary>
    /// The scale of rose colors.
    /// </summary>
    public readonly static Dictionary<string, string> Rose = new()
    {
        ["50"] = "#FFF0F2",
        ["100"] = "#FFD1D9",
        ["200"] = "#FFA3AF",
        ["300"] = "#F97183",
        ["400"] = "#F54761",
        ["500"] = "#DB1F48",
        ["600"] = "#C91841",
        ["700"] = "#9D153C",
        ["800"] = "#801434",
        ["900"] = "#510B20"
    };

    /// <summary>
    /// The scale of red colors.
    /// </summary>
    public readonly static Dictionary<string, string> Red = new()
    {
        ["50"] = "#FFF0F0",
        ["100"] = "#FFD1D1",
        ["200"] = "#FCA6A6",
        ["300"] = "#FB6F6F",
        ["400"] = "#FB5050",
        ["500"] = "#ED4040",
        ["600"] = "#DE2B2B",
        ["700"] = "#9D1515",
        ["800"] = "#821C1C",
        ["900"] = "#420000"
    };

    /// <summary>
    /// The scale of orange colors.
    /// </summary>
    public readonly static Dictionary<string, string> Orange = new()
    {
        ["50"] = "#FFF7F0",
        ["100"] = "#FFE3CC",
        ["200"] = "#FABF8F",
        ["300"] = "#FBA665",
        ["400"] = "#F68D3C",
        ["500"] = "#F07828",
        ["600"] = "#D15D10",
        ["700"] = "#A7450C",
        ["800"] = "#7F2B0A",
        ["900"] = "#4E1C09"
    };

    /// <summary>
    /// The scale of yellow colors.
    /// </summary>
    public readonly static Dictionary<string, string> Yellow = new()
    {
        ["50"] = "#FFFCEB",
        ["100"] = "#FFF5C2",
        ["200"] = "#FDE786",
        ["300"] = "#FEDE6D",
        ["400"] = "#FAC71E",
        ["500"] = "#F5B40F",
        ["600"] = "#CA8907",
        ["700"] = "#A8610B",
        ["800"] = "#733C11",
        ["900"] = "#48250E"
    };

    /// <summary>
    /// The scale of green colors.
    /// </summary>
    public readonly static Dictionary<string, string> Green = new()
    {
        ["50"] = "#F0FFF3",
        ["100"] = "#D1FFDC",
        ["200"] = "#A0FDB6",
        ["300"] = "#7AEB94",
        ["400"] = "#52E075",
        ["500"] = "#2AB74F",
        ["600"] = "#19A347",
        ["700"] = "#137736",
        ["800"] = "#0B4B24",
        ["900"] = "#062D15"
    };

    /// <summary>
    /// The scale of teal colors.
    /// </summary>
    public readonly static Dictionary<string, string> Teal = new()
    {
        ["50"] = "#ECFDF5",
        ["100"] = "#D3FDE8",
        ["200"] = "#A8FAD1",
        ["300"] = "#85F4BD",
        ["400"] = "#0DD38E",
        ["500"] = "#0EB980",
        ["600"] = "#0E9A6B",
        ["700"] = "#0F7152",
        ["800"] = "#064C39",
        ["900"] = "#012D24"
    };

    /// <summary>
    /// The scale of lightblue colors.
    /// </summary>
    public readonly static Dictionary<string, string> LightBlue = new()
    {
        ["50"] = "#F0FBFF",
        ["100"] = "#DBF5FF",
        ["200"] = "#B5E8FD",
        ["300"] = "#78D1FC",
        ["400"] = "#34BDFC",
        ["500"] = "#049FE7",
        ["600"] = "#0480B9",
        ["700"] = "#076997",
        ["800"] = "#0D4A73",
        ["900"] = "#082A45"
    };

    /// <summary>
    /// The scale of blue colors.
    /// </summary>
    public readonly static Dictionary<string, string> Blue = new()
    {
        ["50"] = "#F0F8FF",
        ["100"] = "#D7EBFE",
        ["200"] = "#B4D9FD",
        ["300"] = "#7FBDFA",
        ["400"] = "#4893F4",
        ["500"] = "#227AEC",
        ["600"] = "#1D5BD8",
        ["700"] = "#19419F",
        ["800"] = "#153279",
        ["900"] = "#0F1C43"
    };

    /// <summary>
    /// The scale of indigo colors.
    /// </summary>
    public readonly static Dictionary<string, string> Indigo = new()
    {
        ["50"] = "#F0F2FF",
        ["100"] = "#E1E6FE",
        ["200"] = "#C3CFFE",
        ["300"] = "#93A4FB",
        ["400"] = "#6E77F7",
        ["500"] = "#5E62E4",
        ["600"] = "#474CD7",
        ["700"] = "#3935BB",
        ["800"] = "#2A2583",
        ["900"] = "#1D1B4B"
    };

    /// <summary>
    /// The scale of violet colors.
    /// </summary>
    public readonly static Dictionary<string, string> Violet = new()
    {
        ["50"] = "#F4F0FF",
        ["100"] = "#E8E1FF",
        ["200"] = "#D8CDFE",
        ["300"] = "#B5A1FC",
        ["400"] = "#9F7DFC",
        ["500"] = "#8050F2",
        ["600"] = "#6A29DB",
        ["700"] = "#5D27B9",
        ["800"] = "#451A8E",
        ["900"] = "#311560"
    };

    /// <summary>
    /// The scale of gray colors.
    /// </summary>
    public readonly static Dictionary<string, string> Gray = new()
    {
        ["50"] = "#FAFAFA",
        ["100"] = "#F4F4F5",
        ["200"] = "#E4E4E7",
        ["300"] = "#CACACE",
        ["400"] = "#9C9CA5",
        ["500"] = "#52525B",
        ["600"] = "#3F3F46",
        ["700"] = "#27272A",
        ["800"] = "#18181B",
        ["900"] = "#09090B"
    };

    /// <summary>
    /// Reverses the order of color values in a given color scale.
    /// </summary>
    /// <param name="colors">The color scale to reverse.</param>
    /// <returns>A <see cref="Dictionary{TKey, TValue}"/> with the color values reversed.</returns>
    internal static Dictionary<string, string> ReverseColorValues( Dictionary<string, string> colors )
    {
        var reversedColorValues = new Dictionary<string, string>();
        var keys = colors.Keys.ToList();
        var values = colors.Values.ToList();

        for( var i = 0; i < values.Count; i++ )
        {
            reversedColorValues[keys[i]] = values[values.Count - 1 - i];
        }

        return reversedColorValues;
    }
}
