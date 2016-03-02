using System;
using Xamarin.Forms;
using SQLite.Net;
namespace Orientation {
  public class DbData {

    public static void initializeDatabaseData() {
      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();

      con.CreateTable<Service>();

      string[] names = { };
      string[] descriptions = {  };
      float[] coordsLat = {  };
      float[] coordsLong = {  };
      string[] phoneNumbers = {  };
      string[] websites = {  };

      for (int i = 0; i < names.Length; i++) {
        Service serv = new Service();
        serv.name = names[i];
        serv.description = descriptions[i];
        serv.coordinatesLatitude = coordsLat[i];
        serv.coordinatesLongitude = coordsLong[i];
        serv.phoneNumber = phoneNumbers[i];
        serv.website = websites[i];
        serv.isFavorite = false;
        con.Insert(serv);
      }
    }

  }
}

