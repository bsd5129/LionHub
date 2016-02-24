using System;

using Xamarin.Forms;

namespace Orientation
{
	public class Theme
	{
		private static bool isDark = false;

		private static Color lightThemeBackgroundColor = Color.FromHex("#EEEEEE");
		private static Color lightThemeTextColor = Color.FromHex("#000000");
		private static Color lightThemeEntryColor = Color.FromHex("#FFFFFF");
		private static Color lightThemeEntryPlaceholderColor = Color.FromHex("#BBBBBB");


		private static Color darkThemeBackgroundColor = Color.FromHex("#303030");
		private static Color darkThemeTextColor = Color.FromHex("#BBBBBB");
		private static Color darkThemeEntryColor = Color.FromHex("#BBBBBB");
		private static Color darkThemeEntryPlaceholderColor = Color.FromHex("#303030");

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

		public static Color getEntryColor() {
			if (isDark)
				return darkThemeEntryColor;
			else
				return lightThemeEntryColor;
		}

		public static Color getEntryPlaceholderColor() {
			if (isDark)
				return darkThemeEntryPlaceholderColor;
			else
				return lightThemeEntryPlaceholderColor;
		}

		public static void setDarkTheme(bool darkTheme) {
			isDark = darkTheme;
		}

		public static bool isDarkTheme() {
			return isDark;
		}
	}
}

