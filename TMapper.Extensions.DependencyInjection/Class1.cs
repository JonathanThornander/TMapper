using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace TMapper.Extensions.DependencyInjection
{
    public static class MapperExtensions
    {
        /// <summary>
        /// Locates implementations of IMapper<> in the provided assemblies and adds them to the DI-container
        /// </summary>
        /// <param name="serviceDescriptors"></param>
        /// <param name="assemblies"></param>
        public static void AddMappers(this IServiceCollection serviceDescriptors, params Assembly[] assemblies)
        {
            assemblies.SelectMany(assembly => assembly.GetTypes())
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapper<,>) && i.GetGenericArguments().Length == 2)
                    .Select(i => new { MapperType = t, SourceType = i.GetGenericArguments()[0], TargetType = i.GetGenericArguments()[1] }))
                .ToList()
                .ForEach(t => serviceDescriptors.AddTransient(typeof(IMapper<,>).MakeGenericType(t.SourceType, t.TargetType), t.MapperType));
        }
    }
}
