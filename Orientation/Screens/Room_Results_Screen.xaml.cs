using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Room_Results_Screen : ContentPage
	{
		public Room roomObj;
		public Room_Results_Screen (Room room)
		{
			InitializeComponent ();
			setTheme();
			roomObj = room;
			roomNumber.Text = roomObj.roomNumber;
			buildingName.Text = roomObj.buildingName;
			description.Text = roomObj.description;
			directions.Text = roomObj.directions;
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

