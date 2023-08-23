using CBSD.Seller.Core.Domain.UserProfileAgg.Command;
using CBSD.Seller.Core.Domain.UserProfileAgg.Data;
using CBSD.Seller.Core.Domain.UserProfileAgg.ValueObjects;
using Framework.Domain.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBSD.Framework.Domain.Data;

namespace CBSD.Core.ApplicationServices.UserProfile.CommandHandler
{
    public class UpdateUserNameHandler : ICommandHandler<UpdateUserName>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserProfileRepository _userProfileRepository;
        public UpdateUserNameHandler(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this.unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }
        public void Handle(UpdateUserName command)
        {
            var user = _userProfileRepository.Load(command.UserId);
            if (user == null)
                throw new InvalidOperationException($"کاربری با شناسه {command.UserId} یافت نشد.");
            user.UpdateName(FirstName.FromString(command.FirstName), LastName.FromString(command.LastName));
            unitOfWork.Commit();
        }
    }
}
