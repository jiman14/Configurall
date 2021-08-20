using Configurall.Core;

namespace Configurall.Example
{
    public enum PlatformType
    {
        Android,
        IOS,
        Desktop
    }
    public enum EnvironmentType
    {
        Develop,
        Pre,
        Pro
    }
    public class HostCfg : BaseConfigurator
    {
        public string BOHostURL { get; internal set; }
        public int Port { get; private set; } = 5001;
        public string ApiV1Path { get; private set; } = "api/v1/";
        public string ApiV2Path { get; private set; } = "api/v2/";
    }

    #region Dev

    [HostCfgAttribute(PlatformType.Android, EnvironmentType.Develop)]
    public class DevAndroidHostCfg : HostCfg
    {
        public DevAndroidHostCfg() => BOHostURL = $"https://10.0.2.2:{Port}/";
    }
    [HostCfgAttribute(PlatformType.Desktop, EnvironmentType.Develop)]
    public class DevUWPHostCfg : HostCfg
    {
        public DevUWPHostCfg() => BOHostURL = $"https://localhost:{Port}/";
    }
    [HostCfgAttribute(PlatformType.IOS, EnvironmentType.Develop)]
    public class DevIOSHostCfg : DevUWPHostCfg { }
    #endregion

    #region Pre

    [HostCfgAttribute(PlatformType.Android, EnvironmentType.Pre)]
    public class PreAndroidHostCfg : HostCfg
    {
        public PreAndroidHostCfg() => BOHostURL = $"https://configualltest.pre.com:{Port}/";
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
        public ProAndroidHostCfg() => BOHostURL = $"https://configuralltest.com:{Port}/";
    }

    [HostCfgAttribute(PlatformType.Desktop, EnvironmentType.Pro)]
    public class ProUWPHostCfg : ProAndroidHostCfg { }
        
    [HostCfgAttribute(PlatformType.IOS, EnvironmentType.Pro)]
    public class ProIOSHostCfg : ProAndroidHostCfg { }
    #endregion
}