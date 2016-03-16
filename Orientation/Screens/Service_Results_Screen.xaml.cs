using System;
using System.Collections.Generic;
using SQLite.Net;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Results_Screen : ContentPage
	{
		private Service serviceObject;

		public Service_Results_Screen(Service service)
		{
			InitializeComponent();
			setTheme();

			serviceObject = service;
			//Title = service.name;
			name.Text = service.name;
			description.Text = service.description;

			if (service.coordinatesLatitude <= -999.0)
				coordinates.Text = "N/A";
			else
				coordinates.Text = service.coordinatesLatitude + ", " + service.coordinatesLongitude;

			phoneNumber.Text = service.phoneNumber;

      if (phoneNumber.Text.Length == 0) {
        phoneNumber.Text = "N/A";
      } else {
        //Make the phoneNumber label clickable
        var phoneNumber_tap = new TapGestureRecognizer();
        phoneNumber_tap.Tapped += (sender, eventArgs) => {
          pressPhoneNumber();
        };
        phoneNumber.GestureRecognizers.Add(phoneNumber_tap);
      }

			website.Text = service.website;

			if (website.Text.Length == 0)
				website.Text = "N/A";

			//Disable favorites button if the service is already a favorite
			favoritesButton.IsEnabled = !service.isFavorite;

			if (service.coordinatesLatitude <= -999.0 && service.coordinatesLongitude <= -999.0)
			{
				buttons.Children.Remove(takeMeThereButton);
			}
<<<<<<< HEAD
=======

			//make the phoneNumber label clickable
			// Your label tap event
			var phoneNumber_tap = new TapGestureRecognizer();
			phoneNumber_tap.Tapped += (s, e) =>
			{
				pressPhoneNumber();
		    };
			phoneNumber.GestureRecognizers.Add(phoneNumber_tap);


			var website_tap = new TapGestureRecognizer();
			website_tap.Tapped += (sender, e) =>
			{
				pressWebsite();
			};
			website.GestureRecognizers.Add(website_tap);
>>>>>>> f0267e1... Added websit connect functionality
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			name.TextColor = Theme.getTextColor();
			description.TextColor = Theme.getTextColor();
			coordinates.TextColor = Theme.getTextColor();
			//phoneNumber.TextColor = Theme.getTextColor();
			//website.TextColor = Theme.getTextColor();
		}

		public void pressAddToFavoritesButton(Object sender, EventArgs e)
		{
			displayPrompt();
		}

		public void setFavoritesFlagToTrue()
		{
			serviceObject.isFavorite = true;

			SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			con.Update(serviceObject);
			con.Close();
		}

		public async void displayPrompt()
		{
			var answer = await DisplayAlert("Add To Favorites?", "Would you like to add this Service to your Favorites?", "Yes", "No");

			if (answer)
				pressYesOnPrompt();
			else
				pressNoOnPrompt();
		}

		public void pressNoOnPrompt()
		{
			
		}

		public void pressYesOnPrompt()
		{
			setFavoritesFlagToTrue();

			NavigationPage page = new NavigationPage(new Home_Screen());
			page.PushAsync(new Favorites_Screen());
			((Orientation.App)App.Current).setMainPage(page);
		}

		public async void pressPhoneNumber()
		{
      if (await DisplayAlert("Call Number?", "Would you like to dial this number?", "Yes", "No"))
        Device.OpenUri(new Uri("tel://" + phoneNumber.Text.Replace("-", "")));
		}

		public void pressTakeMeThere(Object sender, EventArgs e)
		{ 
			if (Device.OS == TargetPlatform.Android)
			{
				Device.OpenUri(new Uri("geo:"+serviceObject.coordinatesLatitude+","+serviceObject.coordinatesLongitude));

			}
			else if (Device.OS == TargetPlatform.iOS)
			{
				Device.OpenUri(new Uri("http://maps.apple.com/?daddr=" + serviceObject.coordinatesLatitude+"," + serviceObject.coordinatesLongitude+",&saddr=Current%20Location"));
			}
		}

		public void pressWebsite()
		{
			if (website.Text != "N/A")
				Device.OpenUri(new Uri(website.Text));
		}

	}
}

