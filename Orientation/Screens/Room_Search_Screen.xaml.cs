using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Room_Search_Screen : ContentPage
	{
		public Room_Search_Screen ()
		{
			InitializeComponent ();
			bottomLayout.Children.Add (new TabMenu(3));

			roomNumber.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
			buildingName.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
		}
	}
}

