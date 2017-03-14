using System.Configuration;
using System.IO;
using TestWcfCommon;

namespace WebClientMVC
{
        // создаю класс конфигурации, дабы не тянуть всю сборку TestWcfService
        public class Config : ConfigurationSection
        {
            static Config _instance;

            public static Config Get
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = ConfigurationManager.GetSection("serviceConfig") as Config;
                    }
                    return _instance;
                }
            }

            [ConfigurationProperty("log", IsRequired = false)]
            public LogElement Log
            {
                get { return (LogElement)this["log"]; }
            }
        }

        public class LogElement : ConfigurationElement
        {
            [ConfigurationProperty("dir", DefaultValue = "Log", IsRequired = false)]
            public string Dir
            {
                get
                {
                    string ret = (string)this["dir"] ?? string.Empty;

                    if (!Path.IsPathRooted(ret))
                        ret = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Log");
                    return ret;
                }
            }

            [ConfigurationProperty("level", DefaultValue = Level.Trace, IsRequired = false)]
            public Level Level
            {
                get
                {
                    return (Level)this["level"];
                }
            }

            [ConfigurationProperty("prefix", DefaultValue = "", IsRequired = false)]
            public string Prefix
            {
                get
                {
                    var hostName = System.Net.Dns.GetHostName();
                    return (string)this["prefix"] == null ? hostName : (string)this["prefix"] + "_" + hostName;
                }
            }
        }
    }


