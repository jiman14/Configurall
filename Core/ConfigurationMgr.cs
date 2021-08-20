using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Configurall.Core
{
    [Serializable]
    public class ConfigurallMgr<A> where A: ConfiguratorAttribute
    {
        private bool ExceptionOnNotFound { get; set; } = false;

        static ConcurrentDictionary<string, IEnumerable<Type>> Assemblies = new ConcurrentDictionary<string, IEnumerable<Type>>();
        static ConcurrentDictionary<string, object> CfgObjects = new ConcurrentDictionary<string, object>();
        private Assembly _assembly;

        public ConfigurallMgr(Assembly assembly, bool exceptionOnNotFound=false)
        {
            _assembly = assembly;
            ExceptionOnNotFound = exceptionOnNotFound;
        }
        
        public T Get<T>(A attribute)
            where T : BaseConfigurator
        {            
#if !DEBUG
            if (ConfigObjs.TryGetValue(attribute.GetKey(), out object obj))
                return (T)obj;
#endif
            if (!Assemblies.TryGetValue(attribute.GetKey(), out IEnumerable<Type> configuratorAttribTypes))
            {
                configuratorAttribTypes =
                    from assemblyType in _assembly.GetTypes()
                    where assemblyType.IsDefined(typeof(A), true)
                    select assemblyType;

                Assemblies.TryAdd(attribute.GetKey(), configuratorAttribTypes);
            }

            var configurationTypes = configuratorAttribTypes
                .Where(c => attribute.Match(c.GetCustomAttribute(typeof(A), true)));

            if (!ExceptionOnNotFound && !configurationTypes.Any())
            {
#if !DEBUG
                ConfigObjs.TryAdd(attribKey, null);
#endif
                return null;
            }

            if (configurationTypes.Count() != 1)
                throw new Exception($"One configuration for attributes '{attribute.GetKey()}' expected, founded: {configurationTypes.Count()}.");

            T newObj = (T)Activator.CreateInstance(configurationTypes.First());

#if !DEBUG
            ConfigObjs.TryAdd(attribute.GetKey(), newObj);
#endif
            return (T)newObj;
        }
        public void ClearCache(params A[] attributes)
        {
            if (attributes.Count() == 0)
            {
                CfgObjects.Clear();
                return;
            }
            attributes.ToList().ForEach(a => 
                CfgObjects.TryRemove(a.GetKey(), out object value));
        }
    }
}