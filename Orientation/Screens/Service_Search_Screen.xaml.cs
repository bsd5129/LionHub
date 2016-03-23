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
		}

    public Service getServiceData(string name) {
      SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      TableQuery<Service> query = from s in connection.Table<Service>() where s.name.Equals(name) select s;
      Service service = query.FirstOrDefault();
      connection.Close();
      return service;
    }

    public void pressServiceListItem(Object sender, ItemTappedEventArgs args) {
			if (args.Item != null)
			{
        Navigation.PushAsync(new Service_Results_Screen(getServiceData(args.Item.ToString())));
			}
		}

		public void enterTextIntoSearchBar(Object sender, TextChangedEventArgs e) {
			queryFilteredListOfServices(searchBar.Text);
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
      		var services = connection.Table<Service>().OrderBy(s => s.name);

			List<string> names = new List<string>();
			
      		foreach (var service in services)
			{
				names.Add(service.name);
			}
			
      		connection.Close();
      		servicesList.ItemsSource = names;
		}

		public void queryFilteredListOfServices(String filter)
		{
     		 if (filter == null) {
        		queryListOfServices();
        	 	return;
      		}

			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
     		 var services = connection.Table<Service>().OrderBy(s => s.name);

			List<string> names = new List<string>();
			
      		foreach (var service in services)
			{
        		if(service.name.ToLower().Contains(filter.ToLower()))
					names.Add(service.name);
			}

      		connection.Close();
			servicesList.ItemsSource = names;
		}

	}
}

