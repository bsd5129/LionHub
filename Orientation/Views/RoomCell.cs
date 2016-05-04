using System;
using Xamarin.Forms;
namespace Orientation {
  public class RoomCell : TextCell {

    public Room room { get; set; }
    public string Title { get; set; }
    public Color Color { get; set; }

    public RoomCell(Room room){
      this.room = room;
      Title = room.roomNumber;
      Color = Theme.getTextColor();
    }

    public override string ToString() {
      return Title;
    }

    public override bool Equals(object obj) {
      return obj is RoomCell && ((RoomCell)obj).Title.Equals(Title);
    }

    public override int GetHashCode() {
      return base.GetHashCode();
    }
  }
}

