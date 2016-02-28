using System;
using System.IO;
using Xamarin.Forms;
using SQLite.Net.Attributes;
namespace Orientation {
  [Table("ClueSolutions")]
  public class ClueSolution {
    [PrimaryKey, AutoIncrement, Column("_id")]
    public int id { get; set; }

    [MaxLength(16)]
    public string solutionType { get; set; }

    [MaxLength(64)]
    public string solution { get; set; }

    public byte[] imageData { get; set; }

    public Image getImage() {
      if (imageData == null)
        return null;

      ImageSource source = ImageSource.FromStream(() => new MemoryStream(imageData));
      return new Image() { Source=source };
    }
  }
}

