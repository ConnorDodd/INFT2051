using INFT_2051.Models;
using INFT2051.Pages;

namespace INFT_2051.Pages;

public partial class CharacterSelectPage : ContentPage
{
    public List<CharacterModel> Characters { get; set; }

    public CharacterSelectPage()
	{
        Characters = new List<CharacterModel>();
        Characters.Add(new CharacterModel()
        {
            Name = "Character 1",
            HPTotal = 15,
            HPCurrent = 10,
            StatDexterity = 6,
            StatIntelligence = 8,
            TraitIdeals = "Lorem Ipsum is simply dummy text"
        });
        Characters.Add(new CharacterModel()
        {
            Name = "Character 2",
            HPTotal = 15,
            HPCurrent = 10,
            StatDexterity = 6,
            StatIntelligence = 8,
            TraitIdeals = "Lorem Ipsum is simply dummy text"
        });
        Characters.Add(new CharacterModel()
        {
            Name = "Character 3",
            HPTotal = 15,
            HPCurrent = 10,
            StatDexterity = 6,
            StatIntelligence = 8,
            TraitIdeals = "Lorem Ipsum is simply dummy text"
        });

        BindingContext = this;

        InitializeComponent();
	}

    private void CharacterSelectListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        CharacterModel tapped = (CharacterModel)e.Item;
        Navigation.PushAsync(new CharacterTabPage(tapped));
    }
}