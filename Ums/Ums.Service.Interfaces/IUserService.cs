using System;
using Ums.Entities;

namespace Ums.Service.Interfaces
{
    public interface IUserService : IService<User>
    {
        User GetByUserName(String userName);
        User GetByEmail(String email);
        bool UpdateProfile(User user);
        bool UpdatePassword(User user); 
    }
}
