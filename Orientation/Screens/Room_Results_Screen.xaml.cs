using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Room_Results_Screen : ContentPage
	{
		public Room_Results_Screen (RoomData room)
		{
			InitializeComponent ();
			setTheme();
      roomNumber.Text = room.roomNumber;
			buildingName.Text = room.buildingName;
			description.Text = room.description;
			directions.Text = room.directions;
		}

		public void setTheme()
		{
			stackLayout.BackgroundColor = Theme.getBackgroundColor();
			buildingName.TextColor = Theme.getTextColor();
			description.TextColor = Theme.getTextColor();
			directions.TextColor = Theme.getTextColor();
		}
	}
}

