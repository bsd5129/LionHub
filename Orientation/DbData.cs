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
                        "Angel", "Canvas", "Lynda", "Elion", "Olmsted Building", "Library" };
      
      string[] descriptions = { "College and community support organization",  "N/A", "Academic information for future and current students", "Penn State University representative group",
            "Unique learning program for students with academic excellence", "Information on Jobs, Software training, Family resources, and other school related resources",
            "International Penn State study programs", "N/A", "Events, Marketing Research, News", "Student organization info and other Campus information",
            "Student classroom information, canvas alternative", "Student classroom information, angel alternative","Free service to PSU students for additional skill training",
            "Students transcript information, financial aid info, and other student services", "", "" };

      float[] coordsLat = { -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, 40.205259f, 40.204228f };

      float[] coordsLon = { -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -76.742013f, -76.741195f };

      string[] phoneNumbers = { "717-948-6715", "717-948-6316", "717-948-6604", "717-948-6062", "717-948-6062", "717-948-6004", "717-948-6003", "717-948-6029", "717-948-6303", "717-948-6273", "", "", "", "", "", "" };

      string[] websites = { "https://harrisburg.psu.edu/alumni-relations", "https://harrisburg.psu.edu/philanthropy", "https://harrisburg.psu.edu/division-undergraduate-studies-advising-center",
        "https://harrisburg.psu.edu/faculty-senate", "https://harrisburg.psu.edu/honors-program", "https://harrisburg.psu.edu/human-resources", "https://harrisburg.psu.edu/international-programs",
        "https://harrisburg.psu.edu/marketing-research-and-communications", "https://harrisburg.psu.edu/research", "https://harrisburg.psu.edu/campus-life-and-intercultural-affairs",
        "https://cms.psu.edu", "https://canvas.psu.edu", "https://lynda.com", "https://elion.psu.edu", "", "" };

      for (int i = 0; i < names.Length; i++) {
        Service serv = new Service();
        serv.name = names[i];
        serv.description = descriptions[i];
        serv.coordinatesLatitude = coordsLat[i];
        serv.coordinatesLongitude = coordsLon[i];
        serv.phoneNumber = phoneNumbers[i];
        serv.website = websites[i];
        serv.isFavorite = false;
        con.Insert(serv);
      }

			con.DropTable<Event>();
			con.CreateTable<Event>();

			string[] event_names = { "Innovation Café","2016 Job and Franchise Fair","Career Connections with Deloitte","Deadline to Declare Minor","Dueling Pianos","Kenneth L. Marcus",
									"Bubble Soccer","Classes End"};

			string[] event_descriptions = { "Spring Forum & Networking Event","Sponsored by the Army Community Service Employment Readiness Program","A Day in the Life Career Panel","",
											"Presented by PAC","The Definition of Anti-Semitism","Presented by PAC","Spring 2016"};

			string[] event_date = {"3/30/16","3/30/16","3/31/16","4/8/16","4/9/16","4/12/16","4/16/16","4/29/16" };

			string[] event_time = { "5:00 pm - 7:00 pm","10:00 am - 2:00 pm","11:15 am - 12:45 pm","All Day","7:00 pm - 9:00 pm","7:00 pm - 9:00 pm","8:00 pm - 11:59 pm","All Day" };

			string[] event_location = { "Morrison Gallery","Carlisle Expo Center","C211, Olmsted Building","","Stacks Market Stage","Morrison Gallery","Gymnasium, Capital Union Building","" };

			string[] event_coor = {"","","Dr. Roderick Lee","","","","",""};

			string[] event_coor_phone = { "", "", "", "", "", "", "", "" };

			string[] event_misc_info = { "", "", "", "", "", "", "", "" };

			for (int i = 0; i < event_names.Length; i++)
			{
				Event ev = new Event();
				ev.name = event_names[i];
				ev.description = event_descriptions[i];
				ev.date = event_date[i];
				ev.time = event_time[i];
				ev.location = event_location[i];
				ev.coordinatorName = event_coor[i];
				ev.coordinatorPhoneNumber = event_coor_phone[i];
				ev.miscInfo = event_misc_info[i];
				con.Insert(ev);
			}

      con.DropTable<Room>();
      con.CreateTable<Room>();

      Room room1 = new Room();
      room1.roomNumber = "W255";
      room1.buildingName = "Olmsted";
      room1.description = "Department of Computer Science and Mathematical Sciences";
      room1.directions = "1. Head to the second floor of the Olmstead building.\n\n2. Make your way to the west half of the building. Hint: If you see other room numbers starting with a 'W', then you're in the right area.\n\n3. The west half is a long main hallway with a short hallway stemming off of it. W255 is located in the shorter hallway.";
      con.Insert(room1);

      Room room2 = new Room();
      room2.roomNumber = "103";
      room2.buildingName = "EAB";
      room2.description = "Auditorium Classroom";
      room2.directions = "Located on the first floor of the EAB Building.";
      con.Insert(room2);

      con.Close();
    }

  }
}

