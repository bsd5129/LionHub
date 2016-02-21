using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Event_Search_Screen : ContentPage
	{

		private Label resultsLabel;
		private SearchBar searchBar;

		public Event_Search_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, true);
			
			resultsLabel = new Label {
				Text = "",
				VerticalOptions = LayoutOptions.FillAndExpand,
				FontSize = 25,

			};



			searchBar = new SearchBar {
				Placeholder = "Enter Event",
				SearchCommand = new Command (() => {resultsLabel.Text = "Event Results: " + searchBar.Text;}),
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Start,
				Children = {
					new Label {
						HorizontalTextAlignment = TextAlignment.Center,
						Text = "Event Search",
						FontSize = 25
					},
					searchBar,
					new ScrollView {
						Content = resultsLabel,
						VerticalOptions = LayoutOptions.FillAndExpand
					}
				},
				Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5)
			};

			if (((Orientation.App)App.Current).isDarkTheme ()) {
				this.BackgroundColor = Color.FromHex ("#BBBBBB");
				searchBar.BackgroundColor = Color.FromHex ("#BBBBBB");
				searchBar.CancelButtonColor = Color.FromHex ("#303030");
			}	
		}
	}
}

