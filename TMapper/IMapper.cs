using System.Threading;
using System.Threading.Tasks;

namespace TMapper
{
    /// <summary>
    /// Maps the source type to the target type asynchronously
    /// </summary>
    /// <typeparam name="TSource">The object to map from</typeparam>
    /// <typeparam name="TTarget">The object to map to</typeparam>
    public interface IMapper<TSource, TTarget>
    {
        public Task<TTarget> Map(TSource source, CancellationToken cancellationToken = default);
    }
}
