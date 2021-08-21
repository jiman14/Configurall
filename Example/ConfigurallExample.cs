using Configurall.Example.Configurator;
using System;
using System.Reflection;
using System.Diagnostics;

namespace Configurall.Example
{
    public class ConfigurallExample
    {        
        public ConfigurallExample(PlatformType platform)
        {
            var hostCfg = new Configurall.Core.ConfigurallMgr<HostCfgAttribute>(Assembly.GetExecutingAssembly());

#if DEBUG
            var env = EnvironmentType.Development;
#else
            var env = EnvironmentType.Pre;
#endif
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var host = hostCfg.Get<HostCfg>(new HostCfgAttribute(platform, env));
            sw.Stop();
            Console.WriteLine($"First config read (not cached): {sw.ElapsedMilliseconds} ms");
            sw.Reset();
            sw.Start();
            host = hostCfg.Get<HostCfg>(new HostCfgAttribute(platform, env));
            sw.Stop();
            Console.WriteLine($"Second config read (cached): {sw.ElapsedMilliseconds} ms");

            Console.WriteLine($"Enviroment: {env}, platform: {platform}, host: {host.HostURL}:{host.Port}{host.ApiV1Path}");            
        }
    }
}
