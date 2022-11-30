namespace CRUD_CommunityToolkitUI.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		App.Current.MainPage = new AppShell();
	}

}