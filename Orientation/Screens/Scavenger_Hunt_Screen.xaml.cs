using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;
namespace Orientation
{
	public partial class Scavenger_Hunt_Screen : ContentPage
	{
		private Solution currentClue;
		private string lastDescription;

		public Scavenger_Hunt_Screen()
		{
			InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
			bottomLayout.Children.Add(new TabMenu(4));
			solution.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
      hint.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
			queryClues();
			setTheme();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			hint.TextColor = Theme.getTextColor();
			solution.BackgroundColor = Theme.getEntryColor();
			solution.PlaceholderColor = Theme.getEntryPlaceholderColor();
		}

		public void queryClues()
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var clues = connection.Table<Solution>().OrderBy(s => s.id).Where(s => s.solved == false);

      if (clues.Count() == 0) {
        connection.Close();
        resetClues();
      } else {
        currentClue = clues.First();
        connection.Close();

        if (currentClue.type == 0)
          solution.IsEnabled = true;
        else
          solution.IsEnabled = false;

        lastDescription = null;
        showHint(null, null);
      }
		}

		public async void checkSolutionTapped(object sender, EventArgs args)
		{
      if (currentClue.type == 0) {
        if (solution.Text == null || !solution.Text.ToLower().Trim().Equals(currentClue.solution.ToLower().Trim())) {
          await DisplayAlert("Incorrect", "", "OK");
        } else {
          SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
          currentClue.solved = true;
          connection.Update(currentClue);
          connection.Close();
          solution.Text = "";
          queryClues();
          await DisplayAlert("Correct", "", "OK");
        }
      } else {
        SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
        currentClue.solved = true;
        connection.Update(currentClue);
        connection.Close();
        queryClues();
        await DisplayAlert("Correct", "", "OK");
      }
		}

		public void showHint(object sender, EventArgs args)
		{
      if (currentClue == null)
        return;

			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var descs = connection.Table<Hint>().Where(h => h.solutionID == currentClue.id).OrderBy(h => h.id);

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
	}
}

