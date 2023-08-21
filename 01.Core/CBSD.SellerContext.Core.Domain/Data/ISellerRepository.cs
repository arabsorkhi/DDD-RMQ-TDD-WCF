using System;

namespace CBSD.Seller.Core.Domain.Data
{
    public interface ISellerRepository
    {
        bool Exists(Guid id);

        CBSD.Seller.Core.Domain.Entities.Seller Load(Guid id);

        void Add(CBSD.Seller.Core.Domain.Entities.Seller entity);
    }
}
