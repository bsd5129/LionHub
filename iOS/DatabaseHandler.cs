using System;
using System.IO;
using SQLite.Net;
[assembly: Xamarin.Forms.Dependency (typeof (Orientation.iOS.DatabaseHandler))]
namespace Orientation.iOS {
  public class DatabaseHandler : IDatabaseHandler {
    public DatabaseHandler() {
    }

    public SQLiteConnection getDBConnection() {
      string libraryPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "../Library/");
      string dbPath = Path.Combine (libraryPath, "LionHub.db");
      return new SQLiteConnection(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), dbPath);
    }
  }
}

