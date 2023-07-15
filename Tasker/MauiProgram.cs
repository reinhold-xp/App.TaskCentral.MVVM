using Microsoft.Extensions.Logging;
using Tasker.Repositories;
using Tasker.MVVM.Models;

namespace Tasker;

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
                fonts.AddFont("Roboto-Regular.ttf", "Roboto");
            });

        builder.Services.AddSingleton<BaseRepository<Project>>();
        builder.Services.AddSingleton<BaseRepository<MyTask>>();


        return builder.Build();
	}
}

