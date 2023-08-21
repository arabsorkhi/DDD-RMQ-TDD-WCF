using Framework.Domain.ValueObject;
using System;

namespace CBSD.Seller.Core.Domain.ValueObjects
{
    public class NameVO : BaseValueObject<NameVO>
    {
        public string Value { get; private set; } = "";

        public static NameVO Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (name.Length < 2)
                throw new ArgumentException("name", "must have at least two characters");

            return new NameVO
            {
                Value = name
            };
        }

         public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool ObjectIsEqual(NameVO other)
        {
            return ReferenceEquals(this, other) ||
                   Value.Equals(other.Value);
        }
    }
}
