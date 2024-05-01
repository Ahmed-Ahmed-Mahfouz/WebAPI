using Lab2.Models;
using Lab2.Repository;

namespace Lab2.UnitOfWork
{
    public interface IUnitOfWorks
    {
        IGenericRepository<Student> GenericStudentRepository { get; }
        IGenericRepository<Department> GenericDepartmentRepository { get; }
        IStudentRepository StudentRepo { get; }

        void Save();
    }
}
