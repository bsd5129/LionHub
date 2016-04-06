using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;
namespace Orientation
{
	public partial class Scavenger_Hunt_Screen : ContentPage
	{
		private Solution currentClue;
		private Hint lastDescription;

		public Scavenger_Hunt_Screen()
		{
			InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
			bottomLayout.Children.Add(new TabMenu(4));
			solution.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
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
			var clues = connection.Table<Solution>().OrderBy(s => s.solved).Where(s => s.solved == false);
		
			currentClue = clues.First();
			if (currentClue.solved == false)
			{
				resetClues();
			}
			
			connection.Close();
		}

		public void checkSolutionTapped(object sender, EventArgs args)
		{
			String sol = solution.Text;
			if (sol.Equals(currentClue))
			{
				hint.Text = "Wrong Answer";
			}
			else
			{
				SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
				var put = connection.Table<Solution>().Where(s => (s.id == currentClue.id));
				hint.Text = "Correct Answer";
				var changeSolved = put.First();
				changeSolved.solved = true;
				connection.Close();
			}
		}

		public void showHint(object sender, EventArgs args)
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var descs = connection.Table<Hint>();

			foreach (var desc in descs)
			{
				if (desc.solutionID == currentClue.id)
				{
					lastDescription = desc;
					break;
				}
			}

			connection.Close();
			hint.Text = lastDescription.description.ToString();
		}


		public void resetClues()
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var reset = connection.Table<Solution>();
			foreach (var r in reset)
			{
				r.solved = false;
			}
		}
	}
}

