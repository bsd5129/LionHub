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

			setTheme ();
		}

		public void setTheme()
		{
			bottomLayout.BackgroundColor = Theme.getBackgroundColor ();
			stackLayout.BackgroundColor = Theme.getBackgroundColor ();
		}
	}
}

