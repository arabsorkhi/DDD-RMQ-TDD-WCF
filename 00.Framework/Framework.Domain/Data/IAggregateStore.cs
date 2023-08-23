using Framework.Domain.Entities;

namespace CBSD.Framework.Domain.Data
{
    //for fetching entity by eventStore
    public interface IAggregateStore
    {
        Task<bool> Exists<T, TId>(TId aggregateId);
        Task Save<T, TId>(T aggregate) where T : BaseAggregateRoot<TId> where TId : IEquatable<TId>;
        Task<T> Load<T, TId>(TId aggregateId) where T : BaseAggregateRoot<TId> where TId : IEquatable<TId>;
    }
}
