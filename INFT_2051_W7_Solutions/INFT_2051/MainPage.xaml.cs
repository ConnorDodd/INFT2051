using INFT_2051.Pages;
namespace INFT_2051;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        if (LoginPage.Token == null)
        {
            Dispatcher.Dispatch(async () =>
                await Navigation.PushModalAsync(new LoginPage(), false)
            );
        }
    }

    private void CharacterButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CharacterSelectPage());
    }
}

