using CBSD.Seller.Core.Domain.SellerAgg.Commands;
using CBSD.Seller.Core.Domain.SellerAgg.Data;
using CBSD.Seller.Core.Domain.SellerAgg.ValueObjects;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;

namespace CBSD.Core.ApplicationServices.Sellers.CommandHandlers
{
    public class CreateHandler:ICommandHandler<CreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly  ISellerRepository _sellerRepository;

        public CreateHandler(ISellerRepository sellerRepository,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _sellerRepository = sellerRepository;
        }
        public void Handle(CreateCommand command)
        {
            if (_sellerRepository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا شناسه {command.Id} ثبت شده است.");

            var seller = new  CBSD.Seller.Core.Domain.Entities.Seller(new UserId(command.Id),
                NameVO.Create(command.Name),AddressVO.Create("",command.Address));
            _sellerRepository.Add(seller );
            _unitOfWork.Commit();
        }
    }
}
