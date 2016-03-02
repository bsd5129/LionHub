using System.Collections.Generic;
using System;
using SQLite.Net;
using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Results_Screen : ContentPage
	{
		private Boolean favoritesFlag = false;


		Service data ;
		              
		public Service_Results_Screen (string nameString, string descriptionString, 
		                               string coordinatesString, string phoneNumberString, 
		                               string websiteString,bool favorites)
		{
			InitializeComponent ();
			setTheme ();

			name.SetBinding(Entry.TextProperty, "Name: " + nameString);
			description.SetBinding(Entry.TextProperty, "Description: " + descriptionString);
			coordinates.SetBinding(Entry.TextProperty, "Coordinates: " + coordinatesString);
			phoneNumber.SetBinding(Entry.TextProperty, "Phone Number: " + phoneNumberString);
			website.SetBinding(Entry.TextProperty,"Website: " + websiteString);
			data = new Service {name = nameString, description = descriptionString, phoneNumber = phoneNumberString, website = websiteString};

			//FavoritesButton.Clicked += pressAddToFavoritesButton;
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor ();
			name.TextColor = Theme.getTextColor();
			description.TextColor = Theme.getTextColor();
			coordinates.TextColor = Theme.getTextColor();
			phoneNumber.TextColor = Theme.getTextColor();
			website.TextColor = Theme.getTextColor();
		}

		public void pressAddToFavoritesButton(Object sender, EventArgs e) {
			setFavoritesFlagToTrue();

			SQLiteConnection conn = DependencyService.Get<IDatabaseHandler>().getDBConnection();

			conn.CreateTable<Service>();

			conn.Insert(data);


		}

		public void setFavoritesFlagToTrue() {
			favoritesFlag = true;
		}

		public void displayPrompt() {
			
		}
		public void pressYesOnPrompt() { }
		public void pressNoOnePrompt() { }



	}
}

