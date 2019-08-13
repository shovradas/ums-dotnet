using Ums.Infrastructure.Data.EF;
using Ums.Entities;
using Ums.Service.Interfaces;

namespace Ums.Service.EF
{
    public class DepartmentService : ServiceBase<Department>, IDepartmentService
    {
        private readonly UmsDbContext _context;

        public DepartmentService(UmsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
