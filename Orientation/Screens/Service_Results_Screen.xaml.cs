using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Orientation
{
	public partial class Service_Results_Screen : ContentPage
	{
		public Service_Results_Screen ()
		{
			InitializeComponent ();
			setTheme ();
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

