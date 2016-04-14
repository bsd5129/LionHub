using System;
using Xamarin.Forms;
using SQLite.Net;
namespace Orientation {
  public class DbData {

    public static void initializeDatabaseData(long dbVersion) {
      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();

      try {
        con.CreateTable<Event>();
      } catch (Exception ex) {

      }

      try {
        con.CreateTable<Info>();
        con.Insert(new Info("dbVersion", dbVersion));
        long nowInMillis = (long)DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        con.Insert(new Info("dbTimestamp", nowInMillis));
        con.Insert(new Info("eventCacheTime", 0));
      } catch (Exception ex) {

      }

      con.Close();
    }
  }
}

