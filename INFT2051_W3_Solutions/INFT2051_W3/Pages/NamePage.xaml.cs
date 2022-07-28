namespace INFT2051_W3.Pages;

using INFT2051_W3.Models;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

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