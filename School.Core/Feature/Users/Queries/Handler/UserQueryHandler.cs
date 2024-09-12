using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Core.Base;
using School.Core.Feature.Users.Queries.Model;
using School.Core.Feature.Users.Queries.Result;
using School.Core.Resources;
using School.Core.Wrapper;
using School.Data.Models.Identity;

namespace School.Core.Feature.Users.Queries.Handler
{
    public class UserQueryHandler : ResponseHandler,
            IRequestHandler<GetPagintedUserQuery, Response<PaginatedResult<GetPaginatedListOfUsersDto>>>,
            IRequestHandler<GetSingleUserByIdQuery, Response<GetSingleUserByIdDto>>

    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly UserManager<User> _userManager;
        public UserQueryHandler(IMapper mapper, IStringLocalizer<SharedResources> sharedResources, UserManager<User> userManager) : base(sharedResources)
        {
            _mapper = mapper;
            _sharedResources = sharedResources;
            _userManager = userManager;
        }

        public async Task<Response<PaginatedResult<GetPaginatedListOfUsersDto>>> Handle(GetPagintedUserQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetPaginatedListOfUsersDto>(users)
                                            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return Success(paginatedList);

        }

        public async Task<Response<GetSingleUserByIdDto>> Handle(GetSingleUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == request.Id);
            if (user == null) return NotFound<GetSingleUserByIdDto>();
            var mappedUser = _mapper.Map<GetSingleUserByIdDto>(user);
            return Success(mappedUser);

        }


    }
}
