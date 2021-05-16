using Service.Service;
using Service.ViewModel;
using System.Collections.Generic;
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
            List<StudentViewModel> stuVM = await stuSvr.GetAllStudents();
            return View(stuVM);
        }
    }
}