using AutoMapper;
using Ums.Entities;
using Ums.Web.Mvc.Models;
using Unity;

namespace Ums.Web.Mvc
{
    public class AutoMapperConfig
    {
        public static void Configure(IUnityContainer container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                //All mappings
                cfg.CreateMap<User, UserVM>();
                cfg.CreateMap<UserVM, User>();
                cfg.CreateMap<User, LoginVM>();
                cfg.CreateMap<LoginVM, User>();
                cfg.CreateMap<User, ChangePasswordVM>();
                cfg.CreateMap<ChangePasswordVM, User>();
            });

            IMapper mapper = config.CreateMapper();
            container.RegisterInstance(mapper);

        }
    }
}