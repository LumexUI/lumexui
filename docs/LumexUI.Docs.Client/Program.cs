using LumexUI.Docs.Client.Services;
using LumexUI.Extensions;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using TailwindMerge.Models;

var builder = WebAssemblyHostBuilder.CreateDefault( args );

builder.Services.AddHttpClient();
builder.Services.AddLumexServices( options =>
{
    options.Extend( new ExtendedConfig()
    {
        ClassGroups = new()
        {
            ["bg-image"] = new ClassGroup( "bg", ["dots"] ),
        }
    } );
} );

builder.Services.AddScoped<DocsThemeService>();

await builder.Build().RunAsync();
