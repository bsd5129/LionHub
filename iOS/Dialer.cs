using System;

namespace Orientation.iOS {
  public class Dialer : IDialer {
    public Dialer() {
    }

    public void dial(string number) {
      UIKit.UIApplication.SharedApplication.OpenUrl(new Foundation.NSUrl("tel: " + number));
    }
  }
}

