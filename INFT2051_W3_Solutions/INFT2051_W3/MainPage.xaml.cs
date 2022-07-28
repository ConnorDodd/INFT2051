using INFT2051_W3.Pages;

namespace INFT2051_W3;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		//NavigationPage.SetHasNavigationBar(this, false);
		InitializeComponent();
	}

	private void CharacterButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new CharacterTabPage());
	}
}

