using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Event_Results_Screen : ContentPage
	{
		private Event eventObject;
		public Event_Results_Screen (Event ev)
		{
			InitializeComponent ();
			setTheme();

			name.Text = ev.name;
			description.Text = ev.description;
			date.Text = ev.date;
			time.Text = ev.time;
			location.Text = ev.location;
			coordinatorName.Text = ev.coordinatorName;
			coordinatorPhone.Text = ev.coordinatorPhoneNumber;
			miscInfo.Text = ev.miscInfo;

		}

		public void setTheme()
		{
      BackgroundColor = Theme.getBackgroundColor();
			name.TextColor = Theme.getTextColor();
			description.TextColor = Theme.getTextColor();
			date.TextColor = Theme.getTextColor();
			time.TextColor = Theme.getTextColor();
			location.TextColor = Theme.getTextColor();
			coordinatorName.TextColor = Theme.getTextColor();
			coordinatorPhone.TextColor = Theme.getTextColor();
			miscInfo.TextColor = Theme.getTextColor();
		}
	}
}

