using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Orientation
{
	public partial class MenuButton : ContentView
	{
		private string imageBaseName;
		private bool buttonSelected = false;

		public MenuButton (TabMenu parentMenu, string name, string imageBase)
		{
			InitializeComponent ();
			imageBaseName = imageBase;
			buttonText.Text = name;
			image.Source = imageBaseName + ".png";

			TapGestureRecognizer tap = new TapGestureRecognizer { NumberOfTapsRequired = 1 };

			tap.Tapped += (object sender, EventArgs e) => {
				if (!buttonSelected)
				{
					parentMenu.pressMenuButton(name);
				}
			};

			GestureRecognizers.Add (tap);

			if (((Orientation.App)App.Current).isDarkTheme())
				setDarkTheme();
		}

		public void setSelected (bool isSelected)
		{
			if (isSelected) {
				buttonText.TextColor = Color.FromHex ("#007aff");
				image.Source = imageBaseName + "_selected.png";

				if (((Orientation.App)App.Current).isDarkTheme())
					BackgroundColor = Color.FromHex("#303030");
				else
					BackgroundColor = Color.FromHex("#fafafa");
			} else {
				buttonText.TextColor = Color.Black;
				BackgroundColor = Color.Transparent;
				image.Source = imageBaseName + ".png";
			}

			buttonSelected = isSelected;
		}

		public void setDarkTheme()
		{
			buttonText.TextColor = Color.FromHex ("#BBBBBB");
			image.Source = imageBaseName + "_darkTheme.png";
		}
	}
}

