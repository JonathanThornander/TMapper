# TMapper

![apple-touch-icon](https://github.com/JonathanThornander/TMapper/assets/43991450/adb3cd8d-7b79-4c40-867b-7573a1f6cadf)

**Overview:**

TMapper is a lightweight, strongly-typed mapping library designed to simplify the process of mapping objects from one type to another. It provides an easy-to-use interface for asynchronous type mapping, with a focus on performance and simplicity.

## Key Features:

1. **Asynchronous Mapping:**
   - TMapper allows you to map objects asynchronously, making it suitable for scenarios where asynchronous processing is essential.

2. **Strong Typing:**
   - The library leverages strong typing to ensure that your mappings are type-safe, catching potential errors at compile-time rather than runtime.

3. **Dependency Injection Integration:**
   - TMapper seamlessly integrates with the Microsoft.Extensions.DependencyInjection framework, making it easy to manage and inject mappers into your application's components.

4. **Automated Mapper Registration:**
   - The `AddMappers` extension method automates the registration of `IMapper<TSource, TTarget>` implementations in the provided assemblies. This significantly reduces the boilerplate code required to set up your dependency injection container.

## Getting Started:

### Installation:

You can install the TMapper NuGet package using the following command:

```bash
dotnet add package TMapper
```

### Example Usage:

1. Define your mappers by implementing the `IMapper<TSource, TTarget>` interface.

   ```csharp
   public class MyMapper : IMapper<SourceClass, TargetClass>
   {
       public async Task<TargetClass> Map(SourceClass source, CancellationToken cancellationToken = default)
       {
           // Your mapping logic here
       }
   }
   ```

2. Register your mappers in the DI container using the `AddMappers` method.

   ```csharp
   services.AddMappers(typeof(MyMapper).Assembly);
   ```

3. Inject the mapper into your classes where needed.

   ```csharp
   public class MyService
   {
       private readonly IMapper<SourceClass, TargetClass> _mapper;

       public MyService(IMapper<SourceClass, TargetClass> mapper)
       {
           _mapper = mapper;
       }

       // Use _mapper to perform mappings as needed
   }
   ```

## Why TMapper?

TMapper distinguishes itself from other mapping libraries, such as AutoMapper, by focusing on simplicity, strong typing, and asynchronous mapping capabilities. With TMapper, you get the benefits of a dedicated mapping solution without sacrificing performance or introducing unnecessary complexity to your codebase.

Give TMapper a try and experience the power of strongly-typed, asynchronous mapping in your .NET projects!

For more information, please visit the [TMapper GitHub repository](https://github.com/jonathanthornander/TMapper).
