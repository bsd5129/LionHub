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
			stackLayout.Children.Add (new TabMenu(2));

			if (((Orientation.App)App.Current).isDarkTheme())
				setDarkTheme();
		}

		public void setDarkTheme()
		{
			stackLayout.BackgroundColor = Color.FromHex ("#BBBBBB");
			favoritesList.BackgroundColor = Color.FromHex ("#BBBBBB");
		}
	}
}

