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
			event_picker.Title = "Choose Month";
			event_picker.Items.Add("January 2016");
			event_picker.Items.Add("Febuary 2016");
			event_picker.Items.Add("March 2016");
			event_picker.Items.Add("April 2016");
			event_picker.Items.Add("May 2016");
			event_picker.Items.Add("June 2016");
			event_picker.Items.Add ("July 2016");
			event_picker.Items.Add ("August 2016");
			event_picker.Items.Add("September 2016");
			event_picker.Items.Add("October 2016");
			event_picker.Items.Add("November 2016");
			event_picker.Items.Add("December 2016");

			setTheme();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			event_picker.BackgroundColor = Theme.getEntryColor ();
			
		}

		public void prepareScreen()
		{ }

		public void selectMonth()
		{ }

		public void queryListOfEvents() 
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var events = connection.Table<Event>().OrderBy(e => e.name);

			List<string> names = new List<string>();

			foreach (var evnt in events)
			{
				names.Add(evnt.name);
			}

			connection.Close();
			eventsList.ItemsSource = names;			
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

