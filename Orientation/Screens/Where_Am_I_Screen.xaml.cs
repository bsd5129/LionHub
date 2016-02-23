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

			setTheme ();
		}

		public void setTheme()
		{
			centerLayout.BackgroundColor = Theme.getBackgroundColor();
			stackLayout.BackgroundColor = Theme.getBackgroundColor();
			searchingLabel.TextColor = Theme.getTextColor();
			indicator.Color = Theme.getTextColor();
		}
	}
}

