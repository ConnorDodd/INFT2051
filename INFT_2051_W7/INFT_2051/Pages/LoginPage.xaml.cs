namespace INFT_2051.Pages;

public partial class LoginPage : ContentPage
{
	private static string EMAIL_KEY = "email_key", PASSWORD_KEY = "password_key", REMEMBER_ME_KEY = "remember_key";

	public static string Token = null;
	public LoginPage()
	{
		InitializeComponent();
	}

	private void LoginButton_Clicked(object sender, EventArgs e)
	{
	}
}