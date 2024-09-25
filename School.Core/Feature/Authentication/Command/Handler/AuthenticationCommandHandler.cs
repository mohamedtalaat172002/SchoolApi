using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Core.Base;
using School.Core.Feature.Authentication.Command.Model;
using School.Core.Resources;
using School.Data.Models.Identity;
using School.Data.Result;
using School.Service.Abstract;

namespace School.Core.Feature.Authentication.Command.Handler
{
    public class AuthenticationCommandHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtResult>>
    {

        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authenticationService;


        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IAuthenticationService authenticationService, SignInManager<User> signInManager, UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authenticationService = authenticationService;
            _signInManager = signInManager;
            _userManager = userManager;
        }



        public async Task<Response<JwtResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check username existence
            var UserByUserName = await _userManager.FindByNameAsync(request.UserName);
            if (UserByUserName == null) return BadRequest<JwtResult>(_stringLocalizer[SharedResourcesKeys.SignInFailed]);

            //CheckPassword
            var inResult = await _signInManager.CheckPasswordSignInAsync(UserByUserName, request.Password, false);
            if (!inResult.Succeeded) return BadRequest<JwtResult>(_stringLocalizer[SharedResourcesKeys.SignInFailed]);

            //Generate the token
            var res = await _authenticationService.GenerateJwtToken(UserByUserName);
            return Success(res);







        }
    }
}
