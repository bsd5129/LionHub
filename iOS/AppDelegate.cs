using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Platform.Services.Geolocation;

namespace Orientation.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : XFormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App (new Xamarin.Forms.Size(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height)));

			return base.FinishedLaunching (app, options);
		}
	}
}

