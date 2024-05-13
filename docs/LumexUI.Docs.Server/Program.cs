// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using TailwindMerge.Extensions;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTailwindMerge();

var app = builder.Build();

// Configure the HTTP request pipeline.
if( app.Environment.IsDevelopment() )
{
#if ENABLE_WASM_HOSTING
    app.UseWebAssemblyDebugging();
#endif
}
else
{
    app.UseExceptionHandler( "/Error" );
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();

#if ENABLE_WASM_HOSTING
ApplyHotReloadWorkaround( app );
app.Map( "/webassembly", app =>
{
    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();
    app.UseEndpoints( e => e.MapFallbackToPage( "webassembly/{*path:nonfile}", "/_WebAssemblyHost" ) );
} );

// This is a temporary workaround needed until the next patch release of ASP.NET Core
// The underlying bug was fixed in https://github.com/dotnet/sdk/pull/25534 but that update hasn't shipped yet
void ApplyHotReloadWorkaround( WebApplication app )
{
    app.Use( ( ctx, next ) =>
    {
        if( ctx.Request.Path == "/webassembly/_framework/blazor-hotreload" )
        {
            ctx.Response.Redirect( "/_framework/blazor-hotreload" );
            return Task.CompletedTask;
        }

        return next( ctx );
    } );
}
#endif

app.Map( "/server", app =>
{
    app.UseStaticFiles();
    app.UseEndpoints( endpoints => endpoints.MapBlazorHub( "/server/_blazor" ) );
    app.UseEndpoints( e => e.MapFallbackToPage( "server/{*path:nonfile}", "/_ServerHost" ) );
} );

app.Run();
