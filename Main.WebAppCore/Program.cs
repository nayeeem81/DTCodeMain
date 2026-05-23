using Infrastructure.Localization;
using Main.Services;
using WebApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor ( );

builder.Services.AddScoped<IUserContext,UserContext> ( );

AppSettings.Current = 
     builder.Configuration
            .GetSection ( "MyAppSettings" )
            .Get<MyConfigSettings> ( ) ?? new MyConfigSettings ( );

builder.Services.AddCustomLocalization ( );

builder.Services.AddServiceDependencies ( builder.Configuration );

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
