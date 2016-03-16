using System;

using Xamarin.Forms;

namespace Orientation
{
	public class App : Application
	{
		private Size screenSize;

		public App (Size size)
		{
            DbData.initializeDatabaseData();
			screenSize = size;// Store the screenSize the OS passed us, so it can be used for some aspect ratio calculations later
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
      page.BarBackgroundColor = Theme.getBackgroundColor();
      page.BarTextColor = Theme.getTextColor();
			MainPage = page;
		}

		public Size getScreenSize()
		{
			return screenSize;
		}
	}
}

