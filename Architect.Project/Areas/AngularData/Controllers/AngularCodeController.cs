using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Architect.Project.Areas.AngularData.Controllers
{
    public class AngularCodeController : Controller
    {
        // GET: AngularData/AngularCode
        public ActionResult Index()
        {
            return View("AddData");
        }
    }
}