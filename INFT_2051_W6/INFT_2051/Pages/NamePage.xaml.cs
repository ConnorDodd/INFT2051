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

    public async Task<PermissionStatus> GetCameraPermission()
    {
        PermissionStatus status = await Permissions.RequestAsync<Permissions.Camera>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Prompt the user to turn on in settings
            // On iOS once a permission has been denied it may not be requested again from the application
            await DisplayAlert("Warning", "You need to manually enable camera access for this app in settings.", "OK");
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.Camera>())
        {
            // Prompt the user with additional information as to why the permission is needed
            await DisplayAlert("Warning", "This app requires camera access to add photos for your character", "OK");
        }

        status = await Permissions.RequestAsync<Permissions.Camera>();

        return status;
    }

    public async Task<PermissionStatus> GetMediaPermission()
    {
        PermissionStatus status = await Permissions.RequestAsync<Permissions.StorageRead>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Prompt the user to turn on in settings
            // On iOS once a permission has been denied it may not be requested again from the application
            await DisplayAlert("Warning", "You need to manually enable camera access for this app in settings.", "OK");
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
        {
            // Prompt the user with additional information as to why the permission is needed
            await DisplayAlert("Warning", "This app requires camera access to add photos for your character", "OK");
        }

        status = await Permissions.RequestAsync<Permissions.StorageRead>();

        return status;
    }
}