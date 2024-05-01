using Lab2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab2.DTO
{
    public class StudentDTO
    {
        public int St_Id { get; set; }

        public string St_Fname { get; set; }

        public string St_Lname { get; set; }

        public string St_Address { get; set; }

        public int? St_Age { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Dept_Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SupervisorName { get; set; }
    }
}
