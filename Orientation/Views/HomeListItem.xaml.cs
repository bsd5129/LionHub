using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Orientation
{
	public partial class HomeListItem : ContentView
	{

		public HomeListItem (Home_Screen home, string name, string imageFile)
		{
			InitializeComponent ();
			buttonText.Text = name;
			image.Source = imageFile;

			TapGestureRecognizer tap = new TapGestureRecognizer { NumberOfTapsRequired = 1 };

			tap.Tapped += (object sender, EventArgs e) => {
				home.pressHomeListItem(name);
			};

			GestureRecognizers.Add (tap);
		}
	}
}

