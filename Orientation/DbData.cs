using System;
using Xamarin.Forms;
using SQLite.Net;
namespace Orientation {
  public class DbData {

    public static void initializeDatabaseData() {
      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();

      con.DropTable<Service>();
      con.CreateTable<Service>();

      string[] names = {
        "Alumni Relations",
        "Office of Development",
        "Faculty Senate",
        "Honors Program",
        "Human Resources",
        "International Programs",
        "Office of Research and Outreach",
        "Campus Life and Intercultural Affairs",
        "Angel",
        "Canvas",
        "Lynda",
        "Elion",
        "Olmsted Building",
        "Library",
        "Undergraduate Programs",
        "Graduate Programs",
        "Academic Calendar",
        "Academic Guidelines And Policies",
        "Academic Schools",
        "Advising And Division Of Undergraduate Studies",
        "Army ROTC",
        "Bursar's Office",
        "Commencement",
        "Continuing Education",
        "Financial Aid",
        "First-Year Seminar / Cocurriculars",
        "International Programs",
        "Learning Center",
        "Registrar",
        "Schedule Of Courses",
        "Scholarships",
        "Weather Policy"};
      
      string[] descriptions = { 
        "College and community support organization", 
        "N/A",
        "Penn State University representative group",
        "Unique learning program for students with academic excellence",
        "Information on Jobs, Software training, Family resources, and other school related resources",
        "International Penn State study programs",
        "Events, Marketing Research, News",
        "Student organization info and other Campus information",
        "Student classroom information, canvas alternative",
        "Student classroom information, angel alternative",
        "Free service to PSU students for additional skill training",
        "Students transcript information, financial aid info, and other student services",
        "",
        "" };

      float[] coordsLat = {-999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, 40.205259f, 40.204228f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, };

      float[] coordsLon = { -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -76.742013f, -76.741195f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f, -999.0f };

      string[] phoneNumbers = {
        "717-948-6715",
        "717-948-6316",
        "717-948-6062",
        "717-948-6062",
        "717-948-6004",
        "717-948-6003",
        "717-948-6303",
        "717-948-6273",
        "",
        "",
        "",
        "",
        "",
        "" };

      string[] websites = { 
        "https://harrisburg.psu.edu/alumni-relations",
        "https://harrisburg.psu.edu/philanthropy",
        "https://harrisburg.psu.edu/faculty-senate",
        "https://harrisburg.psu.edu/honors-program",
        "https://harrisburg.psu.edu/human-resources",
        "https://harrisburg.psu.edu/international-programs",
        "https://harrisburg.psu.edu/research",
        "https://harrisburg.psu.edu/campus-life-and-intercultural-affairs",
        "https://cms.psu.edu",
        "https://canvas.psu.edu",
        "https://lynda.com",
        "https://elion.psu.edu",
        "",
        "https://www.libraries.psu.edu/psul/harrisburg.html",
        "https://harrisburg.psu.edu/academics/undergraduate-programs",
        "https://harrisburg.psu.edu/academics/graduate-programs",
        "https://harrisburg.psu.edu/academic-calendar",
        "https://harrisburg.psu.edu/academics/academic-guidelines-and-policies",
        "https://harrisburg.psu.edu/academics#academic-schools",
        "https://harrisburg.psu.edu/division-undergraduate-studies-advising-center",
        "https://harrisburg.psu.edu/programs/army-rotc",
        "https://harrisburg.psu.edu/bursar",
        "https://harrisburg.psu.edu/commencement",
        "https://harrisburg.psu.edu/continuing-education",
        "https://harrisburg.psu.edu/financial-aid",
        "https://harrisburg.psu.edu/academics/first-year-seminar/",
        "https://harrisburg.psu.edu/international-programs",
        "https://harrisburg.psu.edu/learning-center",
        "https://harrisburg.psu.edu/registrar",
        "http://schedule.psu.edu/",
        "https://harrisburg.psu.edu/financial-aid/scholarships",
        "https://harrisburg.psu.edu/policy/c-5-inclement-weather"
      };

      string[] categories = {
        "Alumni & Development",
        "Alumni & Development",
        "Faculty & Staff",
        "Academics",
        "Faculty & Staff",
        "Academics",
        "Academics",
        "Student Life",
        "Online",
        "Online",
        "Online",
        "Online",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics",
        "Academics" };

      for (int i = 0; i < names.Length; i++) {
        Service serv = new Service();
        serv.name = names[i];

        if (i < descriptions.Length)
          serv.description = descriptions[i];
        else
          serv.description = "N/A";

        serv.coordinatesLatitude = coordsLat[i];
        serv.coordinatesLongitude = coordsLon[i];

        if (i < phoneNumbers.Length)
          serv.phoneNumber = phoneNumbers[i];
        else
          serv.phoneNumber = "N/A";

        serv.website = websites[i];
        serv.isFavorite = false;
        serv.category = categories[i];
        con.Insert(serv);
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

      con.DropTable<Solution>();
      con.CreateTable<Solution>();
      con.DropTable<Hint>();
      con.CreateTable<Hint>();

      Solution solution = new Solution();
      solution.id = 1;
      solution.solved = false;
      solution.type = "string";
      solution.solution = "Vartan Plaza";
      con.Insert(solution);

      Hint hint = new Hint();
      hint.solutionID = 1;
      hint.description = "It is the main thoroughfare for students walking to and from campus and the buildings throughout." ;
      con.Insert(hint);

      hint = new Hint();
      hint.solutionID = 1;
      hint.description = "It is a social meeting place for students to study, participate in activities, meet up with friends and enjoy the picturesque campus.";
      con.Insert(hint);

      hint = new Hint();
      hint.solutionID = 1;
      hint.description = "It is home to a lovely fountain.";
      con.Insert(hint);

      solution = new Solution();
      solution.id = 2;
      solution.solved = false;
      solution.type = "coordinates";
      solution.solution = "40.204451 -76.741674";
      con.Insert(solution);

      hint = new Hint();
      hint.solutionID = 2;
      hint.description = "It is the proud symbol of the University, uniting future, current and former Penn Staters for a lifetime.";
      con.Insert(hint);

      hint = new Hint();
      hint.solutionID = 2;
      hint.description = "It is prominently perched on the plaza. Students and alumni always enjoy having their picture taken with this clue. ";
      con.Insert(hint);

      solution = new Solution();
      solution.id = 3;
      solution.solved = false;
      solution.type = "string";
      solution.solution = "Library";
      con.Insert(solution);

      hint = new Hint();
      hint.solutionID = 3;
      hint.description = "It is a three-story, 115,000-square-foot, technologically advanced academic research facility. includes 300,000 volumes, more than 600 journals, and 1.3 million microforms.";
      con.Insert(hint);

      hint = new Hint();
      hint.solutionID = 3;
      hint.description = "It includes 300,000 volumes, more than 600 journals, and 1.3 million microforms.";
      con.Insert(hint);

      solution = new Solution();
      solution.id = 4;
      solution.solved = false;
      solution.type = "coordinates";
      solution.solution = "40.204384 -76.741046";
      con.Insert(solution);

      hint = new Hint();
      hint.solutionID = 4;
      hint.description = "A great place to study, it has vending machines, microwaves and computer access.";
      con.Insert(hint);

      hint = new Hint();
      hint.solutionID = 4;
      hint.description = "It is open 24 hour a day making it an ideal meeting are for students.";
      con.Insert(hint);

      solution = new Solution();
      solution.id = 5;
      solution.solved = false;
      solution.type = "coordinates";
      solution.solution = "40.204951 -76.742051";
      con.Insert(solution);

      hint = new Hint();
      hint.solutionID = 5;
      hint.description = "Virtue, Liberty, and Independence.";
      con.Insert(hint);

      hint = new Hint();
      hint.solutionID = 5;
      hint.description = "This centrally located emblem displays the founding beliefs as well as the date the university was established.";
      con.Insert(hint);

      solution = new Solution();
      solution.id = 6;
      solution.solved = false;
      solution.type = "string";
      solution.solution = "Olmsted";
      con.Insert(solution);

      hint = new Hint();
      hint.solutionID = 6;
      hint.description = "It is the main building on campus, housing the majority of classes. ";
      con.Insert(hint);

      hint = new Hint();
      hint.solutionID = 6;
      hint.description = "Home to most of the administrative offices and where each of the college's academic schools are housed.";
      con.Insert(hint);

      //Initialize Info Table
      //con.DropTable<Event>();

      try {
        con.CreateTable<Event>();
      } catch (Exception ex) {

      }
      //con.DropTable<Info>();

      try {
        con.CreateTable<Info>();
        con.Insert(new Info("dbVersion", 1));
        con.Insert(new Info("eventCacheTime", 0));
      } catch (Exception ex) {

      }
      con.Close();
    }

  }
}

