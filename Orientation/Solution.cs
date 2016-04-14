using System;
using System.IO;
using Xamarin.Forms;
using SQLite.Net.Attributes;
namespace Orientation {
  [Table("Solutions")]
  public class Solution {
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
	  
    public bool solved { get; set;}
    
	  [MaxLength(16)]
    public int type { get; set; }

    [MaxLength(64)]
    public string solution { get; set; }
  }
}

