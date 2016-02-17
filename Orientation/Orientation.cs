using System;

using Xamarin.Forms;

namespace Orientation
{
	public class App : Application
	{
		public App ()
		{
			//new NavigationPage(new Service_Results_Screen ());
			MainPage = new NavigationPage(new Home_Screen ());
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
	}
}

