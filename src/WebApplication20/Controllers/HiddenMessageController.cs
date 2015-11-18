using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication20.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication20.Controllers
{
    [Route("HiddenMessage")]
    public class HiddenMessageController : Controller
    {
        private readonly ApplicationDbContext context;

        public HiddenMessageController(ApplicationDbContext Context)
        {
            this.context = Context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            if (context.Messages.Any(t=>t.Guid == guid))
                return Redirect("http://localhost:43815/HiddenMessage.html?guid=" + guid);
            else
                return Redirect("http://localhost:43815/Message.html");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
