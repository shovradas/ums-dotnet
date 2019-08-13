using System;
using Ums.Entities;

namespace Ums.Service.Interfaces
{
    public interface IAuthService
    {
        bool ValidateUser(User user);
    }
}
