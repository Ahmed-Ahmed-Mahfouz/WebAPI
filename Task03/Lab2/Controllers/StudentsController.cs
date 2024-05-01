using Lab2.Models;
using Lab2.Repository;
using Lab2.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IUnitOfWorks unit;
        public StudentsController(IUnitOfWorks unit)
        {
            this.unit = unit;
        }

        /// <summary>
        ///  get all students and use pagination and search by name
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="name"></param>
        /// <returns>
        /// return all students and when search by name only get the students with this name in first or last name
        /// </returns>
        /// <remarks>
        /// request example  
        /// /api/students
        /// </remarks>
        [HttpGet]
        public ActionResult getall(int pageNumber = 1, int pageSize = 100, string name = "")
        {
            var students = unit.StudentRepo.getAllStudentsWithDept();

            if (!string.IsNullOrEmpty(name))
            {
                students = students.Where(s =>
                    (s.St_Fname != null && s.St_Fname.Contains(name)) ||
                    (s.St_Lname != null && s.St_Lname.Contains(name)))
                    .ToList();
            }

            var totalStudents = students.Count();
            var totalPages = (int)Math.Ceiling(totalStudents / (double)pageSize);

            students = students
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            List<DTO.StudentDTO> studentDTOs = new List<DTO.StudentDTO>();

            foreach (var student in students)
            {
                DTO.StudentDTO studentDTO = new DTO.StudentDTO();
                studentDTO.St_Id = student.St_Id;
                studentDTO.St_Fname = student.St_Fname;
                studentDTO.St_Lname = student.St_Lname;
                studentDTO.St_Address = student.St_Address;
                studentDTO.St_Age = student.St_Age;

                if (student.Dept != null)
                {
                    studentDTO.Dept_Name = student.Dept.Dept_Name;
                }

                studentDTO.SupervisorName = student.St_superNavigation?.St_Fname;
                studentDTOs.Add(studentDTO);
            }

            var paginationMetadata = new
            {
                totalCount = totalStudents,
                pageSize,
                currentPage = pageNumber,
                totalPages
            };

            Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            return Ok(studentDTOs);
        }


        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult add(Student student)
        {
            if (unit.StudentRepo.Any(student.St_Id))
            {
                return Conflict("A student with this ID already exists.");
            }
            unit.GenericStudentRepository.Add(student);
            //unit.GenericStudentRepository.Save();
            unit.Save();
            return Ok();
        }

    }
}
