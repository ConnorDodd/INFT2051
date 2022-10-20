using INFT_2051.Services.PartialMethods;

namespace INFT_2051.Pages;

public partial class LoginPage : ContentPage
{
	private static string EMAIL_KEY = "email_key", PASSWORD_KEY = "password_key", REMEMBER_ME_KEY = "remember_key";

	public static string Token = null;
	public LoginPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

        EmailEntry.Text = Preferences.Default.Get<string>(EMAIL_KEY, "");
        PasswordEntry.Text = Preferences.Default.Get<string>(PASSWORD_KEY, "");
        RememberMeCheckbox.IsChecked = Preferences.Default.Get<bool>(REMEMBER_ME_KEY, false);
    }

	private async void LoginButton_Clicked(object sender, EventArgs e)
	{
		DateTime scheduleTime = DateTime.Now + new TimeSpan(0, 0, 10);
		NotificationService.SendNotification("INFT 2051", "Don't forget to log out!", scheduleTime);

		if (RememberMeCheckbox.IsChecked)
		{
            Preferences.Set(EMAIL_KEY, EmailEntry.Text);
            Preferences.Set(PASSWORD_KEY, PasswordEntry.Text);
            Preferences.Set(REMEMBER_ME_KEY, true);
        }
		else
		{
            Preferences.Default.Remove(EMAIL_KEY);
            Preferences.Default.Remove(PASSWORD_KEY);
            Preferences.Default.Remove(REMEMBER_ME_KEY);
        }

		Token = "justafaketoken";

		Animation parent = new Animation();
		Animation fade = new Animation(x => LoginButton.Opacity = x, 1, 0, Easing.CubicIn);
		Animation size = new Animation(x => LoginButton.Scale = x, 1, 0, Easing.SpringIn);

		parent.Add(0, 0.9, fade);
		parent.Add(0, 1, size);

		parent.Commit(this, "ButtonAnimation", 16, 1000, null, AnimationEnd);
	}

	private async void AnimationEnd(double x, bool y)
	{
        await Navigation.PopModalAsync();
    }
}