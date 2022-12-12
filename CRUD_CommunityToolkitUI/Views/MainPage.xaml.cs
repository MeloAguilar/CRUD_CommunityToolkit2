using Microsoft.IdentityModel.Tokens;

namespace CRUD_CommunityToolkitUI.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Método que nos lleva al tab si se introdujo algo en los entrys de nombre y pass.
	/// No he querido hacer un viewmodel para el inicio de sesion porque hubiese tenido que crear otra tabla en la base de datos
	/// y como este login no era esencial solo comprobaré que tenga contenido en el campo text tanto eName como ePass.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Button_Clicked(object sender, EventArgs e)
	{
		
			App.Current.MainPage = new AppShell();
		
	}


	protected override void OnAppearing()
	{
		InitializeComponent();

		base.OnAppearing();
	}

}