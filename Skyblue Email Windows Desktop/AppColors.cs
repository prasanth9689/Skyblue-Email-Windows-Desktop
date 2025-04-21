using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyblue_Email_Windows_Desktop
{
    public static class AppColors
    {
        public static Color Primary = Color.FromArgb(41, 113, 252);      // Blue
        public static Color Secondary = Color.FromArgb(156, 39, 176);    // Purple
        public static Color Success = Color.FromArgb(76, 175, 80);       // Green
        public static Color Danger = Color.FromArgb(244, 67, 54);        // Red
        public static Color Background = Color.White;
        public static Color Foreground = Color.Black;

        // Optional: Add a method for dynamic theming
        public static void SetDarkTheme()
        {
            Background = Color.FromArgb(30, 30, 30);
            Foreground = Color.White;
        }

        public static void SetLightTheme()
        {
            Background = Color.White;
            Foreground = Color.Black;
        }
    }

}
