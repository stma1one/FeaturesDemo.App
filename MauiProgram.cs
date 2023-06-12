using FeaturesDemo.ViewModels;
using FeaturesDemo.Views;
using Microsoft.Extensions.Logging;

namespace FeaturesDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
	
		builder.Services.AddTransient<NetworkPage>();
        builder.Services.AddTransient<NetworkPageViewModel>();
        builder.Services.AddTransient<SendSmsPageViewModel>();
        builder.Services.AddTransient<SendSmsPage>();
        builder.Services.AddSingleton<MainMenuPage>();
        builder.Services.AddSingleton<MainMenuPageViewModel>();
        builder.Services.AddSingleton<TakePicturePage>();
        builder.Services.AddSingleton<TakePicturePageViewModel>();

#if DEBUG
        builder.Logging.AddDebug();	
#endif

		return builder.Build();
	}
}
