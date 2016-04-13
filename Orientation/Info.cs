using System;
using SQLite.Net.Attributes;
namespace Orientation {
  [Table("Info")]
  public class Info {

    public Info() {
    }

    public Info(String key, long value) {
      this.key = key;
      this.value = value;
    }

    [PrimaryKey, NotNull]
    public string key { get; set; }

    public long value { get; set; }
  }
}

