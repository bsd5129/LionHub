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
			var service = connection.Table<Service>();
			List<string> fav = new List<string>();
			foreach (var s in service)
			{
				if(s.isFavorite)
					fav.Add(s.name);
			}
			favoritesList.ItemsSource = fav;
		}

		public void prepareScreen() 
		{
			
		}

	}
}

