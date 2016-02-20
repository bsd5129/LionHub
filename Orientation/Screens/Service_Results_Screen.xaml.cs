using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Results_Screen : ContentPage
	{
		public Service_Results_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasBackButton (this, false);

			bottomLayout.Children.Add (new TabMenu(1));

			if (((Orientation.App)App.Current).isDarkTheme())
				setDarkTheme();
		}

		public void setDarkTheme()
		{
			//name.TextColor = Color.FromHex ("#BBBBBB");
			//description.TextColor = Color.FromHex ("#BBBBBB");
			//coordinates.TextColor = Color.FromHex ("#BBBBBB");
			//phone.TextColor = Color.FromHex ("#BBBBBB");
			//website.TextColor = Color.FromHex ("#BBBBBB");

			bottomLayout.BackgroundColor = Color.FromHex ("#BBBBBB");
			stackLayout.BackgroundColor = Color.FromHex ("#BBBBBB");
		}
	}
}

