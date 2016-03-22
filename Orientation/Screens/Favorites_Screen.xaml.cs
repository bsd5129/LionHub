using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace Orientation
{
	public partial class Favorites_Screen : ContentPage

	{
		List<string> favs = new List<string>();
		String itemSelected;
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
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var services = connection.Table<Service>();



			foreach (var service in services)
			{
				if (service.isFavorite)
					favs.Add(service.name);
			}

			connection.Close();


			//if (favs.Count > 0)
			//	favoritesList.ItemsSource = favs; causes to get System.NullReferenceException error, need to be fixed, not sure how

		}

		public void prepareScreen()
		{

		}
		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);


			itemSelected = ListView.SelectedItemProperty.PropertyName.ToString();

			var answer =  DisplayAlert("Delete Selected Item", "Do you want to delete?", "Yes", "No");



		}

		public void pressNoOnPrompt()
		{

		}

		public void pressYesOnPrompt()
		{
			favs.Remove(itemSelected);//remove the selected one
		}



	}//


}

