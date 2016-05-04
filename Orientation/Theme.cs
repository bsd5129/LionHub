using System;

using Xamarin.Forms;

namespace Orientation
{
  public class Theme {
    private static int activeThemeIndex = 0;
    private static Theme[] themes = {
      new Theme("Normal", "#EEEEEE", "#000000", "#FFFFFF", "#BBBBBB", "#0000EE", false),
      new Theme("Dark 1", "#303030", "#BBBBBB", "#BBBBBB", "#303030", "#007AFF", true),
      new Theme("Dark 2", "#000000", "#FFFFFF", "#FFFFFF", "#303030", "#007AFF", true)
    };

    private String name;
    private Color backgroundColor;
    private Color textColor;
    private Color entryColor;
    private Color entryPlaceholderColor;
    private Color linkColor;
    private bool isDark;

    private Theme(string name, string background, string text, string entry, string entryPlaceholder, string link, bool dark) {
      this.name = name;
      backgroundColor = Color.FromHex(background);
      textColor = Color.FromHex(text);
      entryColor = Color.FromHex(entry);
      entryPlaceholderColor = Color.FromHex(entryPlaceholder);
      linkColor = Color.FromHex(link);
      isDark = dark;
    }

    public static string getActiveThemeName() {
      return themes[activeThemeIndex].name;
    }

		public static Color getBackgroundColor() {
      return themes[activeThemeIndex].backgroundColor;
		}

		public static Color getTextColor() {
      return themes[activeThemeIndex].textColor;
		}

		public static Color getEntryColor() {
      return themes[activeThemeIndex].entryColor;
		}

		public static Color getEntryPlaceholderColor() {
      return themes[activeThemeIndex].entryPlaceholderColor;
		}

    public static Color getLinkColor() {
      return themes[activeThemeIndex].linkColor;
    }

		public static void cycleTheme() {
      activeThemeIndex++;

      if (activeThemeIndex >= themes.Length)
        activeThemeIndex = 0;
		}

    public static bool isDarkTheme() {
      return themes[activeThemeIndex].isDark;
    }
	}
}

