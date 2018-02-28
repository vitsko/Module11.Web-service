namespace HttpUtil
{
    using System.Configuration;

    public static class Config
    {
        public static string UrlToJSON => GetEnviromentVar("UrlToJSON", "https://jsonplaceholder.typicode.com/users");

        public static string CountOfUsers => GetEnviromentVar("CountOfUsers", "10");

        private static string GetEnviromentVar(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }
    }
}