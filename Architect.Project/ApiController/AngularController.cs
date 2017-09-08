using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Architect.Interfaces.Business.Processors;

namespace Architect.Project
{
    public class custom
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    //[RoutePrefix("api/angular")]
    [ApiErrorHandler]
    public class AngularController : ApiController
    {
        private readonly IDepartmentProcessor deptp;
        public AngularController(IDepartmentProcessor processor)
        {
            this.deptp = processor;
        }
        [HttpGet]
        public HttpResponseMessage GetData1()
        {
            List<custom> data1 = GetData();

            HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK, data1);
            //message.Content=new StringContent()
            return message;
        }
        private List<custom> GetData()
        {
            List<custom> list = new List<custom>()
            {
                new custom(){id=1,name="V1"},
                new custom(){id=2,name="V2"},

            };
            //Dictionary<string, int> data1 = new Dictionary<string, int>();
            //data1.Add("Value 1", 1);
            //data1.Add("Value 2", 2);
            //data1.Add("Value 3", 3);
            //data1.Add("Value 4", 4);
            return list;
        }

        [HttpPost]
        public HttpResponseMessage Data2byData1id([FromBody] custom data)
        {
            List<custom> list = new List<custom>()
            {
                new custom(){id=1,name="V1"},
                new custom(){id=2,name="V2"},
                new custom(){id=3,name="V3"},
                new custom(){id=4,name="V4"},
                new custom(){id=5,name="V5"},
                new custom(){id=6,name="V6"},
                new custom(){id=7,name="V7"},
                new custom(){id=1,name="V8"},


            };
            var dataresult = list.Where(x => x.id == data.id).ToList();


            Dictionary<string, int> data1 = new Dictionary<string, int>();
            data1.Add("Sub-Value 1", 1);
            data1.Add("Sub-Value 2", 2);
            data1.Add("Sub-Value 3", 3);
            data1.Add("Sub-Value 4", 4);
            HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK, dataresult);
            return message;
        }

        //[Route("departments")]
        [HttpGet]
        [ActionName("Departments")]
        public IHttpActionResult GetDepartments(bool istrue=true)
        {
            throw new ArgumentNullException("sdfs");
            return Ok(deptp.GetAll());
        }
    }
}
