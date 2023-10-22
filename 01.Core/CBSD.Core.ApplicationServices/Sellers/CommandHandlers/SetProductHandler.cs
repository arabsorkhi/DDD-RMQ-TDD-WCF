using CBSD.Framework.Domain.Data;
using Framework.Domain.ApplicationServices;
using CBSD.Seller.Core.Domain.SellerAgg.Data;
using CBSD.Seller.Core.Domain.DomainEvent.Commands;

namespace CBSD.Core.ApplicationServices.Sellers.CommandHandlers
{
    public class SetProductHandler : ICommandHandler<SetProductCommand>
    {
        private readonly  ISellerRepository _sellerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetProductHandler(ISellerRepository sellerRepository,IUnitOfWork unitOfWork)
        {
            _sellerRepository = sellerRepository;
            _unitOfWork = unitOfWork;
        }
        public void Handle(SetProductCommand command)
        {
            if (_sellerRepository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا شناسه {command.Id} ثبت شده است.");
            var seller = _sellerRepository.Load(command.Id);
            if (seller == null)
                throw new InvalidOperationException($"  شناسه {command.Id} یافت نشد.");
            seller.SetProduct( command.Id     );
            _unitOfWork.Commit();
        }
    }
}
