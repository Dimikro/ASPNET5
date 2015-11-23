using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApplication20.Models;
using WebApplication20.ViewModels.Message;

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

        [HttpPost]
        [Route("ReadNote/{guid}")]
        public string ReadNote(Guid guid)
        {
            var msg = context.Messages.First(t => t.Guid == guid && t.StateId == 1);
            var txt = "The note is absent";
            if (msg != null)
            {
                msg.StateId = 2;
                context.SaveChanges();
                txt = msg.Text;
            }
            return txt;

        }

        // GET api/values/5
        [HttpGet("{guid}")]
        public IActionResult Get(Guid guid)
        {
            if (context.Messages.Any(t => t.Guid == guid && t.StateId == 1))
                return Redirect("http://localhost:43815/HiddenMessage.html?guid=" + guid);
            else
                return Redirect("http://localhost:43815/Message.html");
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]MessageViewModel message)
        {
            var random = new Random();
            var guid = new Guid();
           
                var msg = new Message();
                msg.Text = message.Text;
                msg.Guid = guid;
                msg.StateId = 1;
                msg.Password = message.Password;
                msg.HoursToDelete = message.HoursToDelete;
                msg.CreateDate = DateTime.Now;
                context.Messages.Add(msg);
                context.SaveChanges();
          
            return "http://localhost:43815/Message/" + guid;
        }

        // PUT api/values/5
        [HttpPut("{guid}")]
        public void Put(Guid guid, [FromBody]string value)
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
