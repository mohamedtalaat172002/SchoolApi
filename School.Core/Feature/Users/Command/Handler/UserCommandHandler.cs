using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using School.Core.Base;
using School.Core.Feature.Users.Command.Model;
using School.Core.Resources;
using School.Data.Models.Identity;

namespace School.Core.Feature.Users.Command.Handler
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<EditeUserCommand, Response<String>>,
        IRequestHandler<AddUserCommand, Response<String>>,
        IRequestHandler<DeleteUserCommand, Response<String>>

    {

        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly UserManager<User> _userManager;



        public UserCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> sharedResources, UserManager<User> userManager) : base(sharedResources)
        {
            _mapper = mapper;
            _sharedResources = sharedResources;
            _userManager = userManager;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            var MappedUser = _mapper.Map<User>(request);
            var user = await _userManager.FindByEmailAsync(MappedUser.Email);
            var username = await _userManager.FindByNameAsync(MappedUser.UserName);
            if (user != null)
                return BadRequest<String>(_sharedResources[SharedResourcesKeys.EmailAlreadyExist]);
            if (username != null)
                return BadRequest<String>(_sharedResources[SharedResourcesKeys.UserNameAlreadyExist]);


            var AddingUser = await _userManager.CreateAsync(MappedUser, request.Password);
            if (!AddingUser.Succeeded)
                return BadRequest<String>(_sharedResources[SharedResourcesKeys.OperationFailed]);
            return Created<String>(_sharedResources[SharedResourcesKeys.RegisterSucess]);

        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id.ToString());
            if (user == null)
                return NotFound<String>();

            var res = await _userManager.DeleteAsync(user);
            if (!res.Succeeded)
                return BadRequest<String>(_sharedResources[SharedResourcesKeys.OperationFailed]);

            return Deleted<String>();
        }

        public async Task<Response<string>> Handle(EditeUserCommand request, CancellationToken cancellationToken)
        {
            //checkId
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                return NotFound<String>();
            //CheckMail
            var userwithmail = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.Email && x.Id != request.Id);
            if (userwithmail != null)
                return BadRequest<String>(_sharedResources[SharedResourcesKeys.EmailAlreadyExist]);
            //CheckUserName
            var userwithname = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName && x.Id != request.Id);
            if (userwithname != null)
                return BadRequest<String>(_sharedResources[SharedResourcesKeys.UserNameAlreadyExist]);

            var MappedUser = _mapper.Map(request, user);


            var updateUser = await _userManager.UpdateAsync(MappedUser);
            if (!updateUser.Succeeded)
                return BadRequest<String>(_sharedResources[SharedResourcesKeys.OperationFailed]);
            return Updated<String>();

        }
    }
}
