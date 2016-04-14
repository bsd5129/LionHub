using System;
using SQLite.Net.Attributes;
namespace Orientation {
  [Table("Events")]
  public class Event {
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string name { get; set; }
    public string link { get; set; }
    public string month { get; set; }
    public string year { get; set; }

    public Event() {

    }

    public Event(string name, string month, string year, string link) {
      this.name = name;
      this.link = link;
      this.month = month;
      this.year = year;
    }

    public bool occursIn(int month) {
      return month == monthToNumber(this.month);
    }

    private int monthToNumber(string month) {
      switch (month.ToLower()) {
        case "jan":
          return 1;
        case "feb":
          return 2;
        case "mar":
          return 3;
        case "apr":
          return 4;
        case "may":
          return 5;
        case "jun":
          return 6;
        case "jul":
          return 7;
        case "aug":
          return 8;
        case "sep":
          return 9;
        case "oct":
          return 10;
        case "nov":
          return 11;
        case "dec":
          return 12;
      }

      return -1;
    }

    public override bool Equals(object obj) {
      return obj is Event && ((Event)obj).name.Equals(name);
    }
  }
}

