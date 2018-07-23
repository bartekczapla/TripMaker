using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripMaker.Controllers;

namespace TripMaker.Web.Host.Controllers
{

    public class TasksController : TripMakerControllerBase
    {
    //    // GET: api/Tasks
    //    [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET: api/Tasks/5
        //[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
