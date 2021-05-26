using DapperService.Model;
using DapperService.Service;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolWeb.Controllers
{
    public class StudentController : Controller
    {
        private StudentService stuSvr = new StudentService();
        // GET: Student
        public async Task<ActionResult> Index()
        {
            var stuVM = await stuSvr.GetAllStudents();
            return View(stuVM.ToList());
        }

        public async Task<ActionResult> EditStudent(int? stuid)
        {
            Student stuVM = stuid == null ? 
                                     new Student() : 
                                     await stuSvr.GetStudentByID(stuid.Value);
            return View(stuVM);
        }

        public async Task<ActionResult> EditAction(Student stuVM)
        {
            if (stuVM.StudentID == 0)
            {
                await stuSvr.CreateStudent(stuVM);
            }
            else
            {
                await stuSvr.UpdateStudent(stuVM);
            }
            
            return RedirectToAction("Index");
        }
    }
}