using System;
using System.Text.RegularExpressions;
using SQLite.Net;

using Xamarin.Forms;

namespace Orientation {
  public partial class Room_Search_Screen : ContentPage {
		public Room_Search_Screen()
		{
			InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
			NavigationPage.SetBackButtonTitle(this, "Search");
			bottomLayout.Children.Add(new TabMenu(3));

			roomNumber.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
			buildingName.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);

			queryBuildings();

			setTheme();
		}

    public void setTheme() {
      stackLayout.BackgroundColor = Theme.getBackgroundColor();
      roomNumber.BackgroundColor = Theme.getEntryColor();
      roomNumber.PlaceholderColor = Theme.getEntryPlaceholderColor();
      buildingName.BackgroundColor = Theme.getEntryColor();
    }

    public void queryBuildings() {
      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var rooms = con.Table<Room>().OrderBy(r => r.buildingName);

      foreach (Room r in rooms) {
        if (!buildingName.Items.Contains(r.buildingName))
          buildingName.Items.Add(r.buildingName);
      }

      con.Close();
    }

    public void pressSearch(object sender, EventArgs args) {
      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var rooms = con.Table<Room>();
	    String building = "";
	  
	    if(buildingName.SelectedIndex > -1)
	  	  building = buildingName.Items[buildingName.SelectedIndex];
 	  
  	  String number = roomNumber.Text;
  	  if(number != null)
  		number.ToUpper().Replace("-", "").Replace(" ", "");
        
  	  Room room = null;

      foreach (Room r in rooms) {
        if (r.buildingName.Equals(building) && r.roomNumber.ToLower().Trim().Equals(number.ToLower().Trim())) {
          room = r;
          break;
        }
      }

      if (room == null) {
        foreach (Room r in rooms) {
          if (r.buildingName.Equals(building) && r.roomNumber.ToLower().Trim().Contains(number.ToLower().Trim())) {
            room = r;
            break;
          }
        }
      }

      con.Close();

      if (room != null)
      {
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

        ((NavigationPage)App.Current.MainPage).PushAsync(new Room_Results_Screen(room));
      }
      else
        showErrorMessage();
    }

    public async void showErrorMessage() {
      await DisplayAlert("Sorry", "That room could not be found", "OK");
    }
  }
}

