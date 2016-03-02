using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace Orientation
{
	public partial class Favorites_Screen : ContentPage
	{
		public Favorites_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasBackButton (this, false);
			bottomLayout.Children.Add (new TabMenu(2));

			setTheme ();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			favoritesList.BackgroundColor = Theme.getBackgroundColor();
		}

		public void queryFavorites()
		{ 
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var services = connection.Table<Service>();
      connection.Close();

      List<string> favs = new List<string>();
			
      foreach (var service in services)
			{
				if(service.isFavorite)
					favs.Add(service.name);
			}

			favoritesList.ItemsSource = favs;
		}

		public void prepareScreen() {
			
		}

	}
}

