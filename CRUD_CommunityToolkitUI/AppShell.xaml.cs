using CRUD_CommunityToolkitUI.Views;

namespace CRUD_CommunityToolkitUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ListaPersonasPage), typeof(ListaPersonasPage));

		Routing.RegisterRoute(nameof(ListadoDepartamentosPage), typeof(ListadoDepartamentosPage));

		Routing.RegisterRoute($"{nameof(DetallesPersonaPage)}", typeof(DetallesPersonaPage));

	}
}
