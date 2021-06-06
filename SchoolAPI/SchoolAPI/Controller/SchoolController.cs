using DapperService.Model;
using DapperService.Service;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SchoolAPI.Controller
{
    public class SchoolController : ApiController
    {
        // GET: School
        [HttpGet]
        [Route("api/School/allStudents")]
        public async Task<IHttpActionResult> GetAllStudents()
        {
            StudentService stuSvr = new StudentService();

            var result = await stuSvr.GetAllStudents();

            if (result == null || result.ToList().Count == 0)
            {
                return NotFound();
            }

            return Ok(new { Items = result, Count = result.ToList().Count });
        }

        [HttpGet]
        [Route("api/School/GetStudent/{id}")]
        public async Task<IHttpActionResult> GetStudentById(int id)
        {
            StudentService stuSvr = new StudentService();

            var result = await stuSvr.GetStudentByID(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(new { Items = result });
        }

        [HttpGet]
        [Route("api/School/StudentWithEnrollment/{id}")]
        public async Task<IHttpActionResult> GetStudentWithEnrollmentById(int id)
        {
            StudentService stuSvr = new StudentService();

            var result = await stuSvr.GetStudentWithEnrollment(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(new { Items = result });
        }

        [HttpGet]
        [Route("api/School/SearchStudent/{name}")]
        public async Task<IHttpActionResult> SearchStudent(string name)
        {
            StudentService stuSvr = new StudentService();

            var result = await stuSvr.SearchStudentByKeyword(name);

            if (result == null || result.ToList().Count == 0)
            {
                return NotFound();
            }

            return Ok(new { Items = result });
        }

        [HttpPost]
        [Route("api/School/NewStudent")]
        public async Task<IHttpActionResult> CreateStudent(Student student)
        {
            StudentService stuSvr = new StudentService();

            var result = await stuSvr.CreateStudent(student);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(new { Items = result });
        }

        [HttpPut]
        [Route("api/School/EditStudent")]
        public async Task<IHttpActionResult> UpdateStudent(Student student)
        {
            StudentService stuSvr = new StudentService();

            var result = await stuSvr.UpdateStudent(student);

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/School/DeleteStudent/{studentID}")]
        public async Task<IHttpActionResult> RemoveStudent(int studentID)
        {
            StudentService stuSvr = new StudentService();

            var result = await stuSvr.DeleteStudent(studentID);

            return Ok(result);
        }
    }
}