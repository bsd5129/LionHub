using System;

using Xamarin.Forms;

namespace Orientation
{
	public class Theme
	{
		private static bool isDark = false;

		private static Color lightThemeBackgroundColor = Color.FromHex("#EEEEEE");
		private static Color lightThemeTextColor = Color.FromHex("#000000");

		private static Color darkThemeBackgroundColor = Color.FromHex("#303030");
		private static Color darkThemeTextColor = Color.FromHex("#BBBBBB");

		public static Color getBackgroundColor() {
			if (isDark)
				return darkThemeBackgroundColor;
			else
				return lightThemeBackgroundColor;
		}

		public static Color getTextColor() {
			if (isDark)
				return darkThemeTextColor;
			else
				return lightThemeTextColor;
		}

		public static void setDarkTheme(bool darkTheme) {
			isDark = darkTheme;
		}

		public static bool isDarkTheme() {
			return isDark;
		}
	}
}

