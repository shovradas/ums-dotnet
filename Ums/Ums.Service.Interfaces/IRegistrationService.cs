using System;
using System.Collections.Generic;
using System.Linq;
using Ums.Entities;

namespace Ums.Service.Interfaces
{
    public interface IRegistrationService : IService<Registration>
    {
        bool Delete(int id);
        bool DeleteByCourseId(int courseId);
        bool DeleteBySectionId(int sectionId);
        bool DeleteByStudentId(int studentId);

        IEnumerable<Registration> GetByCourseId(int courseId);
        IEnumerable<Registration> GetBySectionId(int sectionId);
        IEnumerable<Registration> GetByStudentId(int studentId);
        Registration GetByStudentAndSectionId(int studentId, int sectionId);
        Registration GetByStudentAndCourseId(int studentId, int courseId);
    }
}
