using Hazeltek.Configuration;



namespace Hazeltek.UtiliTrak.Web.Common
{
    public class ConfigProvider: IConfigProvider
    {
        public IConfig GetConfig()
        {
            return new Config { IgnoreStartupTasks = false };
        }

        private class Config: IConfig
        {
            public bool IgnoreStartupTasks { get; set; }
        }
    }


}