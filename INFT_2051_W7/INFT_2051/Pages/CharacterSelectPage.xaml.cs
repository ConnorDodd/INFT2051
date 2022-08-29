using INFT_2051.Models;

namespace INFT_2051.Pages;

public partial class CharacterSelectPage : ContentPage
{
    public CharacterSelectPage()
	{
        InitializeComponent();
	}

    private void CharacterSelectListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        CharacterModel tapped = (CharacterModel)e.Item;
        Navigation.PushAsync(new CharacterTabPage(tapped));
    }

    private void AddCharacterButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CharacterTabPage(new CharacterModel()
        {
            HPCurrent = 15,
            HPTotal = 15
        }));
    }
}