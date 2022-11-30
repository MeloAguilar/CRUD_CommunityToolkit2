namespace CRUD_CommunityToolkitUI.Views;

public partial class ListaPersonasPage : ContentPage
{
	public ListaPersonasPage()
	{
		InitializeComponent();
	}

	protected override bool OnBackButtonPressed()
	{
		App.Current.MainPage = new MainPage();
		return base.OnBackButtonPressed();
	}

	protected override void OnAppearing()
	{
		InitializeComponent();

		base.OnAppearing();
	}
}