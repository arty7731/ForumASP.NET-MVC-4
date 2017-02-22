using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ForumMVC4ForGeeksForLess.Domain.Entities;

namespace ForumMVC4ForGeeksForLess.Domain.Concreate
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            //: base("DefaultConnection")
        {
            //Database.SetInitializer<DatabaseContext>(new ContextInitializer());
        }
        public DbSet<User> User { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Message> Message { get; set; }
	    
    }
}