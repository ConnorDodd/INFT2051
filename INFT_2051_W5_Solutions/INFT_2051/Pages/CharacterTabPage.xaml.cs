using INFT_2051.Models;

namespace INFT2051.Pages;


public partial class CharacterTabPage : TabbedPage
{
	CharacterModel model;
	public CharacterTabPage(CharacterModel m)
	{
		model = m;
		BindingContext = model;

		InitializeComponent();
	}
}