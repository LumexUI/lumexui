// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using BlazorApp2;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using TailwindMerge.Extensions;

internal class Program
{
	private static async global::System.Threading.Tasks.Task Main( string[] args )
	{
		var builder = WebAssemblyHostBuilder.CreateDefault( args );
		builder.RootComponents.Add<App>( "#app" );
		builder.RootComponents.Add<HeadOutlet>( "head::after" );

		builder.Services.AddScoped( sp => new HttpClient { BaseAddress = new Uri( builder.HostEnvironment.BaseAddress ) } );

		builder.Services.AddTailwindMerge();

		await builder.Build().RunAsync();
	}
}