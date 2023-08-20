using CBSD.Seller.Core.Domain.ValueObjects;

using System;

namespace CBSD.Seller.Core.Domain
{


    // based on https://stackoverflow.com/questions/35824607 factories are useful in ddd manner       
    // we need factories when we have sophisticated creation or even when we need to 
    // have more than one constructors, so we can name those constructors
    public class SellerFactory
    {
        public Entities.Seller CreateNewSeller(string name, string fullAddress, string postalCode)
        {
            return new Entities.Seller( UserId.FromString(new Guid().ToString()), NameVO.Create(name), AddressVO.Create(postalCode, fullAddress));
        }
    }

}
