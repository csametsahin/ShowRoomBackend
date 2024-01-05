using AutoMapper;
using SR.Entities.Concrete.DbModels;
using SR.Entities.Concrete.ViewModels.User;

namespace SR.Core.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /* Mapping Profile
             * add your mappings here for view models 
             * i thought i could use it for request models but seems like it is not good practice
             * **/
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
