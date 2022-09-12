using INFT_2051.Models;
using INFT_2051.Services;
using Newtonsoft.Json;

namespace INFT_2051.Pages;
public partial class SpellsPage : ContentPage
{
	private string[] _spellNames;

	public SpellsPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		LoadSpells();
	}

	private async void LoadSpells()
	{
		ErrorLabel.Text = "";

        var model = (CharacterModel)Parent.BindingContext;
		var className = model.Class;

		if (className == null)
		{
			ErrorLabel.Text = "Must set a class before you can select spells";
			return;
		}

		//Creates a URL matching the format required by the API using the chosen class
		//e.g. classes/paladin/spells
        string json = await ApiService.GetJsonFromAPI("classes/" +
			className.ToLower() + "/spells");
        var response = JsonConvert.DeserializeObject<ApiSpellResponse>(json);
        string[] spellNames = new string[response.Count];
        for (int i = 0; i < response.Count; i++)
        {
            spellNames[i] = response.Results[i].Name;
        }
        _spellNames = spellNames;
    }

	private async void AddSpellButton_Clicked(object sender, EventArgs e)
	{
		if (_spellNames == null)
			return;

		var spell = await DisplayActionSheet("Select a Spell", "Cancel", null, _spellNames);
		if (spell == null || spell.Equals("Cancel"))
			return;

        var model = (CharacterModel)Parent.BindingContext;
		model.Spells.Add(new SpellModel()
		{
			Name = spell
		});
		model.OnPropertyChanged("Spells");
    }
}