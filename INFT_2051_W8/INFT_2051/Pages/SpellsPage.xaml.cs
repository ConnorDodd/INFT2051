using INFT_2051.Models;
using INFT_2051.Services;

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

    }

	private async void AddSpellButton_Clicked(object sender, EventArgs e)
	{

    }
}