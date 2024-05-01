using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using Lab2.DTO;
using Swashbuckle.AspNetCore.Annotations;


namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ITIContext db;
        public DepartmentsController(ITIContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "method to return all departments data", Description = "my desc")]
        [SwaggerResponse(404, "if no department")]
        [SwaggerResponse(200, "if found any department", Type = typeof(List<DepartmentDTO>))]
        public ActionResult getall()
        {
            List<Department> departments = db.Departments.ToList();

            if (departments == null)
            {
                return NotFound();
            }
            List<DTO.DepartmentDTO> departmentDTOs = new List<DTO.DepartmentDTO>();

            foreach (var department in departments)
            {
                DTO.DepartmentDTO departmentDTO = new DTO.DepartmentDTO();
                departmentDTO.Dept_Id = department.Dept_Id;
                departmentDTO.Dept_Name = department.Dept_Name;
                departmentDTO.Dept_Desc = department.Dept_Desc;
                departmentDTO.Dept_Location = department.Dept_Location;
                departmentDTO.StudentCount = department.Students.Count();
                departmentDTOs.Add(departmentDTO);
            }
            return Ok(departmentDTOs);
        }
    }
}
