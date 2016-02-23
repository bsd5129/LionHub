using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Event_Search_Screen : ContentPage
	{
		public Event_Search_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, true);

			//show_results.Content = results;
			//thickness = new Thickness(10, Device.OnPlatform (20, 0, 0), 10, 5);
			event_picker_month.Title = "Event Date";
			event_picker_month.Items.Add("January");
			event_picker_month.Items.Add("Febuary");
			event_picker_month.Items.Add("March");
			event_picker_month.Items.Add("April");
			event_picker_month.Items.Add("May");
			event_picker_month.Items.Add("June");
			event_picker_month.Items.Add ("July");
			event_picker_month.Items.Add ("August");
			event_picker_month.Items.Add("September");
			event_picker_month.Items.Add("October");
			event_picker_month.Items.Add("November");
			event_picker_month.Items.Add("December");

			event_picker_year.Title = "Year";
			event_picker_year.Items.Add("2016");
			event_picker_year.Items.Add("2017");

			//if (((Orientation.App)App.Current).isDarkTheme ()) {
			//	BackgroundColor = Color.FromHex ("#303030");
			//
			//}	
		}
			
	}
}

