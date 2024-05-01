using Lab2.Models;

namespace Lab2.Repository
{
    public interface IStudentRepository
    {
        public bool Any(int studentId);

        public List<Student> getAllStudentsWithDept();
    }
}
