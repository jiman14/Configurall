using Configurall.Core;

namespace Configurall.Example.Configurator
{
    public enum PlatformType
    {
        Android,
        IOS,
        Desktop
    }
    public enum EnvironmentType
    {
        Development,
        Pre,
        Pro
    }
    public class HostCfg : ConfiguratorBase
    {
        public string HostURL { get; internal set; }
        public int Port { get; private set; } = 5001;
        public string ApiV1Path { get; private set; } = "/api/v1";
        public string ApiV2Path { get; private set; } = "/api/v2";
    }

    #region Dev

    [HostCfgAttribute(PlatformType.Android, EnvironmentType.Development)]
    public class DevAndroidHostCfg : HostCfg
    {
        // Variables configuration for Platform Android, Env: Development
        public DevAndroidHostCfg()
        {            
            HostURL = $"https://10.0.2.2";
        }
    }
    [HostCfgAttribute(PlatformType.Desktop, EnvironmentType.Development)]
    public class DevUWPHostCfg : HostCfg
    {
        // Variables configuration for Platform Desktop, Env: Development
        public DevUWPHostCfg()
        {
            HostURL = $"https://localhost";
        }
    }
    [HostCfgAttribute(PlatformType.IOS, EnvironmentType.Development)]
    public class DevIOSHostCfg : DevUWPHostCfg { } // Variables configuration for Platform IOS, Env: Development inherits from desktop version
    #endregion

    #region Pre

    [HostCfgAttribute(PlatformType.Android, EnvironmentType.Pre)]
    public class PreAndroidHostCfg : HostCfg
    {        
        public PreAndroidHostCfg() => HostURL = $"https://configualltest.pre.com";
    }

    [HostCfgAttribute(PlatformType.Desktop, EnvironmentType.Pre)]
    public class PreUWPHostCfg : PreAndroidHostCfg { }

    [HostCfgAttribute(PlatformType.IOS, EnvironmentType.Pre)]
    public class PreIOSHostCfg : PreAndroidHostCfg { }
    #endregion

    #region Pro

    [HostCfgAttribute(PlatformType.Android, EnvironmentType.Pro)]
    public class ProAndroidHostCfg : HostCfg
    {
        public ProAndroidHostCfg() => HostURL = $"https://configuralltest.com";
    }

    [HostCfgAttribute(PlatformType.Desktop, EnvironmentType.Pro)]
    public class ProUWPHostCfg : ProAndroidHostCfg { }
        
    [HostCfgAttribute(PlatformType.IOS, EnvironmentType.Pro)]
    public class ProIOSHostCfg : ProAndroidHostCfg { }
    #endregion
}