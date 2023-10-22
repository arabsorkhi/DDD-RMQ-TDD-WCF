using CBSD.Framework.Domain.Data;
using Framework.Domain.ApplicationServices;
using CBSD.Seller.Core.Domain.SellerAgg.Data;
using CBSD.Seller.Core.Domain.DomainEvent.Commands;

namespace CBSD.Core.ApplicationServices.Sellers.CommandHandlers
{
    public class SentRecieptHandler : ICommandHandler<SentRecieptCommand>
    {
        private readonly  ISellerRepository _sellerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SentRecieptHandler(ISellerRepository sellerRepository,IUnitOfWork unitOfWork)
        {
            _sellerRepository = sellerRepository;
            _unitOfWork = unitOfWork;
        }
        public void Handle(SentRecieptCommand command)
        {
            if (_sellerRepository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا شناسه {command.Id} ثبت شده است.");

            var seller = _sellerRepository.Load(command.Id);
            if (seller == null)
                throw new InvalidOperationException($"  شناسه {command.Id} یافت نشد.");
            seller.SendReceipt(   command.Id);
            _unitOfWork.Commit();
        }
    }
}
