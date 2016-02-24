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
			event_picker.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
			event_picker.Title = "Event Date";
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
			
			
	}
}

