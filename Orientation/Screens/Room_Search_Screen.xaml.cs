using System;
using System.Collections.Generic;
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

    public void pressSearchButton(object sender, EventArgs args) {
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
        if (r.buildingName.Equals(building) && r.roomNumber.Equals(number)) {
          room = r;
          break;
        }
      }

      con.Close();

      if (room != null)
        ((NavigationPage)App.Current.MainPage).PushAsync(new Room_Results_Screen(room));
      else
        displayError();
    }

    public async void displayError() {
      await DisplayAlert("Sorry", "That room could not be found", "OK");
    }
  }
}

