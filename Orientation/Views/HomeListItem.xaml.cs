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
			image.Source = imageBase + ".png";

			TapGestureRecognizer tap = new TapGestureRecognizer { NumberOfTapsRequired = 1 };

			tap.Tapped += (object sender, EventArgs e) => {
				home.pressHomeListItem(name);
			};

			GestureRecognizers.Add (tap);

			if (((Orientation.App)App.Current).isDarkTheme())
				setDarkTheme();
		}

		public void setDarkTheme()
		{
			buttonText.TextColor = Color.FromHex ("#BBBBBB");
			image.Source = imageBase + "_darkTheme.png";
		}
	}
}

