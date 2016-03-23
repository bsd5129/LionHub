using System;
using Xamarin.Forms;
using Android.Content;
using Android.Net;

namespace Orientation.Droid {
  public class Dialer : IDialer {
    public Dialer() {
    }

    public void dial(string number) {
      var context = Forms.Context;
      var intent = new Intent(Intent.ActionCall);
      intent.SetData(Android.Net.Uri.Parse("tel:" + number));
      context.StartActivity(intent);
    }
  }
}

