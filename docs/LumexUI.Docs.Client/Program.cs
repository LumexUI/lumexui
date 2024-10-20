using LumexUI.Extensions;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using TailwindMerge.Models;

var builder = WebAssemblyHostBuilder.CreateDefault( args );

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

await builder.Build().RunAsync();
