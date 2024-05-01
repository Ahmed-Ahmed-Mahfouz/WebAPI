using Lab2.Models;
using Lab2.Repository;

namespace Lab2.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWorks
    {
        ITIContext db;
        IGenericRepository<Student> genericStudentRepository;
        IGenericRepository<Department> genericDepartmentRepository;
        IStudentRepository studentRepo;
        public UnitOfWorks(ITIContext db)
        {
            this.db = db;
        }

        public IGenericRepository<Student> GenericStudentRepository
        {
            get
            {
                if (genericStudentRepository == null)
                    genericStudentRepository = new GenericRepository<Student>(db);

                return genericStudentRepository;
            }
        }

        public IGenericRepository<Department> GenericDepartmentRepository
        {
            get
            {
                if (genericDepartmentRepository == null)
                    genericDepartmentRepository = new GenericRepository<Department>(db);

                return genericDepartmentRepository;
            }
        }

        public IStudentRepository StudentRepo
        {
            get
            {
                if (studentRepo == null)
                    studentRepo = new StudentRepository(db);
                return studentRepo;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
