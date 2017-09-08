using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
namespace Architect.Project.Controllers
{
    public class ExcelDataController : Controller
    {
        // GET: Excel
        public ActionResult Index()
        {
            //var app = new Excel.Application();
            //var workbook = app.Workbooks.Open(@"C:\\Users\\mdhingra\\Desktop\\exceldata.xlsx");
            //var sheet = (Excel.Worksheet)workbook.Worksheets.
            var filepath = @"C:\\Users\\mdhingra\\Desktop\\exceldata.xlsx";
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", filepath);
            var dataAdapter = new OleDbDataAdapter("Select * from [Departments$]", connectionString);
            var ds = new System.Data.DataSet();
            dataAdapter.Fill(ds, "Department");
            System.Data.DataTable dt = ds.Tables["Department"];
            return View("AddExcel");
        }

        [HttpPost]
        public ActionResult PostExcel()
        {
            return View();
        }
    }
}