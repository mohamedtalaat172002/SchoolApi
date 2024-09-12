using AutoMapper;

namespace School.Core.Mapping.UserMap
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMap();
            PagintedUsersMap();
            SingleUserMap();
        }

    }
}
