using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Orientation
{
	public partial class Room_Results_Screen : ContentPage
	{
		public Room_Results_Screen (Room room)
		{
			InitializeComponent ();

      generateDirections(room);
      roomNumber.Text = room.roomNumber;
			description.Text = room.description;
			directions.Text = room.directions;

      setTheme();
		}

    public void generateDirections(Room room) {
      if (room.buildingName.Equals("Olmsted")) {
        if (Regex.IsMatch(room.roomNumber, "C1\\d{2}[A-Z]?")) {
          room.directions = "In the center of the 1st floor of the Olmsted Building";
        } else if (Regex.IsMatch(room.roomNumber, "C2\\d{2}[A-Z]?")) {
          room.directions = "In the center of the 2nd floor of the Olmsted Building";
        } else if (Regex.IsMatch(room.roomNumber, "C3\\d{2}[A-Z]?")) {
          room.directions = "In the center of the 3rd floor of the Olmsted Building";
        } else if (Regex.IsMatch(room.roomNumber, "C\\d{1}[A-Z]?") || Regex.IsMatch(room.roomNumber, "C\\d{2}[A-Z]?")) {
          room.directions = "On the basement level of the Olmsted Building";
        } else if (Regex.IsMatch(room.roomNumber, "E1\\d{2}[A-Z]?")) {
          room.directions = "In the east side of the 1st floor of the Olmsted Building";
        } else if (Regex.IsMatch(room.roomNumber, "E2\\d{2}[A-Z]?")) {
          room.directions = "In the east side of the 2nd floor of the Olmsted Building";
        } else if (Regex.IsMatch(room.roomNumber, "E3\\d{2}[A-Z]?")) {
          room.directions = "In the east side of the 3rd floor of the Olmsted Building";
        } else if (room.roomNumber.StartsWith("E")) {
          room.directions = "In the east side of the Olmsted Building";
        } else if (Regex.IsMatch(room.roomNumber, "W1\\d{2}[A-Z]?")) {
          room.directions = "In the west side of the 1st floor of the Olmsted Building";
        } else if (Regex.IsMatch(room.roomNumber, "W2\\d{2}[A-Z]?")) {
          room.directions = "In the west side of the 2nd floor of the Olmsted Building";
        } else if (Regex.IsMatch(room.roomNumber, "W3\\d{2}[A-Z]?")) {
          room.directions = "In the west side of the 3rd floor of the Olmsted Building";
        } else if (room.roomNumber.StartsWith("W")) {
          room.directions = "In the west side of the Olmsted Building";
        }
      } else {
        Match match = Regex.Match(room.roomNumber, "\\w*(\\d)\\d{2}\\w*");

        if (match.Success) {
          string floor = null;

          switch (match.Groups[1].Value) {
            case "1":
              floor = "1st";
              break;
            case "2":
              floor = "2nd";
              break;
            case "3":
              floor = "3rd";
              break;
          }

          if (floor != null)
            room.directions = "On the " + floor + " floor of the " + room.buildingName + " building";
          else
            room.directions = "In the " + room.buildingName + " building...";
        } else {
          room.directions = "In the " + room.buildingName + " building";
        }
      }
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

