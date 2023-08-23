using CBSD.Framework.Domain.Data;
using Framework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CBSD.Infra.Data.Sql.Seller;

public class SellerUnitOfWork : IUnitOfWork
{
    private readonly SellerDbContext _sellerDbContext;
    private readonly IEventSource _eventSource;

    public SellerUnitOfWork(SellerDbContext sellerDbContext,IEventSource eventSource)
    {
        _sellerDbContext = sellerDbContext;
        _eventSource = eventSource;
    }

    public int Commit()
    {
        var entityForSave = GetEntityForSave();
        int result = _sellerDbContext.SaveChanges();
        SaveEvents(entityForSave);
        return result;
    }
    //before save change we recieved entity list
    private void SaveEvents(List<EntityEntry> entityForSave)
    {
        foreach (var item in entityForSave)
        {
            var root = item.Entity as BaseAggregateRoot<Guid>;
            if (root != null)
            {
                var id = root.Id.ToString();
                var aggName = item.Entity.GetType().FullName;
                _eventSource.Save(aggName, id, root.GetEvents());
            }
        }
    }

    private List<EntityEntry> GetEntityForSave()
    {
        return _sellerDbContext.ChangeTracker
            .Entries()
            .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted)
            .ToList();
    }
}