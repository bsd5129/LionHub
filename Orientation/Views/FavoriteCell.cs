using System;
using Xamarin.Forms;
namespace Orientation {
  public class FavoriteCell : TextCell {

    public Service service { get; set; }
    public string Title { get; set; }

    public FavoriteCell(Service service) {
      this.service = service;
      Title = service.name;
    }

    public override string ToString() {
      return Title;
    }
  }
}

