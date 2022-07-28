
using INFT2051_W3.Models;

namespace INFT2051_W3.Pages;


public partial class CharacterTabPage : TabbedPage
{
	CharacterModel model;
	public CharacterTabPage()
	{
		model = new CharacterModel()
		{
			Name = "Test",
			HPTotal = 15,
			HPCurrent = 10,
			DeathSave1 = false,
			StatDexterity = 6,
			StatIntelligence = 8,
			TraitIdeals = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
            "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
            "printer took a galley of type and scrambled it to make a type specimen book."

        };

		BindingContext = model;

		InitializeComponent();
	}
}