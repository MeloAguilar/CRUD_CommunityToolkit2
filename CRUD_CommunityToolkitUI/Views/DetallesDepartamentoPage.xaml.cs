namespace CRUD_CommunityToolkitUI.Views;

public partial class DetallesDepartamentoPage : ContentPage
{
	public DetallesDepartamentoPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		clsVMEditarInsertarDepartamento vm = await clsVMEditarInsertarDepartamento.CreateAsync();
		BindingContext = vm;
		base.OnAppearing();
	}
}