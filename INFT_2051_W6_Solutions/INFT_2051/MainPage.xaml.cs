using INFT_2051.Pages;
using INFT2051.Pages;

namespace INFT_2051;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void CharacterButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CharacterSelectPage());
    }

    private bool _isCheckingLocation = false;
    private CancellationTokenSource _cancelTokenSource;
    private async void GeoButton_Clicked(object sender, EventArgs e)
    {
        if (_isCheckingLocation)
            return;
        try
        {
            PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Warning", "Do not have permission to get geolocation", "OK");
                return;
            }

            _isCheckingLocation = true;
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
                await DisplayAlert("Got Geolocation", String.Format("Longitude: {0}{1}Latitude: {2}", location.Longitude, Environment.NewLine, location.Latitude), "OK");
        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }
}

