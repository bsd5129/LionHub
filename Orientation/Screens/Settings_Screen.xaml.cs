using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SQLite.Net;

namespace Orientation {
  public partial class Settings_Screen : ContentPage {

    public Settings_Screen() {
      InitializeComponent();
      themeStatus.Text = Theme.getActiveThemeName();
      themeStatus.TextColor = Color.Green;

      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      version.Text = "Database Version: " + con.Table<Info>().Where(i => i.key.Equals("dbVersion")).FirstOrDefault().value;
      long downloadTimestamp = con.Table<Info>().Where(i => i.key.Equals("dbTimestamp")).FirstOrDefault().value;
      version.Detail = "Last Update: " + (new DateTime(1970, 1, 1)).AddMilliseconds((double)downloadTimestamp).ToLocalTime().ToString();
      con.Close();

      setTheme();
    }

    public void setTheme() {
      BackgroundColor = Theme.getBackgroundColor();
      tableView.BackgroundColor = Theme.getBackgroundColor();

      themeText.TextColor = Theme.getTextColor();
      themeDetail.TextColor = Theme.getTextColor();

      version.TextColor = Theme.getTextColor();
      version.DetailColor = Theme.getTextColor();

      credits.TextColor = Theme.getTextColor();
      credits.DetailColor = Theme.getTextColor();
    }

    public void pressCycleThemeButton(object sender, EventArgs args) {
      Theme.cycleTheme();
      NavigationPage page = new NavigationPage(new Home_Screen());
      page.PushAsync(new Settings_Screen());
      ((Orientation.App)App.Current).setMainPage(page);
    }

    public void pressCreditsButton(object sender, EventArgs args) {
      displayCredits();
    }

    public async void displayCredits() {
      await DisplayAlert("LionHub", "Developed by:\n\nBrandon Davis\nJohn Deebel\nClarence LaShier\nNgan Nguyen", "Close");
    }
  }
}

