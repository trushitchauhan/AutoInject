# DIAutoInjector
Auto dependency is package to make dependency injection attribute based, which register dependencies based on attributes, easy to manage and forget to mention dependencies in Startup.cs/Program.cs.

## How to get started:
### Register DIAutoInjector installer module into Startup.cs/Program.cs file:
```
builder.Services.RegisterDIAutoInjector(ServiceLifetime defaultServiceLifetime = ServiceLifetime.Transient);
```
> defaultServiceLifetime is parameter where you can define default scope of the dependencies to be registered.

### Apply [Injectable] attribute to dependency class and that will automatically register your dependency into IoC container. This will auto register your dependency into IoC container with defaultServiceLifetime scope which you mention in RegisterModule.
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

### Apply [Injectable(ServiceLifetime.Scoped)] attribute to dependency class and that will automatically register your dependency into IoC container with Scoped scope. Options available are :
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

### If you don't want to register your depdency automatically then don't mention Injectable attribute and register it manually into Startup.cs/Program.cs.
```
builder.Services.AddScoped<IManualHelper, ManualHelper>((provider) => new ManualHelper("connetionString"));
```

Developer:
@trushitchauhan