using LumexUI.Docs.Client.Services;
using LumexUI.Docs.Components;
using LumexUI.Extensions;

using TailwindMerge.Models;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if( app.Environment.IsDevelopment() )
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler( "/Error", createScopeForErrors: true );
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies( typeof( LumexUI.Docs.Client._Imports ).Assembly );

app.Run();
