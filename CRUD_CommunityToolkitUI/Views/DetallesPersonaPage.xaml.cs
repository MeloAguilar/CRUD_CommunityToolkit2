using Entities;

namespace CRUD_CommunityToolkitUI.Views;

public partial class DetallesPersonaPage : ContentPage
{


	public DetallesPersonaPage()
	{
		InitializeComponent();
	}


	protected override async void OnAppearing()
	{
		clsVMEditarInsertarPersona vm = await clsVMEditarInsertarPersona.CreateAsync();
		BindingContext = vm;
		InitializeComponent();
		base.OnAppearing();
	}

}