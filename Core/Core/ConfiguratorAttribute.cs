using System;

namespace Configurall.Core
{
    public abstract class ConfiguratorAttribute: Attribute
    {
        public virtual bool Match(ConfiguratorAttribute configuration) => throw new NotImplementedException("Base 'public virtual bool Match(ConfiguratorAttribute configuration);' method should be overridden with custom Match method.");
        public virtual string GetKey() => throw new NotImplementedException("Base 'public virtual string GetKey();' method should be overridden for getting a unique Key per attribute.");
    }
}