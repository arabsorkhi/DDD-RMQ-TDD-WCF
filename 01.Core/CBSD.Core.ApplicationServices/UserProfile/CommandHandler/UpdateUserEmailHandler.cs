using CBSD.Seller.Core.Domain.Shared.ValueObject;
using CBSD.Seller.Core.Domain.UserProfileAgg.Command;
using CBSD.Seller.Core.Domain.UserProfileAgg.Data;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;

namespace CBSD.Core.ApplicationServices.UserProfile.CommandHandler
{
    public class UpdateUserEmailHandler : ICommandHandler<UpdateUserEmail>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserProfileRepository _userProfileRepository;
        public UpdateUserEmailHandler(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this.unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }
        public void Handle(UpdateUserEmail command)
        {
            var user = _userProfileRepository.Load(command.UserId);
            if (user == null)
                throw new InvalidOperationException($"کاربری با شناسه {command.UserId} یافت نشد.");
            user.UpdateEmail(Email.FromString(command.Email));
            unitOfWork.Commit();
        }
    }
}

