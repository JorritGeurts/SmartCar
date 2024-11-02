using Microsoft.Extensions.Logging;
using SmartCar.Services;
using SmartCar.viewModels;
using SmartCar.ViewModels;
using SmartCar.Views;

namespace SmartCar
{
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
#endif

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<IHomeViewModel, HomeViewModel>();

            builder.Services.AddTransient<InfoPage>();
            builder.Services.AddTransient<IInfoViewModel, InfoViewModel>();

            builder.Services.AddSingleton<IStorageService, StorageService>();
            builder.Services.AddTransient<INavigationService, NavigationService>();


            return builder.Build();
        }
    }
}
