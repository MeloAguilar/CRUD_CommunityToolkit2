using CRUD_CommunityToolkitUI.Views;

namespace CRUD_CommunityToolkitUI;

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


		builder.Services.AddSingleton<clsVMListadoPersonas>();
		builder.Services.AddSingleton<MainPage>();
		
		builder.Services.AddTransient<clsVMEditarInsertarPersona>();
		builder.Services.AddTransient<DetallesPersonaPage>();
		
		return builder.Build();
	}
}
