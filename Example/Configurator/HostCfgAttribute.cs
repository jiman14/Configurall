using Configurall.Core;
using System;

namespace Configurall.Example.Configurator
{
    public class HostCfgAttribute : ConfiguratorAttribute
    {
        private PlatformType Platform { get; set; }
        private EnvironmentType Environment { get; set; }
        public HostCfgAttribute(PlatformType platform, EnvironmentType environment)
        {
            Platform = platform;
            Environment = environment;
        }
        public override bool Match(ConfiguratorAttribute configuration)
            => (configuration as HostCfgAttribute).Platform == Platform &&
               (configuration as HostCfgAttribute).Environment == Environment;
        public override string GetKey() => $"{Platform}.{Environment}";
    }
}
