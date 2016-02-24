using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Scavenger_Hunt_Screen : ContentPage
	{
		public Scavenger_Hunt_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasBackButton(this, false);
			bottomLayout.Children.Add(new TabMenu(4));
			solution.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
			setTheme();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			clue.TextColor = Theme.getTextColor();
			solution.BackgroundColor = Theme.getEntryColor();
			solution.PlaceholderColor = Theme.getEntryPlaceholderColor();
		}
	}
}

