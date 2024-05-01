using Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        SDContext db;
        public CoursesController(SDContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<Course>> get()
        {
            List<Course> courses = db.Courses.ToList();
            if(courses.Count > 0)
            {
                return Ok(courses);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Course course = db.Courses.Find(id);
            if(course != null)
            {
                db.Courses.Remove(course);
                db.SaveChanges();
                List<Course> Courses = db.Courses.ToList();
                return Ok(Courses);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult put(int id, Course crs )
        {
            if(id != crs.ID)
            {
                return BadRequest();
            }
            else if (db.Courses.Find(id) == null)
            {
                return NotFound();
            }
            else
            {
                db.Entry(crs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return NoContent();
            }
        }

        [HttpPost]
        public ActionResult post(Course crs)
        {
            if (crs == null)
            {
                return BadRequest();
            }
            else
            {
                db.Courses.Add(crs);
                db.SaveChanges();
                return CreatedAtAction(nameof(get), new { id = crs.ID }, crs);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Course> getById(int id)
        {
            Course course = db.Courses.Find(id);
            if(course != null)
            {
                return Ok(course);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("name")]
        public ActionResult<Course> getByName(string name)
        {
            Course course = db.Courses.FirstOrDefault(c => c.Crs_name == name);
            if(course != null)
            {
                return Ok(course);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
