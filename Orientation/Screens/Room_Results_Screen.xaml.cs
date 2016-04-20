using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Room_Results_Screen : ContentPage
	{
		public Room_Results_Screen (Room room)
		{
			InitializeComponent ();
			setTheme();
      roomNumber.Text = room.roomNumber;
			description.Text = room.description;
			directions.Text = room.directions;
		}

		public void setTheme()
		{
			stackLayout.BackgroundColor = Theme.getBackgroundColor();
      roomNumber.TextColor = Theme.getTextColor();
			description.TextColor = Theme.getTextColor();
			directions.TextColor = Theme.getTextColor();

      roomNumberLabel.TextColor = Theme.getTextColor();
      descriptionLabel.TextColor = Theme.getTextColor();
      directionsLabel.TextColor = Theme.getTextColor();
		}
	}
}

