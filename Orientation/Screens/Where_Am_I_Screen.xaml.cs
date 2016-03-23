using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;
using XLabs.Platform.Services.Geolocation;
using System.Threading.Tasks;
using System.Threading;
namespace Orientation
{
	public partial class Where_Am_I_Screen : ContentPage
	{
		
		public Where_Am_I_Screen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasBackButton (this, false);

			setTheme ();
			GetPosition();
		}

		public void setTheme()
		{
			centerLayout.BackgroundColor = Theme.getBackgroundColor();
			stackLayout.BackgroundColor = Theme.getBackgroundColor();
			searchingLabel.TextColor = Theme.getTextColor();
			indicator.Color = Theme.getTextColor();
		}

		public async void GetPosition()
		{
			IGeolocator geolocator = DependencyService.Get<IGeolocator>();

			CancellationTokenSource cancelSource = new CancellationTokenSource();

			await geolocator.GetPositionAsync(timeout: 10000, cancelToken: cancelSource.Token, includeHeading: true).ContinueWith(t => {
				if (t.IsFaulted)
				{
					DisplayAlert("BAD", ((GeolocationException)t.Exception.InnerException).Error.ToString(), "OH NO!");
				}
				else if (t.IsCanceled) {
					DisplayAlert("CANCELED", "FUCK", "OH NO!");
				}
				else
				{
					//PositionLatitude = "La: " + t.Result.Latitude;
					//PositionLongitude = "Lo: " + t.Result.Longitude;
					DisplayAlert("SUP", "SUP" , "OKAY");
					getCurrentLocation((float)t.Result.Latitude,(float)t.Result.Longitude);
				}

			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		public void getCurrentLocation(float curLat, float curLon) 
		{
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

			//Replace 0 with the current location, latitude and longitude
			tmpVal = coordToMeters(curLat,nearestBuildingInfo.coordinatesLatitude,curLon,nearestBuildingInfo.coordinatesLongitude);
			connection.Close();
			if (Device.OS == TargetPlatform.Android)
			{
				Device.OpenUri(new Uri("geo:0,0"+ "?q=" + nearestBuildingInfo.coordinatesLatitude + "," + nearestBuildingInfo.coordinatesLongitude));
			}
			else if (Device.OS == TargetPlatform.iOS)
			{
				Device.OpenUri(new Uri("http://maps.apple.com/?daddr=" + nearestBuildingInfo.coordinatesLatitude + "," + nearestBuildingInfo.coordinatesLongitude + "&saddr= Current%20Location"));
			}
			
		}


		public float coordToMeters(float startLat, float destLat, float startLong, float destLong)
		{
			float R = 6378.137F;
			float dLat = (destLat - startLat) * (float)(Math.PI / 180);
			float dLon = (destLong - startLong) * (float)(Math.PI / 180);
			float A = (float)(Math.Sin(dLat / 2) * Math.Sin(dLat / 2) * Math.Cos(startLat * Math.PI / 180) * Math.Cos(destLat * Math.PI / 180)
			                  * Math.Sin(dLon / 2) * Math.Sin(dLon/2));

			float C = (float)(2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1 - A)));
			float D = R * C;

			return D * 1000;
		}
	}
}

