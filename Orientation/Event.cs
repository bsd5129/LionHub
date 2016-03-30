using System;
using SQLite.Net.Attributes;
namespace Orientation {
  [Table("Events")]
  public class Event {
    [PrimaryKey, AutoIncrement, Column("_id")]
    public int id { get; set; }

    [MaxLength(128)]
    public string name { get; set; }

    [MaxLength(4096)]
    public string description { get; set; }

    [MaxLength(128)]
    public string date { get; set; }

    [MaxLength(128)]
    public string time { get; set; }

    [MaxLength(128)]
    public string location { get; set; }

    [MaxLength(64)]
    public string coordinatorName { get; set; }

    [MaxLength(16)]
    public string coordinatorPhoneNumber { get; set; }

    [MaxLength(4096)]
    public string miscInfo { get; set; }

	public int month { get; set; }
  }
}

