# Configurall
Make anything configurable with the Configurator pattern.

 - .Net Standard 2.1 library.

# How to use

1. Add your Attribute class.
```
public class EntityCfgAttribute : ConfiguratorAttribute
{
   -- Attribute properties (i.e. Enviroment, DeviceType)
}
```
2. Add your base configurator class.
```
public class EntityCfg: ConfiguratorAttribute
{
   // Entity configuration properties
   - Property1 
   - Property2
}
```
3. Add your custom configuration classes
```
[HostCfgAttribute(AttributeProperty1: attrValue1, AttributeProperty2: attrValue1...)]
public class CustomHostCfg11: HostCfg
{
   // Set entity configuration properties
   - Property1 = propVal1 
   - Property2 = propVal1
}
...
[HostCfgAttribute(AttributeProperty1: attrValue2, AttributeProperty2: attrValue2...)]
public class CustomHostCfg22: HostCfg
{
   // Set entity configuration properties
   - Property1 = propVal2 
   - Property2 = propVal2
}
```

4. Get one configuration by attribute.
```
var hostCfg = new ConfigurallMgr<HostCfgAttribute>(Assembly.GetExecutingAssembly());
// Configuration cached on first read
var entityCfg = hostCfg.Get<EntityCfg>(new EntityCfgAttribute(attrValue1, attrValue2)); 
```

# Simple, faster

- Cache your configuration classes.
- Simple and easy to extend less than **a hundred code lines**.

# License

Dapper Fluent Query Helper is licensed under [Apache 2.0.](https://github.com/jiman14/Configurall/blob/main/LICENSE "Apache 2.0 License")
