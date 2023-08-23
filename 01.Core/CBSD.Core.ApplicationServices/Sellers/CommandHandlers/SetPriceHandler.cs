using CBSD.Framework.Domain.Data;
using CBSD.Seller.Core.Domain.SellerAgg.Commands;
using CBSD.Seller.Core.Domain.SellerAgg.Data;
using CBSD.Seller.Core.Domain.SellerAgg.ValueObjects;
using Framework.Domain.ApplicationServices;

namespace CBSD.Core.ApplicationServices.Sellers.CommandHandlers
{
    public class SetPriceHandler : ICommandHandler<SetPriceCommand>
    {
        private readonly  ISellerRepository _sellerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetPriceHandler(ISellerRepository sellerRepository,IUnitOfWork unitOfWork)
        {
            _sellerRepository = sellerRepository;
            _unitOfWork = unitOfWork;
        }
        public void Handle(SetPriceCommand command)
        {
            if (_sellerRepository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا شناسه {command.Id} ثبت شده است.");

            var seller = _sellerRepository.Load(command.Id);
            if (seller == null)
                throw new InvalidOperationException($"  شناسه {command.Id} یافت نشد.");
            seller.SetPrice(Price.FromLong(command.Price),command.Id);
            
            _unitOfWork.Commit();
        }
    }
}
