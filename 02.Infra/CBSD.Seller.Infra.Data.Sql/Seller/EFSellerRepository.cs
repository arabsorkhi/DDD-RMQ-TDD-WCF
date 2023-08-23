using CBSD.Seller.Core.Domain.SellerAgg.Data;

namespace CBSD.Infra.Data.Sql.Seller
{

    public class EFSellerRepository:ISellerRepository,IDisposable
    {
        readonly SellerDbContext _sellerDbContext;
        public EFSellerRepository(SellerDbContext sellerDbContext)
        {
           _sellerDbContext= sellerDbContext;
        }
        public bool Exists(Guid id)
        {
           return _sellerDbContext.Seller.Any(c=>c.Id == id);
        }

        public CBSD.Seller.Core.Domain.SellerAgg.Entities.Seller Load(Guid id)
        {
           return _sellerDbContext.Seller.Find(id );
        }

        public void Add(CBSD.Seller.Core.Domain.SellerAgg.Entities.Seller entity)
        {
             _sellerDbContext.Seller.Add(entity);
        }

        public void Dispose()
        {
            _sellerDbContext.Dispose();
        }
 
        }
}