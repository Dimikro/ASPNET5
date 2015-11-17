using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication20.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication20.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            var random = new Random();
            var link = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 30)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            using (var context = new ApplicationDbContext())
            {
                var msg = new Message();
                msg.Text = value;
                msg.Link = link;
                msg.StateId = 1;
                context.Messages.Add(msg);
                context.SaveChanges();
            }
            return "http://hh.ru/" + link;
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
