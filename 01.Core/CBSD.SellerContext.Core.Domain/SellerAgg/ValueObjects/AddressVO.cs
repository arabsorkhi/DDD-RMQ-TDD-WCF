using Framework.Domain.ValueObject;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.ValueObjects
{
    public class AddressVO : BaseValueObject<AddressVO>
    {
        public string PostalCode { get; private set; } = "";
        public string FullAddress { get; private set; } = "";

        public static AddressVO Create(string postalCode, string fullAddress)
        {
            if (string.IsNullOrEmpty(postalCode))
                throw new ArgumentNullException("postalCode");

            if (postalCode.Length < 2)
                throw new ArgumentException("name", "must have at least two characters");

            if (string.IsNullOrEmpty(fullAddress))
                throw new ArgumentNullException("name");

            if (fullAddress.Length < 2)
                throw new ArgumentException("name", "must have at least two characters");


            return new AddressVO { PostalCode = postalCode, FullAddress = fullAddress };
        }




        public override bool ObjectIsEqual(AddressVO otherObject)
        {

            if (ReferenceEquals(this, otherObject))
                return true;

            return FullAddress.Equals(otherObject.FullAddress) &&
                   PostalCode.Equals(otherObject.PostalCode);

        }

        public override int ObjectGetHashCode()
        {
            return FullAddress.GetHashCode() |
                   PostalCode.GetHashCode();

        }
    }
}
