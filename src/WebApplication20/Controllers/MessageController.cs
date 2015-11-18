using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication20.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication20.Controllers
{
    //[Route("api/[controller]")]
    [Route("Message")]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext context;
        public MessageController(ApplicationDbContext Context)
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
        public void Get(string guid)
        {
            //return context.Messages.First(t => t.Link == link).Text;
            //return Redirect("~/HiddenMessage.html/" + guid);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            var random = new Random();
            var guid = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 30)
              .Select(s => s[random.Next(s.Length)]).ToArray());
           
                var msg = new Message();
                msg.Text = value;
                msg.Guid = guid;
                msg.StateId = 1;
                msg.CreateDate = DateTime.Now;
                context.Messages.Add(msg);
                context.SaveChanges();
          
            return "http://localhost:43815/HiddenMessage/" + guid;
        }

        // PUT api/values/5
        [HttpPut("{guid}")]
        public void Put(string guid, [FromBody]string value)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Messages.FirstOrDefault(t => t.Guid == guid).StateId = 2;
                context.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{guid}")]
        public void Delete(string guid)
        {
        }
    }
}
