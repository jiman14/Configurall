# Configurall
Make anything configurable with the Configurator pattern.

 - .Net Standard 2.1 library.

# How to use

1. Add your Attribute class.
```
public class HostCfgAttribute : ConfiguratorAttribute
{
   -- Attribute properties (i.e. Enviroment, DeviceType)
}
```
3. Add your configurator classes.
```
[HostCfgAttribute(..Attributes..)]
public class HostCfg: ConfiguratorAttribute
{
   -- Configuration properties
}
```
5. Get one configuration by attribute.
```
public class HostCfgAttribute : ConfiguratorAttribute
{
   -- Attribute properties (i.e. Enviroment, DeviceType)
}
```

# Simple, faster

- Cache your configuration classes.
- Simple and easy to extend less than **a hundred code lines**.

# License

Dapper Fluent Query Helper is licensed under [Apache 2.0.](https://github.com/jiman14/Configurall/blob/main/LICENSE "Apache 2.0 License")
