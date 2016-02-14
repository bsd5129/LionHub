using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Orientation
{
	public partial class MenuButton : ContentView
	{
		public MenuButton (string name, string imageSource)
		{
			InitializeComponent ();
			buttonText.Text = name;
			image.Source = imageSource;
		}
	}
}

