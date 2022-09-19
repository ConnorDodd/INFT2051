using INFT_2051.Models;
using INFT_2051.ViewModels;

namespace INFT_2051.Layouts;

public partial class CharacterSelectView : ContentView
{
	public CharacterSelectView()
	{
		InitializeComponent();
	}

	private void DeleteButton_Clicked(object sender, EventArgs e)
	{
        CharacterModel model = (CharacterModel)BindingContext;
		CharacterViewModel.Current.DeleteCharacter(model);
		CharacterViewModel.Current.LoadCharacters();
    }
}