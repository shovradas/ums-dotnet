using System;
using System.Linq;
using Ums.Infrastructure.Data.EF;
using Ums.Entities;
using Ums.Service.Interfaces;
using System.Security.Cryptography;
using Ums.Framework;

namespace Ums.Service.EF
{
    public class AuthService: IAuthService
    {
        private readonly UmsDbContext _context;
        private readonly CryptoHelper _cryptoHelper;

        public AuthService(UmsDbContext context, CryptoHelper cryptoHelper)
        {
            _context = context;
            _cryptoHelper = cryptoHelper;
        }

        public bool ValidateUser(User user)
        {            
            using (MD5 md5Hash = MD5.Create())
            {
                var hashedPassword = _cryptoHelper.GetMd5Hash(md5Hash, user.Password);

                var authenticatedUser = _context.Users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == hashedPassword);

                if (authenticatedUser != null)
                {
                    user.Id = authenticatedUser.Id;
                    user.Name = authenticatedUser.Name;
                    user.Type = authenticatedUser.Type;
                    user.IsActive = authenticatedUser.IsActive;
                    user.Email = authenticatedUser.Email;
                    user.Password = "*****";
                    return true;
                }
            }     

            return false;
        }
    }
}
