using Service.Service;
using Service.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolWeb.Controllers
{
    public class EnrollmentController : Controller
    {
        private StudentCourseEnrollmentService sceSvr = new StudentCourseEnrollmentService();
        // GET: Enrollment
        public async Task<ActionResult> Index(int stuid)
        {
            List<StudentCourseEnrollment> sceVM = await sceSvr.GetStudentEnrollments(stuid);
            return View(sceVM);
        }
    }
}