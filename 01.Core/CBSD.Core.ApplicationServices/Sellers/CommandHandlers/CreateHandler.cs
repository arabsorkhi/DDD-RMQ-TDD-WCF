using CBSD.Framework.Domain.Data;
using CBSD.Seller.Core.Domain.SellerAgg.Commands;
using CBSD.Seller.Core.Domain.SellerAgg.Data;
using CBSD.Seller.Core.Domain.SellerAgg.ValueObjects;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Events;

namespace CBSD.Core.ApplicationServices.Sellers.CommandHandlers
{
    public class CreateHandler:ICommandHandler<CreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
       // private readonly IEventSource _eventSource;
        private readonly  ISellerRepository _sellerRepository;

        public CreateHandler(ISellerRepository sellerRepository,IUnitOfWork unitOfWork
            //,IEventSource eventSource
            )
        {
            _unitOfWork = unitOfWork;
          //  _eventSource = eventSource;
            _sellerRepository = sellerRepository;
        }

        public void Handle(CreateCommand command)
        {
            if (_sellerRepository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا شناسه {command.Id} ثبت شده است.");

            var seller = new Seller.Core.Domain.SellerAgg.Entities.Seller(new UserId(command.Id),
                NameVO.Create(command.Name), AddressVO.Create("", command.Address));
            _sellerRepository.Add(seller);
            _unitOfWork.Commit();
            var events = seller.GetEvents();
            //streamId=AggId
            //_eventSource.Save("SellerAggregate", command.Id.ToString(), events);
        }
    }
}
