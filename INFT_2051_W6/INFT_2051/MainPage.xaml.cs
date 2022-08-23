using INFT_2051.Pages;
using INFT2051.Pages;

namespace INFT_2051;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void CharacterButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CharacterSelectPage());
    }

}

