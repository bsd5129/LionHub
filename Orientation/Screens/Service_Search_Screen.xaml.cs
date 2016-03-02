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
			if (searchBar.Text == null || searchBar.Text.Length == 0)
				queryListOfServices();

			searchBar.TextChanged += (object sender, TextChangedEventArgs e) =>
			{
				queryFilteredListOfServices(searchBar.Text);
			};

			servicesList.ItemSelected += (Object sender, SelectedItemChangedEventArgs sel) =>
			{
				if (sel.SelectedItem != null)
				{
					servicesList.SelectedItem = null;
					Navigation.PushAsync(new Service_Results_Screen("","","","","",true));
				}
			};
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			servicesList.BackgroundColor = Theme.getBackgroundColor();
			searchBar.BackgroundColor = Theme.getBackgroundColor();
		}

		public void queryListOfServices()
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var service = connection.Table<Service>();
			List<string> names = new List<string>();
			foreach (var s in service)
			{
				names.Add(s.name);
			}
			servicesList.ItemsSource = names;
		}

		public void queryFilteredListOfServices(String filter)
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var service = connection.Table<Service>();
			List<string> names = new List<string>();
			foreach (var s in service)
			{
				if(filter.Contains(s.name))
					names.Add(s.name);
			}
			servicesList.ItemsSource = names;
		}

	}
}

