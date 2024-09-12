using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Core.Base;
using School.Core.Feature.Users.Command.Model;
using School.Core.Resources;
using School.Data.Models.Identity;

namespace School.Core.Feature.Users.Command.Handler
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<String>>
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
                return BadRequest<String>(_sharedResources[SharedResourcesKeys.CreationFailed]);
            return Created<String>(_sharedResources[SharedResourcesKeys.RegisterSucess]);





        }
    }
}
