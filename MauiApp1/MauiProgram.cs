using MauiApp1.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiApp1;

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

#if DEBUG
		builder.Logging.AddDebug();

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<DetailsViewModel>();
        return builder.Build();
	}
}
