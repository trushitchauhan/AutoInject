# DIAutoInjector: Attribute-based Dependency Injection
Auto dependency is a package to make dependency injection attribute-based, which registers dependencies based on attributes, is easy to manage, and forgets to mention dependencies in Startup.cs/Program.cs.

## How to get started:
### Register the DIAutoInjector installer module into Startup.cs/Program.cs file:
```
builder.Services.RegisterDIAutoInjector(ServiceLifetime defaultServiceLifetime = ServiceLifetime.Transient);
```
> defaultServiceLifetime is a parameter where you can define the default scope of the dependencies to be registered.

### Apply [Injectable] attribute to the dependency class and that will automatically register your dependency into the IoC container. This will auto-register your dependency into the IoC container with the defaultServiceLifetime scope which you mention in RegisterModule.
```
public interface IHelper
{
    ...
}

[Injectable]
public class Helper : IHelper
{    
        ...
}
```

### Apply [Injectable(ServiceLifetime.Scoped)] attribute to the dependency class and that will automatically register your dependency into the IoC container with Scoped scope. Options available are :
 - [Injectable(ServiceLifetime.Transient)]
 - [Injectable(ServiceLifetime.Scoped)]
 - [Injectable(ServiceLifetime.Singleton)]
```
public interface IScopedHelper
{
    ...
}

[Injectable(ServiceLifetime.Scoped)]

public class ScopedHelper : IScopedHelper
{    
        ...
}
```

### If you don't want to register your dependency automatically then don't mention Injectable attribute and register it manually into Startup.cs/Program.cs.
```
builder.Services.AddScoped<IManualHelper, ManualHelper>((provider) => new ManualHelper("connetionString"));
```

Developer:
@trushitchauhan
