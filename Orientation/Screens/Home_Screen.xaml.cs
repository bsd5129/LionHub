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

			grid.Children.Add (new HomeListItem (this, "Services", "services.png"), 0, 0);
			grid.Children.Add (new HomeListItem (this, "Favorites", "favorite.png"), 0, 1);
			grid.Children.Add (new HomeListItem (this, "Rooms", "rooms.png"), 0, 2);
			grid.Children.Add (new HomeListItem (this, "Scavenger Hunt", "scavengerHunt.png"), 0, 3);
			grid.Children.Add (new HomeListItem (this, "Events", "events.png"), 0, 4);
			grid.Children.Add (new HomeListItem (this, "Where Am I?", "whereAmI.png"), 0, 5);
			grid.Children.Add (new HomeListItem (this, "Settings", "settings.png"), 0, 6);
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
			
		}

		public void pressWhereAmIHomeListItem()
		{
			Navigation.PushAsync (new Where_Am_I_Screen());
		}

		public void pressSettingsHomeListItem()
		{

		}
	}
}

