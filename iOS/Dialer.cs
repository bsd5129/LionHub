using System;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof (Orientation.iOS.Dialer))]
namespace Orientation.iOS {
  public class Dialer : IDialer {
    public Dialer() {
    }

    public void dial(string number) {
      Device.OpenUri(new Uri("tel:" + number));
    }
  }
}

