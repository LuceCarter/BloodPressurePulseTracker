using Microsoft.Maui.Controls.Compatibility;

namespace BloodPressurePulseTracker;

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
			})
			.ConfigureMauiHandlers(handlers =>
            {
#if __ANDROID__
								handlers.AddCompatibilityRenderer(typeof(AppShell), typeof(BloodPressureTracker.Droid.Renderers.CustomShellRenderer));
#endif

#if __IOS__
                handlers.AddCompatibilityRenderer(typeof(AppShell), typeof(BloodPressurePulseTracker.iOS.CustomShellRenderer));
#endif

			});

		return builder.Build();
	}
}
