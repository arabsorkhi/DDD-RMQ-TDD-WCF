using CBSD.Seller.Core.Domain.SellerAgg.Data;
using Framework.Domain.Data;

namespace CBSD.Seller.Infra.Data.Sql.Seller
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

        public Core.Domain.SellerAgg.Entities.Seller Load(Guid id)
        {
           return _sellerDbContext.Seller.Find(id );
        }

        public void Add(Core.Domain.SellerAgg.Entities.Seller entity)
        {
             _sellerDbContext.Seller.Add(entity);
        }

        public void Dispose()
        {
            _sellerDbContext.Dispose();
        }
 
        }

    public class SellerUnitOfWork : IUnitOfWork
    {
        private readonly SellerDbContext _sellerDbContext;

        public SellerUnitOfWork(SellerDbContext sellerDbContext)
        {
            _sellerDbContext = sellerDbContext;
        }

        public int Commit()
        {
            return _sellerDbContext.SaveChanges();
        }
    }


}