using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation {
  public partial class Settings_Screen : ContentPage {

    public Settings_Screen() {
      InitializeComponent();
      darkThemeStatus.Text = Theme.isDarkTheme() ? "Enabled" : "Disabled";
      darkThemeStatus.TextColor = Theme.isDarkTheme() ? Color.Green : Color.Red;
      setTheme();
    }

    public void setTheme() {
      BackgroundColor = Theme.getBackgroundColor();
      tableView.BackgroundColor = Theme.getBackgroundColor();

      darkThemeText.TextColor = Theme.getTextColor();
      darkThemeDetail.TextColor = Theme.getTextColor();
      //darkThemeSwitch.BackgroundColor = Theme.getBackgroundColor();

      version.TextColor = Theme.getTextColor();
      version.DetailColor = Theme.getTextColor();

      credits.TextColor = Theme.getTextColor();
      credits.DetailColor = Theme.getTextColor();
    }

    public void pressDarkThemeListItem(object sender, EventArgs args) {
      Theme.setDarkTheme(!Theme.isDarkTheme());
      NavigationPage page = new NavigationPage(new Home_Screen());
      page.PushAsync(new Settings_Screen());
      ((Orientation.App)App.Current).setMainPage(page);
    }

    public void pressVersionListItem(object sender, EventArgs args) {
      //NOTHING FOR NOW
    }

    public void pressCreditsListItem(object sender, EventArgs args) {
      //NOTHING FOR NOW
    }
  }
}

