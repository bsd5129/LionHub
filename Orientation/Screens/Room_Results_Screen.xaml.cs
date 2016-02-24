using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Room_Results_Screen : ContentPage
	{
		public Room_Results_Screen ()
		{
			InitializeComponent ();
			setTheme();
		}

		public void setTheme()
		{
			stackLayout.BackgroundColor = Theme.getBackgroundColor();
			roomNumber.TextColor = Theme.getTextColor();
			buildingName.TextColor = Theme.getTextColor();
			description.TextColor = Theme.getTextColor();
			directions.TextColor = Theme.getTextColor();
		}
	}
}

