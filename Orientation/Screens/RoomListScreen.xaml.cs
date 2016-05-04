using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace Orientation {
  public partial class RoomListScreen : ContentPage {
    public RoomListScreen(string building) {
      InitializeComponent();

      queryRooms(building);
      setTheme();
    }

    public void setTheme() {
      BackgroundColor = Theme.getBackgroundColor();
      roomsList.BackgroundColor = Theme.getBackgroundColor();
    }

    public void queryRooms(string building) {
      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var rooms = con.Table<Room>().Where(r => r.buildingName.ToLower().Equals(building.ToLower())).OrderBy(r => r.roomNumber);

      List<RoomCell> roomList = new List<RoomCell>();

      foreach (Room r in rooms) {
        roomList.Add(new RoomCell(r));
      }

      roomsList.ItemsSource = roomList;

      con.Close();
    }

    public void pressRoomListItem(object sender, ItemTappedEventArgs args) {
      if (args.Item != null) {
        ((NavigationPage)App.Current.MainPage).PushAsync(new Room_Results_Screen(((RoomCell)args.Item).room));
      }
    }
  }
}