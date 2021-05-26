using DapperService.Service;
using System.Linq;
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
            var courseVM = await courseSvr.GetAllCourses();
            return View(courseVM.ToList());
        }
    }
}