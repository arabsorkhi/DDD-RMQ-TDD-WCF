using CBSD.Seller.Core.Domain.UserProfileAgg.Command;
using CBSD.Seller.Core.Domain.UserProfileAgg.Data;
using CBSD.Seller.Core.Domain.UserProfileAgg.ValueObjects;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSD.Core.ApplicationServices.UserProfile.CommandHandler
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserProfileRepository _userProfileRepository;
        public RegisterUserHandler(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this.unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }
        public void Handle(RegisterUser command)
        {
            if (_userProfileRepository.Exists(command.UserId))
                throw new InvalidOperationException($"قبلا کاربری با شناسه {command.UserId} ثبت شده است.");

            Seller.Core.Domain.UserProfileAgg.Entities.UserProfile userProfile = new Seller.Core.Domain.UserProfileAgg.Entities.UserProfile(command.UserId,
                FirstName.FromString(command.FirstName),
                LastName.FromString(command.LastName),
                DisplayName.FromString(command.DisplayName));
            _userProfileRepository.Add(userProfile);
            unitOfWork.Commit();
        }
    }
}
