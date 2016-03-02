using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Search_Screen : ContentPage
	{
		public Service_Search_Screen()
		{
			InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
			bottomLayout.Children.Add(new TabMenu(1));

			setTheme();

			searchBar.TextChanged += (object sender, TextChangedEventArgs e) =>
			{
				onClick();
			};

			servicesList.ItemSelected += (Object sender, SelectedItemChangedEventArgs sel) =>
			{
				if (sel.SelectedItem != null)
				{
					servicesList.SelectedItem = null;
					this.Navigation.PushAsync(new Service_Results_Screen());
				}
			};
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			servicesList.BackgroundColor = Theme.getBackgroundColor();
			searchBar.BackgroundColor = Theme.getBackgroundColor();
		}

		public void onClick()
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var service = connection.Table<Service>();
			List<string> names = new List<string>();
			foreach (var s in service)
				names.Add(s.name);

			servicesList.ItemsSource = names;
		}

	}
}

