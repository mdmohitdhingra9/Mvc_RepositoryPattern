using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Architect.Interfaces;
using Architect.Interfaces.Business.Processors;
using Architect.Models.Models;


namespace Architect.Project.Controllers
{
    [Authorize]
    [ErrorHandler]
    public class EmployeeController : BaseController
    {
        private IEmployeeProcessor empProcessor;
        private IDepartmentProcessor deptProcessor;
        //public EmployeeController(IDepartmentProcessor deptProcessor)
        //{
        //    this.deptProcessor = deptProcessor;

        //}
        public EmployeeController(IEmployeeProcessor empProcessor, IDepartmentProcessor deptProcessor)
        {
            this.empProcessor = empProcessor;
            this.deptProcessor = deptProcessor;
        }

        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.DepartmentList = deptProcessor.GetAll();
            return View("Add",new Employee());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Save(Employee emp, System.Web.HttpPostedFileBase file)
        {
            if(ModelState.IsValid)
            {
                if(emp.file!=null && emp.file.ContentLength>0)
                {
                    string fileName = System.IO.Path.GetFileName(emp.file.FileName);
                    string uniquefilename = $"{Guid.NewGuid().ToString()}_{fileName}";
                    string path = System.IO.Path.Combine("C:\\Mohit Folder\\ProjectImages\\", uniquefilename);
                    emp.file.SaveAs(path);
                    emp.ImageId = uniquefilename;
                    empProcessor.Add(emp);
                }
            }
            return RedirectToAction("Index");
        }
    }
}