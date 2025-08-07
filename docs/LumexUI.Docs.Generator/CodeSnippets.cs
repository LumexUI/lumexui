// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Text;

using Markdig;

namespace LumexUI.Docs.Generator;

internal static class CodeSnippets
{
    private static readonly MarkdownPipeline _pipeline;

    static CodeSnippets()
    {
        _pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();
    }

    public static Task GenerateAsync()
    {
        var rootPath = GetRootDirectoryPath();
        if( string.IsNullOrEmpty( rootPath ) )
        {
            throw new DirectoryNotFoundException( "The 'docs' directory was not found in the path hierarchy." );
        }

        var contentsPath = Directory
            .EnumerateDirectories( rootPath, Path.Combine( "LumexUI.Docs.Client" ) )
            .FirstOrDefault();

        if( string.IsNullOrEmpty( contentsPath ) )
        {
            throw new DirectoryNotFoundException( "The 'LumexUI.Docs/LumexUI.Docs.Client' directory was not found." );
        }

        return ProcessAsync( new DirectoryInfo( contentsPath ) );
    }

    private static async Task ProcessAsync( DirectoryInfo di )
    {
        foreach( var file in di.GetFiles( "Pages/*.razor", SearchOption.AllDirectories ) )
        {
            if( file.DirectoryName?.EndsWith( "Examples" ) == true )
            {
                await ProcessFileAsync( file );
            }
        }
    }

    private static async Task ProcessFileAsync( FileInfo file )
    {
        var fileName = file.Name.Replace( ".razor", ".html" );
        var filePath = file.DirectoryName!.Replace( "Examples", "Code" );
        var markdownPath = Path.Combine( filePath, fileName );

        if( !Directory.Exists( filePath ) )
        {
            Directory.CreateDirectory( filePath );
        }

        var markdownContent = ConvertRazorToMarkdown( file );
        var htmlContent = Markdown.ToHtml( markdownContent, _pipeline );
		htmlContent = htmlContent.Replace( "<pre>", "<pre class=\"line-numbers\">" );

		await using var streamWriter = new StreamWriter( markdownPath );
        await streamWriter.WriteAsync( htmlContent );
    }

    private static string ConvertRazorToMarkdown( FileInfo file )
    {
        var sb = new StringBuilder();
        sb.AppendLine( "```razor" );

        try
        {
            using var reader = file.OpenText();
            var content = reader.ReadToEnd();
            sb.AppendLine( content );
        }
        catch( IOException ex )
        {
            Console.WriteLine( $"An error occurred while reading the file: {ex.Message}" );
            return string.Empty;
        }

        sb.AppendLine( "```" );
        return sb.ToString();
    }

    private static string? GetRootDirectoryPath()
    {
        var path = Directory.GetCurrentDirectory();
        while( !string.IsNullOrEmpty( path ) )
        {
            if( Path.GetFileName( path ).Equals( "docs", StringComparison.OrdinalIgnoreCase ) )
            {
                return path;
            }

            var parentPath = Path.GetDirectoryName( path );
            if( string.IsNullOrEmpty( parentPath ) || parentPath == path )
            {
                break;
            }

            path = parentPath;
        }

        return null;
    }
}
