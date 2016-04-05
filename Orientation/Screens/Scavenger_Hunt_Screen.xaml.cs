using System;
using System.Collections.Generic;
using SQLite.Net;

namespace Orientation
{
	public partial class Scavenger_Hunt_Screen : ContentPage
	{
		private ClueSolution currentClue;
		private ClueDescription lastDescription;

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
			clue.TextColor = Theme.getTextColor();
			solution.BackgroundColor = Theme.getEntryColor();
			solution.PlaceholderColor = Theme.getEntryPlaceholderColor();
		}

		public Service getServiceData(string name)
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			TableQuery<Service> query = from s in connection.Table<Service>() where s.name.Equals(name) select s;
			Service service = query.FirstOrDefault();
			connection.Close();
			return service;
		}

		public void queryClues()
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var clues = connection.Table<ClueSolution>().OrderBy(s => (s.solved == false));
			currentClue = clues.First();
			if (currentClue.solved == false)
			{
				resetClues();
			}

			connection.Close();
		}

		public void checkSolutionTapped()
		{
			String sol = solution.Text;
			if (sol.Equals(currentClue))
			{

			}
			else
			{

			}
		}

		public void showHint()
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var descs = connection.Table<ClueDescription>();

			foreach (var desc in descs)
			{
				if (desc.solutionID == currentClue.id)
				{
					lastDescription = desc;
					break;
				}
			}

			connection.Close();
			hint.Text = lastDescription.description;
		}


		public void resetClues()
		{
			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var reset = connection.Table<ClueSolution>();
			foreach (var r in reset)
			{
				r.solved = false;
			}
		}
	}
}

