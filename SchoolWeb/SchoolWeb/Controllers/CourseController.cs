using Service.Service;
using Service.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoolWeb.Controllers
{
    public class CourseController : Controller
    {
        private CourseService courseSvr = new CourseService();
        // GET: Course
        public async Task<ActionResult> Index()
        {
            List<CourseViewModel> courseVM = await courseSvr.GetAllCourses();
            return View(courseVM);
        }
    }
}