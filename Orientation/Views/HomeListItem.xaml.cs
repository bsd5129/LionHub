using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Orientation
{
	public partial class HomeListItem : ContentView
	{
		private string imageBase;

		public HomeListItem (Home_Screen home, string name, string imageBase)
		{
			InitializeComponent ();
			buttonText.Text = name;
			this.imageBase = imageBase;

			TapGestureRecognizer tap = new TapGestureRecognizer { NumberOfTapsRequired = 1 };

			tap.Tapped += (object sender, EventArgs e) => {
				home.pressHomeListItem(name);
			};

			GestureRecognizers.Add (tap);

			setTheme();
		}

		public void setTheme()
		{
			buttonText.TextColor = Theme.getTextColor();

			if (Theme.isDarkTheme())
				image.Source = imageBase + "_darkTheme.png";
			else
				image.Source = imageBase + ".png";
		}
	}
}

