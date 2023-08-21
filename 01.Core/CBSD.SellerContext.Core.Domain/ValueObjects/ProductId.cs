using Framework.Domain.ValueObject;
using System;

namespace CBSD.Seller.Core.Domain.ValueObjects
{
    public class ProductId : BaseValueObject<ProductId>
    {
        public Guid Value { get; private set; }
        private ProductId()
        {

        }
        public static ProductId FromString(string value) => new ProductId(Guid.Parse(value));
        public ProductId(Guid value)
        {
            if (value == default)
                throw new ArgumentException("شناسه کاربر نمی‌تواند خالی باشد", nameof(value));
            Value = value;
        }
        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool ObjectIsEqual(ProductId otherObject)
        {
            return Value == otherObject.Value;
        }
        public static implicit operator Guid(ProductId productId) => productId.Value;
    }
}
