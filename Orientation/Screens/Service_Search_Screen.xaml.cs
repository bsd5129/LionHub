using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Search_Screen : ContentPage
	{
    private string category;

		public Service_Search_Screen(string category)
		{
			InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
			bottomLayout.Children.Add(new TabMenu(1));

      this.category = category;

			setTheme();

      if (category == null) {
        queryListOfCategories();
      } else {
        queryListOfServices();
      }
		}

    public string getCategory() {
      return category;
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
        if (category != null || (searchBar.Text != null && searchBar.Text.Length > 0))
          Navigation.PushAsync(new Service_Results_Screen(getServiceData(args.Item.ToString())));
        else
          Navigation.PushAsync(new Service_Search_Screen(args.Item.ToString()));
			}
		}

		public void enterTextIntoSearchBar(Object sender, TextChangedEventArgs e) {
			queryFilteredServices(searchBar.Text);
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
        if (service.category.Equals(category))
				  names.Add(service.name);
			}
			
      connection.Close();
      servicesList.ItemsSource = names;
		}

    public void queryListOfCategories() {
      SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var services = connection.Table<Service>().OrderBy(s => s.category);

      List<string> categories = new List<string>();

      foreach (var service in services) {
        if (!categories.Contains(service.category))
          categories.Add(service.category);
      }

      connection.Close();
      servicesList.ItemsSource = categories;
    }

		public void queryFilteredServices(String filter)
		{
      if (filter == null || filter.Length == 0) {
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

