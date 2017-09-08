using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Architect.Models.Models;
using Architect.BAL.Processors;
using Architect.Interfaces.Business.Processors;

namespace Architect.Project.Areas.Department.Controllers
{

    //[RouteArea("")]
    //[RoutePrefix("")]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentProcessor departmentProcessor;
        public DepartmentController(IDepartmentProcessor deptProcessor)
        {
            this.departmentProcessor = deptProcessor;
        }

        // GET: Department/Department
        [HttpGet]
        public ActionResult Index()
        {
            return View("Add",new Deparment());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(Deparment department)
        {
            if (ModelState.IsValid)
            {
                if (department.DepartmentId == 0)
                    departmentProcessor.Add(department);
                if (department.DepartmentId != 0)
                    departmentProcessor.Update(department);
            }
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult GetDepartments()
        {
            List<Deparment> listDepts = departmentProcessor.GetAll().ToList();
            //System.Threading.Thread.Sleep(20000);
            return PartialView("DepartmentList", listDepts);
        }

        public ActionResult EditDepartment(Deparment dept)
        {
            return View("Add", dept);
        }

        public ActionResult DeleteDepartment(Deparment dept)
        {
            departmentProcessor.Delete(dept);
            return RedirectToAction("Index");
        }
    }
}