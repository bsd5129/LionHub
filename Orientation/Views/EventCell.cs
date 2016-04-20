using System;
using Xamarin.Forms;
namespace Orientation {
  public class EventCell : TextCell {

    public Event evnt { get; set; }
    public string Title { get; set; }
    public Color Color { get; set; }

    public EventCell(Event evnt){
      this.evnt = evnt;
      Title = evnt.name;
      Color = Theme.getTextColor();
    }

    public override string ToString() {
      return Title;
    }

    public override bool Equals(object obj) {
      return obj is EventCell && ((EventCell)obj).Title.Equals(Title);
    }

    public override int GetHashCode() {
      return base.GetHashCode();
    }
  }
}

