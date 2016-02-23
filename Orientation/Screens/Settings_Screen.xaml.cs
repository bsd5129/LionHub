using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Settings_Screen : ContentPage
	{
		public Settings_Screen ()
		{
			InitializeComponent ();
			darkThemeSwitch.IsToggled = Theme.isDarkTheme ();

			darkThemeSwitch.Toggled += async (object sender, ToggledEventArgs e) => {
				Theme.setDarkTheme(darkThemeSwitch.IsToggled);

				await ((NavigationPage)App.Current.MainPage).PopAsync();

				((NavigationPage)App.Current.MainPage).CurrentPage.ForceLayout();
				NavigationPage page = new NavigationPage(new Home_Screen());
				//page.PushAsync(new Settings_Screen());
				((Orientation.App)App.Current).setMainPage(page);
			};

			setTheme();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor ();
			tableView.BackgroundColor = Theme.getBackgroundColor ();

			darkThemeText.TextColor = Theme.getTextColor ();
			darkThemeDetail.TextColor = Theme.getTextColor ();
			darkThemeSwitch.BackgroundColor = Theme.getBackgroundColor ();

			version.TextColor = Theme.getTextColor ();
			version.DetailColor = Theme.getTextColor ();

			credits.TextColor = Theme.getTextColor ();
			credits.DetailColor = Theme.getTextColor ();
		}
	}
}

