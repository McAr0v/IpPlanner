using IpPlanner.DataBase.Auth;
using Microsoft.Extensions.Logging;

namespace IpPlanner
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

            // Инициализируем некоторыми настройками текущего пользователя
            CustomUser.SetUser(AuthInDataBase.setUser());

            return builder.Build();
        }
    }
}
