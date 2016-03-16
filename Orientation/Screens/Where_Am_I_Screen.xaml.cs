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
			NavigationPage.SetHasBackButton (this, false);

			setTheme ();
		}

		public void setTheme()
		{
			centerLayout.BackgroundColor = Theme.getBackgroundColor();
			stackLayout.BackgroundColor = Theme.getBackgroundColor();
			searchingLabel.TextColor = Theme.getTextColor();
			indicator.Color = Theme.getTextColor();
		}

		public float coordToMeters(float startLat, float destLat, float startLong, float destLong)
		{
			float R = 6378.137F;
			float dLat = (destLat - startLat) * (float)(Math.PI / 180);
			float dLon = (destLong - startLong) * (float)(Math.PI / 180);
			float A = (float)(Math.Sin(dLat / 2) * Math.Sin(dLat / 2) * Math.Cos(startLat * Math.PI / 180) * Math.Cos(destLat * Math.PI / 180)
			                  * Math.Sin(dLon / 2) * Math.Sin(dLon/2));

			float C = (float)(2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1 - A)));
			float D = R * C;

			return D * 1000;
		}
	}
}

