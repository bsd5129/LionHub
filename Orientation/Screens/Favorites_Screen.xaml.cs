using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace Orientation
{
	public partial class Favorites_Screen : ContentPage
	{
    List<FavoriteCell> favorites;

    public Favorites_Screen()
		{
			InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
			bottomLayout.Children.Add(new TabMenu(2));
			setTheme();
      queryFavorites();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			favoritesList.BackgroundColor = Theme.getBackgroundColor();
		}

		public void queryFavorites()
		{
      favorites = new List<FavoriteCell>();

			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var services = connection.Table<Service>();

			foreach (var service in services)
			{
				if (service.isFavorite)
          favorites.Add(new FavoriteCell(service));
			}

      connection.Close();

      favoritesList.ItemsSource = favorites;
		}//end query favorites


		public void prepareScreen()
		{

		}

		public void pressFavoriteListItem(Object sender, ItemTappedEventArgs args)
		{
			if (args.Item != null)
			{
				Navigation.PushAsync(new Service_Results_Screen(queryServiceData(args.Item.ToString())));
			}
		}


		public Service queryServiceData(string name)
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			TableQuery<Service> query = from s in connection.Table<Service>() where s.name.Equals(name) select s;
			Service service = query.FirstOrDefault();
			connection.Close();
			return service;
		}

    public async void OnDelete(object sender, EventArgs e) {
      MenuItem button = (MenuItem)sender;
      FavoriteCell favorite = null;

      foreach (FavoriteCell cell in favorites)
        if (cell.Title.Equals(button.CommandParameter))
          favorite = cell;

      if (await DisplayAlert("Delete Favorite", "Do you want to delete this favorite?", "Yes", "No")) {
        Service service = favorite.service;
        service.isFavorite = false;

        SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
        connection.Update(service);
        connection.Close();

        queryFavorites();
      }
    }
	}
}

