using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SQLite.Net;
using System.Net.Http;
using System.Threading;

namespace Orientation
{
	public partial class Home_Screen : ContentPage
	{
		
		public Home_Screen()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "Back");

      //Adjust the psu logo ratio based on a fraction on the screen width
			psuLogo.WidthRequest = (int)(0.75 * ((Orientation.App)App.Current).getScreenSize().Width);

      //Add the home screen main buttons
			grid.Children.Add (new HomeListItem (this, "Services", "services"), 0, 0);
			grid.Children.Add (new HomeListItem (this, "Favorites", "favorite"), 0, 1);
			grid.Children.Add (new HomeListItem (this, "Rooms", "rooms"), 0, 2);
			grid.Children.Add (new HomeListItem (this, "Scavenger Hunt", "scavengerHunt"), 0, 3);
			grid.Children.Add (new HomeListItem (this, "Events", "events"), 0, 4);
			grid.Children.Add (new HomeListItem (this, "Where Am I?", "whereAmI"), 0, 5);
			grid.Children.Add (new HomeListItem (this, "Settings", "settings"), 0, 6);

			setTheme();

      //Query the database for the last update timestamp and the current database version
      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      long dbVersion = con.Table<Info>().Where(i => i.key.Equals("dbVersion")).FirstOrDefault().value;
      con.Close();

      //Check for a db update
      checkForDbUpdate(dbVersion, false);
		}

		public void pressHomeListItem(string name)
		{
			switch (name) {
			case "Services":
				pressServicesHomeListItem();
				break;
			case "Favorites":
				pressFavoritesHomeListItem();
				break;
			case "Rooms":
				pressRoomHomeListItem();
				break;
			case "Scavenger Hunt":
				pressScavengerHuntHomeListItem();
				break;
			case "Events":
				pressEventsHomeListItem();
				break;
			case "Where Am I?":
				pressWhereAmIHomeListItem();
				break;
			case "Settings":
				pressSettingsHomeListItem();
				break;
			}
		}

		public void pressServicesHomeListItem()
		{
			Navigation.PushAsync (new Service_Search_Screen(null));
		}

		public void pressFavoritesHomeListItem()
		{
			Navigation.PushAsync (new Favorites_Screen());
		}

		public void pressRoomHomeListItem()
		{
			Navigation.PushAsync (new Room_Search_Screen ());
		}

		public void pressScavengerHuntHomeListItem()
		{
			Navigation.PushAsync (new Scavenger_Hunt_Screen ());
		}

		public void pressEventsHomeListItem()
		{
			Navigation.PushAsync (new Event_Search_Screen ());
		}

		public void pressWhereAmIHomeListItem()
		{
			Navigation.PushAsync (new Where_Am_I_Screen());
		}

		public void pressSettingsHomeListItem()
		{
			Navigation.PushAsync (new Settings_Screen());
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			stackLayout.BackgroundColor = Theme.getBackgroundColor();
			grid.BackgroundColor = Theme.getBackgroundColor();
			copyright.TextColor = Theme.getTextColor();
			copyright.BackgroundColor = Theme.getBackgroundColor ();
		}

    public async void checkForDbUpdate(long version, bool displayResult)
    {
      long latestVersion = version;

      try {
        string str = await new HttpClient().GetStringAsync(new Uri("https://drive.google.com/uc?export=download&id=0BxEFbSUhqF_6Wk1XX1plWjQ2cDQ"));
        latestVersion = long.Parse(str);
      } catch (Exception) {
        if (displayResult)
          await DisplayAlert("Failed to Update", "There was an issue determining the latest version from the server. Please try again later.", "OK");
      }

      if (latestVersion != version) {
        if (await DisplayAlert("Update Available", "The information database has an update available. Would you like to update?", "Update", "Cancel")) {
          try {
            byte[] db = await new HttpClient().GetByteArrayAsync(new Uri("https://drive.google.com/uc?export=download&id=0BxEFbSUhqF_6X2ZVQWhybVlkLXc"));
            DependencyService.Get<IDatabaseHandler>().saveDatabase(latestVersion, db);
            await DisplayAlert("Update Complete!", "The information database has been updated to version " + latestVersion + "!", "Close");
          } catch (Exception) {
            await DisplayAlert("Failed to Update", "There was an issue downloading the update from the server. Please try again later.", "OK");
          }
        }
      } else if (displayResult) {
        await DisplayAlert("No Update Available", "You have the latest version of the database.", "Close");
      }
    }
	}
}

