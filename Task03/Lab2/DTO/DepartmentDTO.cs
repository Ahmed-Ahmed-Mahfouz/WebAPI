using System.ComponentModel.DataAnnotations;

namespace Lab2.DTO
{
    public class DepartmentDTO
    {
        public int Dept_Id { get; set; }

        public string Dept_Name { get; set; }

        public string Dept_Desc { get; set; }

        public string Dept_Location { get; set; }

        public int StudentCount { get; set; }
    }
}
