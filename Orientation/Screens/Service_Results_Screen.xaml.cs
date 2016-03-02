using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Results_Screen : ContentPage
	{
		private Boolean isFavorite;

		public Service_Results_Screen (string nameString, string descriptionString, 
		                               string coordinatesString, string phoneNumberString, 
		                               string websiteString, bool favorites)
		{
			InitializeComponent ();
			setTheme ();

			name.SetBinding(Entry.TextProperty, "Name: " + nameString);
			description.SetBinding(Entry.TextProperty, "Description: " + descriptionString);
			coordinates.SetBinding(Entry.TextProperty, "Coordinates: " + coordinatesString);
			phoneNumber.SetBinding(Entry.TextProperty, "Phone Number: " + phoneNumberString);
			website.SetBinding(Entry.TextProperty,"Website: " + websiteString);
			isFavorite = favorites;
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
	}
}

