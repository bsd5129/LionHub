using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Favorites_Screen : ContentPage
	{
		public Favorites_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasBackButton (this, false);
			bottomLayout.Children.Add (new TabMenu(2));

			setTheme ();
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			favoritesList.BackgroundColor = Theme.getBackgroundColor();
		}
	}
}

