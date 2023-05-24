// <copyright file="ThemesController.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Themes
{
    using System;
    using System.Windows;

    public static class ThemesController
    {
        public enum ThemeTypes
        {
            Light,
            Dark,
        }

        public static ThemeTypes CurrentTheme { get; set; }

        public static ResourceDictionary ThemeDictionary
        {
            get { return Application.Current.Resources.MergedDictionaries[0]; }
            set { Application.Current.Resources.MergedDictionaries[0] = value; }
        }

        public static void ChangeTheme(Uri uri)
        {
            ThemeDictionary = new ResourceDictionary() { Source = uri };
        }

        public static void SetTheme(ThemeTypes theme)
        {
            string themeName = null;
            switch (theme)
            {
                case ThemeTypes.Dark:
                    themeName = "DarkTheme";
                    break;
                case ThemeTypes.Light:
                    themeName = "LightTheme";
                    break;
            }

            if (themeName != null && CurrentTheme != theme)
            {
                try
                {
                    ChangeTheme(new Uri($"Themes/{themeName}.xaml", UriKind.Relative));
                    CurrentTheme = theme;
                }
                catch
                {
                }
            }
        }
    }
}
