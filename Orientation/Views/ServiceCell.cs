using System;
using Xamarin.Forms;
namespace Orientation {
  public class ServiceCell : TextCell {

    public ServiceData service { get; set; }
    public string Title { get; set; }

    public ServiceCell(ServiceData service) : this(service, false) {
    }

    public ServiceCell(ServiceData service, bool isCategory) {
      this.service = service;

      if (isCategory)
        Title = service.category;
      else
        Title = service.name;
    }

    public override string ToString() {
      return Title;
    }

    public override bool Equals(object obj) {
      return obj is ServiceCell && ((ServiceCell)obj).Title.Equals(Title);
    }

    public override int GetHashCode() {
      return base.GetHashCode();
    }
  }
}

