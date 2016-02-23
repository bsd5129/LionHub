using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Orientation.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App (new Xamarin.Forms.Size(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height)));

			return base.FinishedLaunching (app, options);
		}
	}
}

