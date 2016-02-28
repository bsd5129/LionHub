using System;
using SQLite.Net.Attributes;
namespace Orientation {
  [Table("Rooms")]
  public class Room {
    [PrimaryKey, AutoIncrement, Column("_id")]
    public int id { get; set; }

    [MaxLength(32)]
    public string roomNumber { get; set; }

    [MaxLength(64)]
    public string buildingName { get; set; }

    [MaxLength(4096)]
    public string description { get; set; }

    [MaxLength(4096)]
    public string directions { get; set; }
  }
}

