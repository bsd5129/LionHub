using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Orientation
{
	public partial class MenuButton : ContentView
	{
		private TabMenu parent;
		private ContentPage linkedPage;
		private string imageBaseName;
		private bool buttonSelected = false;

		public MenuButton (TabMenu parentMenu, string name, string imageBase, ContentPage link)
		{
			InitializeComponent ();
			parent = parentMenu;
			imageBaseName = imageBase;
			linkedPage = link;
			buttonText.Text = name;
			image.Source = imageBaseName + ".png";

			TapGestureRecognizer tap = new TapGestureRecognizer { NumberOfTapsRequired = 1 };

			tap.Tapped += (object sender, EventArgs e) => {
				if (!buttonSelected)
				{
					parent.setSelected (this);
					App.Current.MainPage = new NavigationPage(linkedPage);
				}
			};

			GestureRecognizers.Add (tap);
		}

		public void setSelected (bool isSelected)
		{
			if (isSelected) {
				buttonText.TextColor = Color.FromHex ("#007aff");
				BackgroundColor = Color.FromHex("#f2f2f2");
				image.Source = imageBaseName + "_selected.png";
			} else {
				buttonText.TextColor = Color.Black;
				BackgroundColor = Color.Transparent;
				image.Source = imageBaseName + ".png";
			}

			buttonSelected = isSelected;
		}

		public ContentPage getLinkedPage()
		{
			return linkedPage;
		}
	}
}

