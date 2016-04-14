using System;
using SQLite.Net.Attributes;
namespace Orientation {
  [Table("Services")]
  public class Service {
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }

    [MaxLength(64)]
    public string name { get; set; }

    [MaxLength(4096)]
    public string description { get; set; }

    public float coordinatesLatitude { get; set; }

    public float coordinatesLongitude { get; set; }

    [MaxLength(16)]
    public string phoneNumber { get; set; }

    [MaxLength(128)]
    public string website { get; set; }

    public bool isFavorite { get; set; }

    [MaxLength(32)]
    public string category { get; set; }
  }
}

