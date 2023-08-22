using CBSD.Seller.Core.Domain.UserProfileAgg.Entities;
using System;

namespace CBSD.Seller.Core.Domain.UserProfileAgg.Data
{
    public interface IUserProfileRepository
    {
         UserProfile Load(Guid id);
         void Add(UserProfile entity);
         bool Exists(Guid id);
    }
}
