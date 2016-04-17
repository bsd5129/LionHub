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
      NavigationPage.SetBackButtonTitle(this, "Search");
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

    public void pressServiceListItem(Object sender, ItemTappedEventArgs args) {
			if (args.Item != null)
			{
        if (category != null || (searchBar.Text != null && searchBar.Text.Length > 0))
          Navigation.PushAsync(new Service_Results_Screen(((ServiceCell)args.Item).service));
        else
          Navigation.PushAsync(new Service_Search_Screen(args.Item.ToString()));
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
      var services = connection.Table<ServiceData>().OrderBy(s => s.name);

      List<ServiceCell> names = new List<ServiceCell>();
			
      foreach (var service in services)
			{
        if (service.category.Equals(category))
          names.Add(new ServiceCell(service));
			}
			
      connection.Close();
      servicesList.ItemsSource = names;
		}

    public void queryListOfCategories() {
      SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var services = connection.Table<ServiceData>().OrderBy(s => s.category);

      List<ServiceCell> categories = new List<ServiceCell>();

      foreach (var service in services) {
        if (!categories.Contains(new ServiceCell(service, true)))
          categories.Add(new ServiceCell(service, true));
      }

      connection.Close();
      servicesList.ItemsSource = categories;
    }

		public void queryFilteredListOfServices(String filter)
		{
      if (filter == null || filter.Length == 0) {
        queryListOfServices();
        return;
      }

			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
     	var services = connection.Table<ServiceData>().OrderBy(s => s.name);

			List<ServiceCell> names = new List<ServiceCell>();
			
      foreach (var service in services)
			{
        if(service.name.ToLower().Contains(filter.ToLower()))
          names.Add(new ServiceCell(service));
			}

      connection.Close();
			servicesList.ItemsSource = names;
		}

	}
}

