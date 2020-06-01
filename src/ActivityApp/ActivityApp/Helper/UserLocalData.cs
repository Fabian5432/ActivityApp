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
            userId
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
    }


}
