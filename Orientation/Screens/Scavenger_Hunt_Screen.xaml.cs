using System;
using SQLite.Net;
using Xamarin.Forms;
using Plugin.Geolocator;

namespace Orientation
{
	public partial class Scavenger_Hunt_Screen : ContentPage
	{
		private Solution currentSolution;
		private string lastDescription;

		public Scavenger_Hunt_Screen()
		{
			InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
			bottomLayout.Children.Add(new TabMenu(4));
			solution.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
      hint.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
      geoInfo.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
			extraHint.IsEnabled = true;
      checkSolution.IsEnabled = true;
      queryClues();
			setTheme();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			hint.TextColor = Theme.getTextColor();
			solution.BackgroundColor = Theme.getEntryColor();
			solution.PlaceholderColor = Theme.getEntryPlaceholderColor();
      geoInfo.TextColor = Theme.getTextColor();
		}

		public void queryClues()
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var clues = connection.Table<Solution>().OrderBy(s => s.id).Where(s => s.solved == false);

      if (clues.Count() == 0) {
        connection.Close();
        resetClues();
      } else {
        currentSolution = clues.First();
        connection.Close();

        if (currentSolution.type == 0) {
          solution.IsEnabled = true;
          solution.IsVisible = true;
          geoInfo.IsVisible = false;
        } else {
          solution.IsEnabled = false;
          solution.IsVisible = false;
          geoInfo.IsVisible = true;
        }

        lastDescription = null;
        showHint(null, null);
      }
		}

		public async void checkSolutionTapped(object sender, EventArgs args)
		{
      extraHint.IsEnabled = false;
      checkSolution.IsEnabled = false;

      if (currentSolution.type == 0) {
        if (solution.Text == null || !solution.Text.ToLower().Trim().Equals(currentSolution.solution.ToLower().Trim())) {
          await DisplayAlert("Incorrect", "Please try again.", "OK");
        } else {
          SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
          currentSolution.solved = true;
          connection.Update(currentSolution);
          connection.Close();
          solution.Text = "";
          queryClues();
          await DisplayAlert("Correct", "", "OK");
        }
      } else {
        var locator = CrossGeolocator.Current;
        locator.DesiredAccuracy = 5;
        var position = await locator.GetPositionAsync(timeoutMilliseconds: (1000 * 60 * 2));
        float curLat = (float)position.Latitude;
        float curLon = (float)position.Longitude;

        string[] coords = currentSolution.solution.Split(new char[] { ',' });

        if (distanceFrom(curLat, curLon, float.Parse(coords[0]), float.Parse(coords[1])) <= 13) {
          SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
          currentSolution.solved = true;
          connection.Update(currentSolution);
          connection.Close();
          queryClues();
          await DisplayAlert("Correct", "", "OK");
        } else {
          await DisplayAlert("Incorrect", "You are in the wrong location. Please try again.", "OK");
        }
      }

      extraHint.IsEnabled = true;
      checkSolution.IsEnabled = true;
		}

		public void showHint(object sender, EventArgs args)
		{
      if (currentSolution == null)
        return;

			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var descs = connection.Table<Hint>().Where(h => h.solutionID == currentSolution.id).OrderBy(h => h.id);

      if (lastDescription == null) {
        lastDescription = descs.FirstOrDefault().description;
      } else {
        bool found = false;
        bool beenSet = false;

        foreach (Hint desc in descs) {
          if (found) {
            lastDescription = desc.description;
            beenSet = true;
            break;
          }

          if (desc.description.Equals(lastDescription)) {
            found = true;
          }
        }

        if (!beenSet) {
          lastDescription = descs.FirstOrDefault().description;
        }
      }



			connection.Close();
      hint.Text = lastDescription;
		}


		public void resetClues()
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var reset = connection.Table<Solution>();
			
      foreach (var r in reset)
			{
				r.solved = false;
        connection.Update(r);
			}

      connection.Close();
      queryClues();

      DisplayAlert("Complete", "You have completed the Scavenger Hunt! The clues will now reset.", "OK");
		}

    public float distanceFrom(float lat1, float lon1, float lat2, float lon2) {
      float dLat = (lat2 - lat1) * (float)(Math.PI / 180);
      float dLon = (lon2 - lon1) * (float)(Math.PI / 180);
      float A = (float)(Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                        + Math.Cos(lat1 * (float)(Math.PI / 180)) * Math.Cos(lat2 * (float)(Math.PI / 180))
                        * Math.Sin(dLon / 2) * Math.Sin(dLon / 2));

      float C = (float)(2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1 - A)));
      return 6367 * C * 1000;
    }
	}
}

