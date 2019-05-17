namespace SAC.Munin.Infrastructure.Motification
{
    using System.Configuration;
    public static class Settings
    {
        public static string DefaultEmailTo
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultEmailTo"];
            }
        }
        public static string DefaultEmailFrom
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultEmailFrom"];
            }
        }
        public static string SmtpUser
        {
            get
            {
                return ConfigurationManager.AppSettings["SmtpUser"];
            }
        }
        public static string SmtpPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["SmtpPassword"];
            }
        }
        public static string SmtpServerHost
        {
            get
            {
                return ConfigurationManager.AppSettings["SmtpServerHost"];
            }
        }
        public static bool SmtpEnableSsl
        {
            get
            {
                bool result;
                bool.TryParse(ConfigurationManager.AppSettings["SmtpEnableSsl"], out result);
                return result;
            }
        }
        public static int SmtpMailPort
        {
            get
            {
                int result;
                int.TryParse(ConfigurationManager.AppSettings["SmtpMailPort"], out result);

                return result;
            }
        }
    }
}
