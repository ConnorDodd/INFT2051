using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace INFT_2051;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        Intent intent = this.Intent;
        var action = intent.Action;
        var key = intent.GetStringExtra("test_key");

        return;
    }
}
