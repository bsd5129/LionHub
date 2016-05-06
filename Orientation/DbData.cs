using System;
using Xamarin.Forms;
using SQLite.Net;
namespace Orientation {
  public class DbData {

    public static void initializeDatabaseData(long dbVersion) {
      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();

      try {
        con.CreateTable<Event>();
      } catch (Exception) {

      }

      try {
        con.CreateTable<Info>();
        con.Insert(new Info("dbVersion", dbVersion));
        con.Insert(new Info("theme", 0));
        long nowInMillis = (long)DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        con.Insert(new Info("dbTimestamp", nowInMillis));
        con.Insert(new Info("eventCacheTime", 0));
      } catch (Exception) {

      }


      Info theme = con.Table<Info>().Where(i => i.key.Equals("theme")).FirstOrDefault();

      if (theme == null) {
        con.Insert(new Info("theme", 0));
      } else {
        Theme.setActiveThemeId((int)theme.value);
      }

      con.Close();
    }
  }
}

