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

	protected override void OnAppearing()
	{
		InitializeComponent();

		base.OnAppearing();
	}
}