using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation {
  public partial class Event_Web_Screen : ContentPage {
    private string pageUrl;

    public Event_Web_Screen(string title, string pageUrl) {
      InitializeComponent();
      NavigationPage.SetHasNavigationBar(this, true);
      NavigationPage.SetHasBackButton(this, true);
      Title = title;
      this.pageUrl = pageUrl;

      webView.Source = new UrlWebViewSource {
        Url = this.pageUrl
      };
    }
  }
}

