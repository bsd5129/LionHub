using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace Orientation
{
	public partial class Favorites_Screen : ContentPage

	{
		List<string> favs = new List<string>();
		public Favorites_Screen()
		{
			InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
			bottomLayout.Children.Add(new TabMenu(2));

			setTheme();
			queryFavorites();
			deleteFavorite();
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



			foreach (var service in services)
			{
				if (service.isFavorite)
					favs.Add(service.name);
			}

			connection.Close();

			if (favs.Count > 0)
				favoritesList.ItemsSource = favs;
		}

		public void prepareScreen()
		{

		}
		public void deleteFavorite()
		{

			var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
			deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
			deleteAction.Clicked += async (sender, e) =>
			{
				var mi = ((MenuItem)sender);
				favs.Remove(mi.Text);
			};
			// add to the ViewCell's ContextActions property
			ListView.Add(deleteAction);

		}
	}
}

