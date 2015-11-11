using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace WebApplication20.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);            
            var b = builder.Entity<SlaveEntity>();
            b.HasKey(t => t.Id);
            b.HasOne(t => t.Master);
            var c = builder.Entity<MasterEntity>();
            c.HasKey(t => t.Id);
            c.HasMany(t => t.Slaves).WithOne(t=>t.Master).ForeignKey(t=>t.MasterId);
        }
    }

    public class SlaveEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MasterId { get; set; }
        public virtual MasterEntity Master { get; set; }
    }

    public class MasterEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SlaveEntity> Slaves { get; set; }
    }
}
