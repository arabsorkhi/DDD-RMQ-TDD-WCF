using CBSD.Seller.Core.Domain.UserProfileAgg.Data;
using CBSD.Seller.Infra.Data.Sql.Seller;

namespace CBSD.Seller.Infra.Data.Sql.UserProfile
{
    public class EFUserProfileRepository : IUserProfileRepository, IDisposable
    {
        private readonly SellerDbContext  _sellerDbContext;

        public EFUserProfileRepository(  SellerDbContext sellerDbContext)
        {
            _sellerDbContext = sellerDbContext;
            
        }
        public void Add(Core.Domain.UserProfileAgg.Entities.UserProfile entity)
        {
            _sellerDbContext.UserProfiles.Add(entity);
        }

        public void Dispose()
        {
            _sellerDbContext.Dispose();
        }

        public bool Exists(Guid id)
        {
            return _sellerDbContext.UserProfiles.Any(c => c.Id == id);
        }

        public Core.Domain.UserProfileAgg.Entities.UserProfile Load(Guid id)
        {
            return _sellerDbContext.UserProfiles.Find(id);
        }
    }
}
