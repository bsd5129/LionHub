using System;

using Android.App;
using Android.Content.PM;
using Android.OS;

using XLabs.Forms;

namespace Orientation.Droid
{
	[Activity(Label = "LionHub", Icon = "@drawable/ic_launcher", Theme = "@android:style/Theme.Holo.Light", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsApplicationDroid
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			global::Xamarin.Forms.Forms.Init(this, bundle);
			global::Xamarin.Forms.Forms.SetTitleBarVisibility(Xamarin.Forms.AndroidTitleBarVisibility.Never);
			LoadApplication(new App(new Xamarin.Forms.Size((int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density), (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density))));
		}
	}
}

