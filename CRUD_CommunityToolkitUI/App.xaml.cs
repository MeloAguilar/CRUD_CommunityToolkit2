using CRUD_CommunityToolkitUI.Views;

namespace CRUD_CommunityToolkitUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
