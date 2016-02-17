using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Orientation
{
	public partial class TabMenu : ContentView
	{
		private static TabMenu instance;
		private MenuButton selected;

		private static ContentPage homeScreen, serviceSearchScreen, favoritesScreen, serviceResultsScreen, whereAmIScreen;

		private TabMenu ()
		{
			instance = this;

			if (homeScreen == null)
				homeScreen = new Home_Screen ();

			if (serviceSearchScreen == null)
				serviceSearchScreen = new Service_Search_Screen ();

			if (favoritesScreen == null)
				favoritesScreen = new Favorites_Screen ();

			if (serviceResultsScreen == null)
				serviceResultsScreen = new Service_Results_Screen ();

			if (whereAmIScreen == null)
				whereAmIScreen = new Where_Am_I_Screen ();

			InitializeComponent ();
			grid.Children.Add (new MenuButton(this, "Home", "home", homeScreen), 0, 0);
			grid.Children.Add (new MenuButton(this, "Services", "services", serviceSearchScreen), 1, 0);
			grid.Children.Add (new MenuButton(this, "Favorites", "favorite", favoritesScreen), 2, 0);
			grid.Children.Add (new MenuButton(this, "Rooms", "rooms", serviceResultsScreen), 3, 0);
			grid.Children.Add (new MenuButton(this, "Scavenger", "scavengerHunt", whereAmIScreen), 4, 0);

			setSelected ((MenuButton)grid.Children [1]);
		}

		public void setSelected(MenuButton menuButton)
		{
			if (selected != null && selected == menuButton)
				return;

			if (selected != null)
				selected.setSelected (false);

			menuButton.setSelected (true);
			selected = menuButton;
		}

		public static TabMenu getInstance()
		{
			if (instance != null)
				return instance;

			return new TabMenu ();
		}
	}
}

