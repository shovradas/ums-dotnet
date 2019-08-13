using Ums.Infrastructure.Data.EF;
using Ums.Entities;
using Ums.Service.Interfaces;
using System.Data.Entity;
using System.Linq;
using System;

namespace Ums.Service.EF
{
    public class UserService:ServiceBase<User>,IUserService
    {
        private readonly UmsDbContext _context;

        public UserService(UmsDbContext context) : base(context)
        {
            _context = context;
        }

        override public bool Update(User user)
        {
            try
            {
                user.Password = "*****";
                _context.Entry(user).State = EntityState.Modified;                
                _context.Entry(user).Property(x => x.Password).IsModified = false;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public User GetByUserName(string userName)
        {
            return _context.Set<User>().SingleOrDefault(x => x.UserName == userName);                
                
        }

        public User GetByEmail(String email)
        {
            return _context.Set<User>().SingleOrDefault(x => x.Email == email);
        }

        public bool UpdateProfile(User user)
        {
            try
            {
                _context.Users.Attach(user);
                _context.Entry(user).Property(x => x.Name).IsModified = true;
                _context.Entry(user).Property(x => x.Email).IsModified = true;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePassword(User user)
        {
            try
            {
                _context.Users.Attach(user);
                _context.Entry(user).Property(x => x.Password).IsModified = true;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
