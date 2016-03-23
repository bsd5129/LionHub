using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;
using XLabs.Platform.Services.Geolocation;
using System.Threading.Tasks;
using System.Threading;

using Plugin.Geolocator;

namespace Orientation
{
	public partial class Where_Am_I_Screen : ContentPage
	{
		
		public Where_Am_I_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasBackButton (this, false);

			setTheme ();
			getCurrentLocation();
		}

		public void setTheme()
		{
			centerLayout.BackgroundColor = Theme.getBackgroundColor();
			stackLayout.BackgroundColor = Theme.getBackgroundColor();
			searchingLabel.TextColor = Theme.getTextColor();
			indicator.Color = Theme.getTextColor();
		}

		public async void getCurrentLocation()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 5;
			var position = await locator.GetPositionAsync(timeoutMilliseconds: (1000 * 60 * 2));
			float curLat = (float)position.Latitude;
			float curLon = (float)position.Longitude;

			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
			var latlong = connection.Table<Service>().OrderBy(s => s.coordinatesLatitude);
			Service nearestBuildingInfo = null;
			float tmpLat = 0, tmpLon = 0;
			float tmpVal= float.MaxValue;

			foreach (var latLon in latlong)
			{
				if (latLon.coordinatesLatitude.Equals(null)|| latLon.coordinatesLongitude.Equals(null))
					continue;
				tmpLat = Math.Abs(latLon.coordinatesLatitude - curLat);
				tmpLon = Math.Abs(latLon.coordinatesLongitude - curLon);
				tmpLat += tmpLon;
				if (tmpLat < tmpVal)
				{
					tmpVal = tmpLat;
					nearestBuildingInfo = latLon;
				}
			}
			connection.Close();

			float dist = coordToMeters(curLat, curLon, nearestBuildingInfo.coordinatesLatitude, nearestBuildingInfo.coordinatesLongitude);

			await DisplayAlert("DEBUG", "You are: " + dist, "Ok");

			if (dist > 1600) {
				await DisplayAlert("Too Far Away", "You are too far away from the PSU Harrisburg Campus", "Ok");
				await ((NavigationPage)App.Current.MainPage).PopAsync();
			} else {
				await ((NavigationPage)App.Current.MainPage).PopAsync();
				await ((NavigationPage)App.Current.MainPage).PushAsync(new Service_Search_Screen());
				await ((NavigationPage)App.Current.MainPage).PushAsync(new Service_Results_Screen(nearestBuildingInfo));
			}
		}


		public float coordToMeters(float lat1, float lon1, float lat2, float lon2)
		{
			float dLat = (lat2 - lat1) * (float)(Math.PI / 180);
			float dLon = (lon2 - lon1) * (float)(Math.PI / 180);
			float A = (float)(Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
			                  + Math.Cos(lat1 * (float)(Math.PI / 180)) * Math.Cos(lat2 * (float)(Math.PI / 180))
			                  * Math.Sin(dLon / 2) * Math.Sin(dLon/2));

			float C = (float)(2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1 - A)));
			return 6367 * C * 1000;
		}
	}
}

