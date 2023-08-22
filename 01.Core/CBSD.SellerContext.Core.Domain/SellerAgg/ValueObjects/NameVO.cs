using Framework.Domain.ValueObject;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.ValueObjects
{
    public class ProductName : BaseValueObject<ProductName>
    {
        public string Value { get; private set; } = "";

        public static ProductName Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (name.Length < 2)
                throw new ArgumentException("name", "must have at least two characters");

            return new ProductName
            {
                Value = name
            };
        }

        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool ObjectIsEqual(ProductName other)
        {
            return ReferenceEquals(this, other) ||
                   Value.Equals(other.Value);
        }
    }
}
