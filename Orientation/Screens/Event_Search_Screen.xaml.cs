using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;

namespace Orientation
{
  
	public partial class Event_Search_Screen : ContentPage
	{
		public Event_Search_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, true);
      NavigationPage.SetBackButtonTitle(this, "Back");
      event_picker.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
      event_picker.SelectedIndexChanged += (sender, e) => queryListOfEvents();
      Device.StartTimer(TimeSpan.FromMilliseconds(250), updateData);
      setTheme();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
      event_picker.BackgroundColor = Theme.getEntryColor();
      eventsList.BackgroundColor = Theme.getBackgroundColor();
		}

    public bool updateData() {
      SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      Info cacheInfo = connection.Table<Info>().Where(i => i.key.Equals("eventCacheTime")).FirstOrDefault();
      long lastCacheTime = cacheInfo.value;
      long currentTime = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;

      if (currentTime - lastCacheTime > 1000 * 60 * 60 * 6) {
        string html;

        Task<string> task = new HttpClient().GetStringAsync(new Uri("http://harrisburg.psu.edu/calendar"));
        task.Wait();
        html = task.Result;

        for (int i = 1; i < 9; i++) {
          Task<string> task2 = new HttpClient().GetStringAsync(new Uri("http://harrisburg.psu.edu/calendar?page=" + i));
          task2.Wait();
          html += task2.Result;
        }

        string regex = @"views-row-\d.*?<span class=""date-display-start""><span>(\w{3})\s(\d{4}).*?<\/time>\s*(<span class=""separator"">.*?<div class=""clr""><\/div>|<div class=""clr""><\/div>)<\/span>.*?<span class=""field-content""><a href=""([\/\w\d\-]*)"">(.*?)<\/a><\/span>";

        List<Event> events = new List<Event>();
        MatchCollection matches = Regex.Matches(html, regex, RegexOptions.Singleline);

        foreach (Match m in matches) {
          Event e = new Event(System.Net.WebUtility.HtmlDecode(m.Groups[5].Value), m.Groups[1].Value, m.Groups[2].Value, "http://harrisburg.psu.edu" + m.Groups[4].Value);

          if (!events.Contains(e))
            events.Add(e);
        }

        connection.BeginTransaction();
        connection.DeleteAll<Event>();

        foreach (Event e in events) {
          connection.Insert(e);
        }

        cacheInfo.value = currentTime; //Not entirely accurate, but will work alright
        connection.Update(cacheInfo);
        connection.Commit();
        connection.Close();
        updateData();

      } else if (event_picker.Items.Count == 0) {

        var eventEntries = connection.Table<Event>();

        event_picker.Items.Clear();

        foreach (var e in eventEntries) {
          string month = e.month + " " + e.year;

          if (!event_picker.Items.Contains(month))
            event_picker.Items.Add(month);
        }

        connection.Close();

        string now = numberToMonth(DateTime.Now.Month) + " " + DateTime.Now.Year;

        for (int i = 0; i < event_picker.Items.Count; i++) {
          if (event_picker.Items[i].Equals(now)) {
            event_picker.SelectedIndex = i;
            break;
          }
        }

        if (event_picker.SelectedIndex == -1 && event_picker.Items.Count > 0)
          event_picker.SelectedIndex = 0;
      }

      return false;
    }

    public string numberToMonth(int month) {
      switch (month) {
        case 1:
          return "Jan";
        case 2:
          return "Feb";
        case 3:
          return "Mar";
        case 4:
          return "Apr";
        case 5:
          return "May";
        case 6:
          return "Jun";
        case 7:
          return "Jul";
        case 8:
          return "Aug";
        case 9:
          return "Sep";
        case 10:
          return "Oct";
        case 11:
          return "Nov";
        case 12:
          return "Dec";
      }

      return "UNKNOWN";
    }

		public void queryListOfEvents() 
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var events = connection.Table<Event>().OrderBy(e => e.name);

			List<EventCell> eventNames = new List<EventCell>();

			foreach (var e in events)
			{
        if (event_picker.Items[event_picker.SelectedIndex].Equals(e.month + " " + e.year))
          eventNames.Add(new EventCell(e));
			}

			connection.Close();
			eventsList.ItemsSource = eventNames;

      if (eventNames.Count == 0)
        showErrorMessage();
		}

		public void pressEventListItem(Object sender, ItemTappedEventArgs args)
		{
      if (args.Item != null)
			{
        Navigation.PushAsync(new Web_Screen(((EventCell)args.Item).evnt.name, ((EventCell)args.Item).evnt.link));
      }
		}

		public void showErrorMessage()
		{
      DisplayAlert("No Events", "We could not find any events from the PSU calendar. Please try again later.", "OK");
      pressOkOnErrorMessage();
    }

		public void pressOkOnErrorMessage()
		{
      Navigation.PopAsync();
    }
			
	}
}

