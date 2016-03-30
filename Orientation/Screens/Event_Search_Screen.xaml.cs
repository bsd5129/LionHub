using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;


namespace Orientation
{
	public partial class Event_Search_Screen : ContentPage
	{
		public Event_Search_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, true);
			event_picker.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);

      queryMonths();

			setTheme();

			event_picker.SelectedIndexChanged += (sender, e) => queryListOfEvents();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
      event_picker.BackgroundColor = Theme.getEntryColor();
      eventsList.BackgroundColor = Theme.getBackgroundColor();
		}

    public void queryMonths() {
      SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var events = connection.Table<Event>().OrderBy(e => e.name);

      foreach (var e in events) {
        string month = numberToMonth(int.Parse(e.date.Substring(0, 2))) + " " + e.date.Substring(6);

        if (!event_picker.Items.Contains(month))
          event_picker.Items.Add(month);
      }

      connection.Close();
    }

    public string numberToMonth(int month) {
      switch (month) {
        case 1:
          return "January";
        case 2:
          return "February";
        case 3:
          return "March";
        case 4:
          return "April";
        case 5:
          return "May";
        case 6:
          return "June";
        case 7:
          return "July";
        case 8:
          return "August";
        case 9:
          return "September";
        case 10:
          return "October";
        case 11:
          return "November";
        case 12:
          return "December";
      }

      return "UNKNOWN";
    }

		public void prepareScreen()
		{
      
    }

		public void selectMonth()
		{
      
    }

		public void queryListOfEvents() 
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var events = connection.Table<Event>().OrderBy(e => e.name);

			List<string> eventNames = new List<string>();

			foreach (var e in events)
			{
        string month = numberToMonth(int.Parse(e.date.Substring(0, 2))) + " " + e.date.Substring(6);

        if (event_picker.Items[event_picker.SelectedIndex].ToString().Equals(month))
				  eventNames.Add(e.name);
			}

			connection.Close();
			eventsList.ItemsSource = eventNames;			
		}

		public void pressEventListItem(Object sender, ItemTappedEventArgs args)
		{
			if (args.Item != null)
			{
				Navigation.PushAsync(new Event_Results_Screen(queryEventData(args.Item.ToString())));
			}
		}

		public Event queryEventData(String name)
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			TableQuery<Event> query = from e in connection.Table<Event>() where e.name.Equals(name) select e;
			Event ev = query.FirstOrDefault();
			connection.Close();
			return ev;
		}

		public void showErrorMessage()
		{ }

		public void pressOkOnErrorMessage()
		{ }

			
			
	}
}

