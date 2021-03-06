﻿using System;
using SQLite.Net;
using Xamarin.Forms;
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
      Plugin.Geolocator.Abstractions.Position position = null;

      try {
        position = await locator.GetPositionAsync(timeoutMilliseconds: (1000 * 60 * 2));
      } catch (Exception) {
        await DisplayAlert("GPS is Disabled", "You must enable GPS to use this feature", "OK");
        await ((NavigationPage)App.Current.MainPage).PopAsync();
        return;
      }

      float curLat = (float)position.Latitude;
			float curLon = (float)position.Longitude;

			SQLiteConnection connection = DependencyService.Get<IDatabaseHandler>().getDBConnection();
      var services = connection.Table<Service>().Where(s => s.coordinatesLatitude > -998.0f);
			
      Service nearestBuildingInfo = null;
      float minDistance = float.MaxValue;

			foreach (var service in services)
			{
        float dist = distanceFrom(curLat, curLon, service.coordinatesLatitude, service.coordinatesLongitude);

        if (dist < minDistance)
				{
          minDistance = dist;
					nearestBuildingInfo = service;
				}
			}
			connection.Close();

      if (minDistance > 400) {
				await DisplayAlert("Too Far Away", "You are too far away from the PSU Harrisburg Campus", "OK");
				await ((NavigationPage)App.Current.MainPage).PopAsync();
			} else {
				await ((NavigationPage)App.Current.MainPage).PopAsync();
				await ((NavigationPage)App.Current.MainPage).PushAsync(new Service_Search_Screen(null));
        await ((NavigationPage)App.Current.MainPage).PushAsync(new Service_Search_Screen(nearestBuildingInfo.category));
				await ((NavigationPage)App.Current.MainPage).PushAsync(new Service_Results_Screen(nearestBuildingInfo));
			}
		}


		public float distanceFrom(float lat1, float lon1, float lat2, float lon2)
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

