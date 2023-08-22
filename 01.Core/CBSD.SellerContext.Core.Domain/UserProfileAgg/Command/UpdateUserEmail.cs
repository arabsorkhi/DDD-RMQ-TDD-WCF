using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSD.Seller.Core.Domain.UserProfileAgg.Command
{
    public class UpdateUserEmail
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
