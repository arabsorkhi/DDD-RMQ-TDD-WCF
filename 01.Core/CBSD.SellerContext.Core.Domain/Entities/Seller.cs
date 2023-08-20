using CBSD.Seller.Core.Domain.Events;
using CBSD.Seller.Core.Domain.ValueObjects;
using Framework.Domain.Entities;
using Framework.Domain.Events;
using Framework.Domain.Exceptions;
using Framwork.Tools.Enums;
using System;
using System.ComponentModel;

namespace CBSD.Seller.Core.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public sealed class Seller : BaseAggregateRoot<Guid>
    {
        #region vo

        public Price Price { get; private set; }
        public Product Product { get; private set; }
        public int ProductId { get; private set; }
        public SellerStatus Status { get; private set; }
        public NameVO Name { get; internal set; }
        public AddressVO Address { get; internal set; }

        #endregion

        //behaviure: create
        public Seller(UserId id, NameVO sellerName, AddressVO address)
        {
            HandleEvent(new SellerCreated { Id = id, Address = address.FullAddress, Name = sellerName.Value });
        }

        //command->event
        public void SetPrice(Price price, Guid guid)
        {

            HandleEvent(new SellerPriceSet { Id = guid, Price = price.Value });
        }

        public void SetProduct(int productId)
        {
            HandleEvent(new SellerProductSet { ProductId = productId });
        }

        public void SendReceipt(Guid  id)
        {

            HandleEvent(new SellerSentReceipt { id = id });
        }


        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case SellerCreated e:
                    Id = e.Id;
                    Name =NameVO.Create(e.Name);
                    Status = SellerStatus.New;
                    break;
                case SellerPriceSet e:
                    Price = new Price(Rial.FromLong(e.Price));
                    break;
                case SellerProductSet e:
                    Status = SellerStatus.RequestforSelling;

                    break;
                case SellerSentReceipt e:
                    Status = SellerStatus.Sold;
                    break;


                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }

        //validation
        protected override void ValidateInvariants()
        {

            var isValid =
                Id != null &&
                Status switch
                {
                    SellerStatus.New =>
                        Name != null
                        && Price != null,
                    SellerStatus.selling =>
                        Name != null
                        && Price != null
                        ,

                    _ => true
                };
            if (!isValid)
            {
                throw new InvalidEntityStateException(this, $"مقدار تنظیم شده برای آگهی در وضیعت {Status.GetDescription()} غیر قابل قبول است");
            }
        }
    }

    public enum SellerStatus
    {
        [Description("جدید")]
        New = 0,
        selling = 1,
        RequestforSelling = 2,
        Waitting = 3,
        Sold = 4,

    }
}
