using System;
using Xamarin.Forms;
using SQLite.Net;
namespace Orientation {
  public class DbData {

    public static void initializeDatabaseData() {
      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();

      con.DropTable<Service>();
      con.CreateTable<Service>();

      string[] names = { "Alumni Relations", "Office of Development", "Division of Undergraduate Studies Advising Center", "Faculty Senate", "Honors Program", "Human Resources",
                        "International Programs", "Marketing Research and Communication", "Office of Research and Outreach", "Campus Life and Intercultural Affairs",
                        "Angel", "Canvas", "Lynda", "Elion" };
      
      string[] descriptions = { "College and community support organization",  "N/A", "Academic information for future and current students", "Penn State University representative group",
            "Unique learning program for students with academic excellence", "Information on Jobs, Software training, Family resources, and other school related resources",
            "International Penn State study programs", "N/A", "Events, Marketing Research, News", "Student organization info and other Campus information",
            "Student classroom information, canvas alternative", "Student classroom information, angel alternative","Free service to PSU students for additional skill training",
            "Students transcript information, financial aid info, and other student services" };

      float[] coordsLat = { 40.19751166f, 40.19751166f, 40.19751166f, 40.19751166f, 40.19751166f, 40.19751166f, 40.19751166f, 40.19751166f, 40.19751166f, 40.19751166f, -999.0f, -999.0f, -999.0f, -999.0f };

      float[] coordsLong = { -76.73974655f, -76.73974655f, -76.73974655f, -76.73974655f, -76.73974655f, -76.73974655f, -76.73974655f, -76.73974655f, -76.73974655f, -76.73974655f, -999.0f, -999.0f, -999.0f, -999.0f };

      string[] phoneNumbers = { "717-948-6715", "717-948-6316", "717-948-6604", "717-948-6062", "717-948-6062", "717-948-6004", "717-948-6003", "717-948-6029", "717-948-6303", "717-948-6273", "", "", "", "" };

      string[] websites = { "https://harrisburg.psu.edu/alumni-relations", "https://harrisburg.psu.edu/philanthropy", "https://harrisburg.psu.edu/division-undergraduate-studies-advising-center",
        "https://harrisburg.psu.edu/faculty-senate", "https://harrisburg.psu.edu/honors-program", "https://harrisburg.psu.edu/human-resources", "https://harrisburg.psu.edu/international-programs",
        "https://harrisburg.psu.edu/marketing-research-and-communications", "https://harrisburg.psu.edu/research", "https://harrisburg.psu.edu/campus-life-and-intercultural-affairs",
        "https://cms.psu.edu", "https://canvas.psu.edu", "https://lynda.com", "https://elion.psu.edu" };

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

      con.Close();
    }

  }
}

