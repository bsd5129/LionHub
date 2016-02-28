using System;
using Android.App;
using SQLite.Net;

[assembly: Xamarin.Forms.Dependency (typeof (Orientation.Droid.DatabaseHandler))]
namespace Orientation.Droid {
  public class DatabaseHandler : IDatabaseHandler {
    public DatabaseHandler() {
    }

    public SQLiteConnection getDBConnection() {
      string dbPath = Application.Context.GetDatabasePath("LionHub.db").Path;
      return new SQLiteConnection(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), dbPath);
    }
  }
}

