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

			NavigationPage.SetHasNavigationBar (this, false);

			grid.Children.Add (new HomeListItem (this, "Services", "services"), 0, 0);
			grid.Children.Add (new HomeListItem (this, "Favorites", "favorite"), 0, 1);
			grid.Children.Add (new HomeListItem (this, "Rooms", "rooms"), 0, 2);
			grid.Children.Add (new HomeListItem (this, "Scavenger Hunt", "scavengerHunt"), 0, 3);
			grid.Children.Add (new HomeListItem (this, "Events", "events"), 0, 4);
			grid.Children.Add (new HomeListItem (this, "Where Am I?", "whereAmI"), 0, 5);
			grid.Children.Add (new HomeListItem (this, "Settings", "settings"), 0, 6);

			if (((Orientation.App)App.Current).isDarkTheme())
				setDarkTheme();
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
			
		}

		public void pressScavengerHuntHomeListItem()
		{
			
		}

		public void pressEventsHomeListItem()
		{
			((Orientation.App)App.Current).setDarkTheme (!((Orientation.App)App.Current).isDarkTheme ());
		}

		public void pressWhereAmIHomeListItem()
		{
			Navigation.PushAsync (new Where_Am_I_Screen());
		}

		public void pressSettingsHomeListItem()
		{
			Navigation.PushAsync (new Service_Results_Screen());
		}

		public void setDarkTheme()
		{
			stackLayout.BackgroundColor = Color.FromHex ("#303030");
			copyright.TextColor = Color.FromHex ("#BBBBBB");
		}
	}
}

