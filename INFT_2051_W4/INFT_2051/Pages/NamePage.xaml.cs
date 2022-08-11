using INFT_2051.Models;

namespace INFT2051.Pages;

public partial class NamePage : ContentPage
{
	public NamePage()
	{
        InitializeComponent();
	}

    private void HPStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var model = (CharacterModel)Parent.BindingContext;
        model.OnPropertyChanged("HPPercent");
        model.OnPropertyChanged("HPCurrent");
    }
}