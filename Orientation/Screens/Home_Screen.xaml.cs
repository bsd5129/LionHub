using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Home_Screen : ContentPage
	{
		
		public Home_Screen ()
		{
			InitializeComponent ();

			//NavigationPage.SetHasNavigationBar (this, false);
			NavigationPage.SetBackButtonTitle (this, "Back");

			psuLogo.WidthRequest = (int)(0.75 * ((Orientation.App)App.Current).getScreenSize().Width);

			grid.Children.Add (new HomeListItem (this, "Services", "services"), 0, 0);
			grid.Children.Add (new HomeListItem (this, "Favorites", "favorite"), 0, 1);
			grid.Children.Add (new HomeListItem (this, "Rooms", "rooms"), 0, 2);
			grid.Children.Add (new HomeListItem (this, "Scavenger Hunt", "scavengerHunt"), 0, 3);
			grid.Children.Add (new HomeListItem (this, "Events", "events"), 0, 4);
			grid.Children.Add (new HomeListItem (this, "Where Am I?", "whereAmI"), 0, 5);
			grid.Children.Add (new HomeListItem (this, "Settings", "settings"), 0, 6);

			setTheme ();
		}

		public void pressHomeListItem(string name)
		{
			switch (name) {
			case "Services":
				pressServicesHomeListItem ();
				break;
			case "Favorites":
				pressFavoritesHomeListItem ();
				break;
			case "Rooms":
				pressRoomHomeListItem ();
				break;
			case "Scavenger Hunt":
				pressScavengerHuntHomeListItem ();
				break;
			case "Events":
				pressEventsHomeListItem ();
				break;
			case "Where Am I?":
				pressWhereAmIHomeListItem ();
				break;
			case "Settings":
				pressSettingsHomeListItem ();
				break;
			}
		}

		public void pressServicesHomeListItem()
		{
			Navigation.PushAsync (new Service_Search_Screen());
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
	}
}

