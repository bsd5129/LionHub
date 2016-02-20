using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Where_Am_I_Screen : ContentPage
	{
		public Where_Am_I_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);

			if (((Orientation.App)App.Current).isDarkTheme())
				setDarkTheme();
		}

		public void setDarkTheme()
		{
			centerLayout.BackgroundColor = Color.FromHex ("#303030");
			stackLayout.BackgroundColor = Color.FromHex ("#303030");
			searchingLabel.TextColor = Color.FromHex ("#BBBBBB");
			indicator.Color = Color.FromHex ("#BBBBBB");
		}
	}
}

