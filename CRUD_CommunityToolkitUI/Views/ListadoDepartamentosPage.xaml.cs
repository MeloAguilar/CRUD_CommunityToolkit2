namespace CRUD_CommunityToolkitUI.Views;

public partial class ListadoDepartamentosPage : ContentPage
{
	public ListadoDepartamentosPage()
	{
		InitializeComponent();
	}
	protected override bool OnBackButtonPressed()
	{
		App.Current.MainPage = new MainPage();
		return base.OnBackButtonPressed();
	}

	protected override async void OnAppearing()
	{

		clsVMListadoDepartamentos vm = await clsVMListadoDepartamentos.CreateAsync();
		BindingContext = vm;
		InitializeComponent();

		base.OnAppearing();
	}
}