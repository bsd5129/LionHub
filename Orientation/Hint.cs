using System;
using SQLite.Net.Attributes;
namespace Orientation {
  [Table("Hints")]
  public class Hint {
    [PrimaryKey, AutoIncrement, Column("_id")]
    public int id { get; set; }
	public int solutionID { get; set; }
    [MaxLength(512)]
    public string description { get; set; }
  }
}

