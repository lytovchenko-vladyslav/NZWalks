using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet] // GET: https://localhost:portnumber/api/students
        public IActionResult GetAllStudents()
        {
            var studentsNames = new List<string> { "John", "Jane", "Jack" };
            return Ok(studentsNames);
        }
    }
}
