using System;

using Xamarin.Forms;

namespace Orientation
{
	public class App : Application
	{
		private Size screenSize;

		public App (Size size)
		{
			screenSize = size;
			setMainPage(new NavigationPage (new Home_Screen ()));
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

		public void setMainPage(NavigationPage page)
		{
			if (!Theme.isDarkTheme()) {
				page.BarBackgroundColor = Color.FromHex ("#EEEEEE");
			} else {
				page.BarBackgroundColor = Color.FromHex ("#303030");
				page.BarTextColor = Color.FromHex ("#BBBBBB");
			}

			MainPage = page;
		}

		public Size getScreenSize()
		{
			return screenSize;
		}
	}
}

