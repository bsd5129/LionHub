using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Search_Screen : ContentPage
	{
		public Service_Search_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasBackButton (this, false);
			stackLayout.Children.Add (new TabMenu(1));

			if (((Orientation.App)App.Current).isDarkTheme())
				setDarkTheme();
		}

		public void setDarkTheme()
		{
			stackLayout.BackgroundColor = Color.FromHex ("#BBBBBB");
			servicesList.BackgroundColor = Color.FromHex ("#BBBBBB");
			searchBar.BackgroundColor = Color.FromHex ("#BBBBBB");
		}
	}
}

