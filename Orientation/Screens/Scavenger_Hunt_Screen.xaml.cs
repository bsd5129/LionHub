using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Scavenger_Hunt_Screen : ContentPage
	{
		public Scavenger_Hunt_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasBackButton(this, false);
			bottomLayout.Children.Add(new TabMenu(4));
		}
	}
}

