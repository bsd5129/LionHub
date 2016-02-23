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

			TapGestureRecognizer tap = new TapGestureRecognizer { NumberOfTapsRequired = 1 };

			tap.Tapped += (object sender, EventArgs e) => {
				if (!buttonSelected)
				{
					parentMenu.pressMenuButton(name);
				}
			};

			GestureRecognizers.Add (tap);

			setTheme();
		}

		public void setSelected (bool isSelected)
		{
			if (isSelected) {
				buttonText.TextColor = Color.FromHex ("#007aff");
				image.Source = imageBaseName + "_selected.png";

				if (Theme.isDarkTheme())
					BackgroundColor = Theme.getBackgroundColor();
				else
					BackgroundColor = Color.FromHex("#fafafa");
			} else {
				buttonText.TextColor = Color.Black;
				BackgroundColor = Color.Transparent;
				image.Source = imageBaseName + ".png";
			}

			buttonSelected = isSelected;
		}

		public void setTheme()
		{
			buttonText.TextColor = Theme.getTextColor();

			if (Theme.isDarkTheme())
				image.Source = imageBaseName + "_darkTheme.png";
			else
				image.Source = imageBaseName + ".png";
		}
	}
}

