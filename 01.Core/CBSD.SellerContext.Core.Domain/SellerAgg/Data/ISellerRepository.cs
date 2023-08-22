using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Data
{
    //Repo for cmd
    public interface ISellerRepository
    {
        bool Exists(Guid id);

        Entities.Seller Load(Guid id);

        void Add(Entities.Seller entity);
    }
}
