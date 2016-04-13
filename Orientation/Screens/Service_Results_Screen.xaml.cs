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

      NavigationPage.SetBackButtonTitle(this, "Back");

			serviceObject = service;
			Title = service.name;
			name.Text = service.name;
			description.Text = service.description;
			phoneNumber.Text = service.phoneNumber;
      website.Text = service.website;

      if (phoneNumber.Text.Length == 0) {
        phoneNumber.Text = "N/A";
      } else {
        //Make the phoneNumber label clickable
        var phoneNumber_tap = new TapGestureRecognizer();
        phoneNumber_tap.Tapped += (sender, eventArgs) => {
          pressOnServicePhoneNumber();
        };
        phoneNumber.GestureRecognizers.Add(phoneNumber_tap);
      }

      if (website.Text.Length == 0) {
        website.Text = "N/A";
      } else {
        //Make the website label clickable
        var website_tap = new TapGestureRecognizer();
        website_tap.Tapped += (sender, eventArgs) => {
          pressOnServiceWebsiteURL();
        };
        website.GestureRecognizers.Add(website_tap);
      }

			//Disable favorites button if the service is already a favorite
			favoritesButton.IsEnabled = !service.isFavorite;

			if (service.coordinatesLatitude <= -999.0 && service.coordinatesLongitude <= -999.0)
			{
				buttons.Children.Remove(takeMeThereButton);
			}
		}

		public void setTheme()
		{
			BackgroundColor = Theme.getBackgroundColor();
			name.TextColor = Theme.getTextColor();
			description.TextColor = Theme.getTextColor();
		}

		public async void pressAddToFavoritesButton(Object sender, EventArgs e)
		{
      if (await DisplayAlert("Add To Favorites?", "Would you like to add this Service to your Favorites?", "Yes", "No"))
        pressYesOnPrompt();
		}

		public void setFavoritesFlagToTrue()
		{
			serviceObject.isFavorite = true;

      //UPDATE Services SET favoriteFlag=true WHERE _id=##;
			SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			con.Update(serviceObject);
			con.Close();
		}

		public void pressYesOnPrompt()
		{
			setFavoritesFlagToTrue();

			NavigationPage page = new NavigationPage(new Home_Screen());
			page.PushAsync(new Favorites_Screen());
			((Orientation.App)App.Current).setMainPage(page);
		}

		public async void pressOnServicePhoneNumber()
		{
      		if (await DisplayAlert("Call Number?", "Would you like to dial this number?", "Yes", "No"))
            DependencyService.Get<IDialer>().dial(phoneNumber.Text.Replace("-", ""));
		}

		public void pressTakeMeThere(Object sender, EventArgs e)
		{ 
			if (Device.OS == TargetPlatform.Android)
			{
        Device.OpenUri(new Uri("google.navigation:q=" + serviceObject.coordinatesLatitude + "," + serviceObject.coordinatesLongitude));
			}
			else if (Device.OS == TargetPlatform.iOS)
			{
				Device.OpenUri(new Uri("http://maps.apple.com/?daddr=" + serviceObject.coordinatesLatitude+"," + serviceObject.coordinatesLongitude+",&saddr=Current%20Location"));
			}
		}

    public void pressOnServiceWebsiteURL() {
      Navigation.PushAsync(new Web_Screen(serviceObject.name, serviceObject.website));
    }
	}
}

