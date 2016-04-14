using System;
using Android.App;
using SQLite.Net;
using System.IO;

[assembly: Xamarin.Forms.Dependency (typeof (Orientation.Droid.DatabaseHandler))]
namespace Orientation.Droid {
  public class DatabaseHandler : IDatabaseHandler {
    public DatabaseHandler() {
    }

    public SQLiteConnection getDBConnection() {
      //string dbPath = Application.Context.GetDatabasePath("LionHub.db").Path;
      string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "LionHub.db");
      return new SQLiteConnection(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), dbPath);
    }

    public void saveDatabase(long version, byte[] dbData) {
      string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "LionHub.db");
      File.Delete(dbPath);
      File.WriteAllBytes(dbPath, dbData);
      DbData.initializeDatabaseData(version);
    }
  }
}

