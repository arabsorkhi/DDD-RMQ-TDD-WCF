using CBSD.Seller.Core.Domain.Events;
using CBSD.Seller.Core.Domain.ValueObjects;
using Framework.Domain.Entities;
using Framework.Domain.Events;
using System;
using System.Collections.Generic;

namespace CBSD.Seller.Core.Domain.Entities
{
    public class Product:BaseEntity<Guid>
    {
        #region Fields
        public ProductId Id { get; set; }
        public ProductName Name { get; set; } 
        public string Description { get; set; }
        public string Title { get; set; }
        public List<Picture> Pictures { get; private set; }
         
        public int Order { get; private set; }
        #endregion
        public Product()
        {

        }
        //double dispatch
        //applier change state by own and notif Root to validate
        public Product(Action<IEvent> applier) : base(applier)
        {
        }

        #region Methods

        public void AddPicture(PictureUrl pictureUrl,PictureSize pictureSize)
        {
            var newPic=new Picture(HandleEvent);
            newPic.HandleEvent(new ProductPictureAdded
            {
                Id= Id,
                PictureUrl= pictureUrl,
                Name= Name.Value,
                Height= pictureSize.Height,
                Width= pictureSize.Width,
                Order   =Order,
                //PictureSize=pictureSize.Height;


            });

            Pictures.Add(newPic);
        }
        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case ProductPictureAdded e:
                //    Id =new ProductId(e.Id);
                //     Pictures = PictureUrl.FromString(e.PictureUrl);
                //    Size = new PictureSize(e.Height, e.Width);
                //    Order = e.Order;
                    break;
                //case AdvertismentPictureResized e:
                //    Size = new PictureSize(e.Height, e.Width);
                //    break;
            }
        }

        #endregion
    }
}
