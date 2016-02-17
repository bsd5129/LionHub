using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Search_Screen : ContentPage
	{
		public Service_Search_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasBackButton (this, false);
			stackLayout.Children.Add (new TabMenu(1));
		}
	}
}

