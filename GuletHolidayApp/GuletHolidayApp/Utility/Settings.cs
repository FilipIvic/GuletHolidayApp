using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace GuletHolidayApp.Utility
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string usernameKey = "username_key";
        private const string passwordKey = "password_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string LastUsedUsername
        {
            get
            {
                return AppSettings.GetValueOrDefault(usernameKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(usernameKey, value);
            }
        }
        public static string LastUsedPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault(passwordKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(passwordKey, value);
            }
        }

    }
}
