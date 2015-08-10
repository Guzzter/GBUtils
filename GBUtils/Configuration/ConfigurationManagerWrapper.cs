namespace GBUtils.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Text;

    public class ConfigurationManagerWrapper : IConfigurationManager
    {
        public NameValueCollection AppSettings
        {
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }

        public string ConnectionStrings(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public T GetSection<T>(string sectionName)
        {
            return (T)ConfigurationManager.GetSection(sectionName);
        }

        public string GetSafeSetting(string key)
        {
            if (string.IsNullOrWhiteSpace(key) || this.AppSettings == null || this.GetSafeSetting(key) == null)
                return "";
            return this.AppSettings[key];
        }

        public int GetSafeIntSetting(string key, int valueWhenNotFound)
        {
            int setting = 0;
            if (int.TryParse(ConfigurationManager.AppSettings[key], out setting))
            {
                return setting;
            }
            return valueWhenNotFound;
        }
    }
}
