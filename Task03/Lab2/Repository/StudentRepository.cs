using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repository
{
    public class StudentRepository : IStudentRepository
    {
        ITIContext db;

        public StudentRepository(ITIContext db)
        {
            this.db = db;
        }

        public bool Any(int studentId)
        {
            return db.Students.Any(s => s.St_Id == studentId);
        }

        public List<Student> getAllStudentsWithDept()
        {
            return db.Students.Include(s => s.Dept).ToList();
        }
    }
}
