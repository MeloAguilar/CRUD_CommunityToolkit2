using BL.Listados;

namespace CRUD_CommunityToolkitUI.Views;

public partial class ListaPersonasPage : ContentPage
{
	public ListaPersonasPage()
	{
		InitializeComponent();
	}

	

	protected override async void OnAppearing()
	{

		clsVMListadoPersonas vm = await clsVMListadoPersonas.CreateAsync();
		BindingContext = vm;
		InitializeComponent();

		base.OnAppearing();
	}
}