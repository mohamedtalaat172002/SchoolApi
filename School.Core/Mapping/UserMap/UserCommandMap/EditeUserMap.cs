using AutoMapper;
using School.Core.Feature.Users.Command.Model;
using School.Data.Models.Identity;

namespace School.Core.Mapping.UserMap
{
    public partial class UserProfile : Profile
    {
        void EditeUserMap()
        {
            CreateMap<EditeUserCommand, User>();
        }
    }
}
