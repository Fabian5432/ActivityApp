using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ActivityApp.Helper
{
    public class UserLocalData
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public enum DataKey
        {
            userToken,
            userId,
            logged
        }

        public static string logged
        {
            get => AppSettings.GetValueOrDefault(DataKey.logged.ToString(), string.Empty);
            set => AppSettings.AddOrUpdateValue(DataKey.logged.ToString(), value);
        }
        public static string userToken
        {
            get => AppSettings.GetValueOrDefault(DataKey.userToken.ToString(), string.Empty);
            set => AppSettings.AddOrUpdateValue(DataKey.userToken.ToString(), value);
        }

        public static string userId
        {
            get => AppSettings.GetValueOrDefault(DataKey.userId.ToString(), string.Empty);
            set => AppSettings.AddOrUpdateValue(DataKey.userId.ToString(), value);
        }

        public static void RemoveToken()
        {
            AppSettings.Remove(DataKey.userToken.ToString());
        }
        public static void RemoveUserId()
        {
            AppSettings.Remove(DataKey.userId.ToString());
        }
        public static void RemoveLogged()
        {
            AppSettings.Remove(DataKey.logged.ToString());
        }
    }


}
