using System;

using Xamarin.Forms;

namespace Orientation
{
	public class App : Application
	{
		private bool isDark;

		public App ()
		{
			setDarkTheme (false);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		public bool isDarkTheme()
		{
			return isDark;
		}

		public void setDarkTheme(bool dark)
		{
			isDark = dark;
			NavigationPage navPage = new NavigationPage (new Home_Screen ());
			setNavigationTheme (navPage);
			MainPage = navPage;
		}

		public void setNavigationTheme(NavigationPage page)
		{
			if (!isDark)
				page.BarBackgroundColor = Color.FromHex ("#EEEEEE");
			else {
				page.BarBackgroundColor = Color.FromHex ("#303030");
				page.BarTextColor = Color.FromHex ("#BBBBBB");
			}
		}
	}
}

