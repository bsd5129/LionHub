using System;
using System.Collections.Generic;
using SQLite.Net;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Results_Screen : ContentPage
	{
    private Service serviceObject;

		public Service_Results_Screen (Service service)
		{
			InitializeComponent ();
			setTheme ();

      serviceObject = service;
      Title = service.name;
      name.Text = "";//"Name: " + service.name;
      description.Text = "Description: " + service.description;
      coordinates.Text = "Coordinates: " + service.coordinatesLatitude + ", " + service.coordinatesLongitude;
      phoneNumber.Text = "Phone Number: " + service.phoneNumber;
      website.Text = "Website: " + service.website;

      //Disable favorites button if the service is already a favorite
      favoritesButton.IsEnabled = !service.isFavorite;

      if (service.coordinatesLatitude <= -999.0 && service.coordinatesLongitude <= -999.0) {
        buttons.Children.Remove(takeMeThereButton);
      }
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
      displayPrompt();
    }

		public void setFavoritesFlagToTrue() {
      serviceObject.isFavorite = true;

      SQLiteConnection con = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      con.Update(serviceObject);
      con.Close();
		}

    public async void displayPrompt()
    {
      var answer = await DisplayAlert ("Add To Favorites?", "Would you like to add this Service to your Favorites?", "Yes", "No");

      if (answer.Equals("Yes"))
        pressYesOnPrompt();
      else
        pressNoOnPrompt();
    }   


    public void pressYesOnPrompt()
    {
      setFavoritesFlagToTrue();

      NavigationPage page = new NavigationPage(new Home_Screen());
      page.PushAsync(new Favorites_Screen());
      App.Current.MainPage = page;
    }   


    public void pressNoOnPrompt()
    {
      
    }
	}
}

