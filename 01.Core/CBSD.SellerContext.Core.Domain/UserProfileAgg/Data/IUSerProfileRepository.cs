using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSD.Seller.Core.Domain.UserProfileAgg.Data
{
    public class IUSerProfileRepository
    {
        UserProfile Load(Guid id);
        void Add(UserProfile entity);
        bool Exists(Guid id);
    }
}
