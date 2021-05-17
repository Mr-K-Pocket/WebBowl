using EntityModel.Models;
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

        public async Task<ActionResult> EditStudent(int? stuid)
        {
            StudentViewModel stuVM = stuid == null ? 
                                     new StudentViewModel() : 
                                     await stuSvr.GetStudentById(stuid.Value);
            return View(stuVM);
        }

        public async Task<ActionResult> EditAction(StudentViewModel stuVM)
        {
            Student student = stuVM.StudentID == 0 ? 
                              stuSvr.CreateStudent(stuVM) :
                              stuSvr.UpdateStudent(stuVM);

            return RedirectToAction("Index");
        }
    }
}