namespace GBUtils.Configuration
{
    using System.Collections.Specialized;

    public interface IConfigurationManager
    {
        NameValueCollection AppSettings
        {
            get;
        }

        string GetSafeSetting(string key);

        string ConnectionStrings(string name);

        T GetSection<T>(string sectionName);

        int GetSafeIntSetting(string key, int valueWhenNotFound);
    }
}
