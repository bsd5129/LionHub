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
			NavigationPage.SetHasBackButton(this, false);
			NavigationPage.SetBackButtonTitle(this, "Search");
			bottomLayout.Children.Add (new TabMenu(3));

			roomNumber.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);
			buildingName.WidthRequest = (int)(0.8 * ((Orientation.App)App.Current).getScreenSize().Width);

			setTheme();
		}

		public void setTheme()
		{
			stackLayout.BackgroundColor = Theme.getBackgroundColor();
			roomNumber.BackgroundColor = Theme.getEntryColor();
			roomNumber.PlaceholderColor = Theme.getEntryPlaceholderColor();
			buildingName.BackgroundColor = Theme.getEntryColor();
		}

		public void pressSearchButton(object sender, EventArgs args)
		{
			((NavigationPage)App.Current.MainPage).PushAsync(new Room_Results_Screen());
		}
	}
}

