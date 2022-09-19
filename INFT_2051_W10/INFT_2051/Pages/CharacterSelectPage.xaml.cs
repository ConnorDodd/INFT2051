using INFT_2051.Models;
using INFT_2051.ViewModels;

namespace INFT_2051.Pages;

public partial class CharacterSelectPage : ContentPage
{
    CharacterViewModel viewModel;

    public CharacterSelectPage()
	{
        BindingContext = viewModel = new CharacterViewModel();

        InitializeComponent();
	}

    protected override void OnAppearing()
    {
        viewModel.LoadCharacters();
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