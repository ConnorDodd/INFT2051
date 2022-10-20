using INFT_2051.Models;
using INFT_2051.Services;
using INFT_2051.ViewModels;
using Newtonsoft.Json;

namespace INFT_2051.Pages;

public partial class NamePage : ContentPage
{
    public string[] ClassNames { get; set; }

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

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        var model = (CharacterModel)Parent.BindingContext;
        if (model.Name == null || model.Name.Length < 1)
        {
            await DisplayAlert("Warning", "You must enter a name before saving a character", "OK");
            return;
        }
        CharacterViewModel.Current.SaveCharacter(model);

        await Navigation.PopAsync();
    }


    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Confirm Delete", "Are you sure you want to delete this character? This cannot be undone.", "Yes", "No") != true)
            return;
        var model = (CharacterModel)Parent.BindingContext;
        CharacterViewModel.Current.DeleteCharacter(model);

        await Navigation.PopAsync();
    }

    private async void LoadImage(object sender, EventArgs e)
    {
        FileResult photo = null;

        if (MediaPicker.Default.IsCaptureSupported && DeviceInfo.Platform != DevicePlatform.WinUI)
        {
            PermissionStatus status = await GetCameraPermission();
            if (status == PermissionStatus.Granted)
            {
                photo = await MediaPicker.CapturePhotoAsync();
            }
        }
        else
        {
            PermissionStatus status = await GetMediaPermission();
            if (status == PermissionStatus.Granted)
            {
                photo = await MediaPicker.PickPhotoAsync();
            }
        }

        if (photo != null)
        {
            //Check if images folder exists
            string imagesDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "images");
            System.IO.Directory.CreateDirectory(imagesDir);

            var newFile = Path.Combine(imagesDir, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            {
                await stream.CopyToAsync(newStream);
            }

            var model = (CharacterModel)Parent.BindingContext;
            model.ImageFilePath = newFile;
            model.OnPropertyChanged("ImageFilePath");
        }
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