using Ums.Infrastructure.Data.EF;
using Ums.Entities;
using Ums.Service.Interfaces;

namespace Ums.Service.EF
{
    public class SectionService : ServiceBase<Section>, ISectionService
    {
        private readonly UmsDbContext _context;

        public SectionService(UmsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
