using Lavid.Libraske.Util;

namespace Lavid.Libraske.Web
{
    public static class AccessData
    {
        public static string RefreshToken { get; private set; }
        public static string AccessToken { get; private set; }
        public static string UserName { get; private set; }
        public static string Email { get; private set; }
        public static Boolean IsGuest { get; private set; }

        public static void SetRefreshToken(string data) => RefreshToken = data;
        public static void SetAccessToken(string data) => AccessToken = data;
        public static void SetUserName(string data) => UserName = data;
        public static void SetEmail(string data) => Email = data;
        public static void SetIsGuest(Boolean data) => IsGuest = new Boolean(data);

        public static new string ToString()
        {
            return $"[AccessData]: Current Data \n" +
                   $"UserName: {UserName} \n" +
                   $"Email: {Email} \n" +
                   $"Refresh Token: {RefreshToken} \n" +
                   $"Access Token: {AccessToken} \n" +
                   $"IsGuest: {(bool)IsGuest}";
        }
    }
}