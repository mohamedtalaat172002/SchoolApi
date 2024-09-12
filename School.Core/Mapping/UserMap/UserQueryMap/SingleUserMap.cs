using School.Core.Feature.Users.Queries.Result;
using School.Data.Models.Identity;

namespace School.Core.Mapping.UserMap
{
    public partial class UserProfile
    {
        public void SingleUserMap()
        {
            CreateMap<User, GetSingleUserByIdDto>();
        }
    }
}
