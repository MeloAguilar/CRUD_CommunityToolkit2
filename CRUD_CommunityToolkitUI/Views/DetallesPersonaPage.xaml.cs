using Entities;

namespace CRUD_CommunityToolkitUI.Views;


public partial class DetallesPersonaPage : ContentPage
{

	
	public DetallesPersonaPage(clsVMEditarInsertarPersona viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}


	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{

		base.OnNavigatedTo(args);
	}

}