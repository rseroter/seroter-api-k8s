using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace seroter_api_k8s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value1";
        }

        [HttpGet("{id}/status")]
        public string GetOrderStatus(int id)
        {
            if (id > 0 && id <= 20)
            {
                return "shipped";
            }
            else
            {
                return "processing";
            }
        }
    }
}
