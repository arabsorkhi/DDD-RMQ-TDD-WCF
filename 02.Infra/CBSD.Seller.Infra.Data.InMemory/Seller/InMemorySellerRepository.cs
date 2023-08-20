using CBSD.Seller.Core.Domain.Data;

namespace CBSD.Seller.Infra.Data.InMemory.Seller
{
    public class InMemorySellerRepository : ISellerRepository
        {
            private readonly Dictionary<Guid, Core.Domain.Entities.Seller> db = new Dictionary<Guid, Core.Domain.Entities.Seller>();
            public bool Exists(Guid id)
            {
                return db.ContainsKey(id);
            }

            public Core.Domain.Entities.Seller Load(Guid id)
            {
                return db[id];
            }

            public void Add(Core.Domain.Entities.Seller entity)
            {
                db[entity.Id] = entity;
            }
        }
    }
 