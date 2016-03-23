using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Event_Results_Screen : ContentPage
	{
		public Event_Results_Screen ()
		{
			InitializeComponent ();
			setTheme();
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

