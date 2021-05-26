using DapperService.Service;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolWeb.Controllers
{
    public class EnrollmentController : Controller
    {
        private StudentService sceSvr = new StudentService();
        // GET: Enrollment
        public async Task<ActionResult> Index(int stuid)
        {
            var sceVM = await sceSvr.GetStudentWithEnrollment(stuid);
            return View(sceVM);
        }
    }
}