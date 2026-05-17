using Infrastructure.Localization;
using Main.Common.Settings;
using Main.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

AppSettings.Current = 
     builder.Configuration
            .GetSection ( "MyAppSettings" )
            .Get<MyConfigSettings> ( ) ?? new MyConfigSettings ( );

builder.Services.AddCustomLocalization ( );

builder.Services.AddInfrastructureServices( builder.Configuration );

builder.Services.AddControllersWithViews ( );



var app = builder.Build();

app.UseCustomLocalization ( );

app.UseStaticFiles ( );

app.UseRouting ( );

app.UseAuthorization ( );

app.MapDefaultControllerRoute ( );

app.UseExceptionHandler ( );

app.UseStatusCodePages ( );


app.Run();
