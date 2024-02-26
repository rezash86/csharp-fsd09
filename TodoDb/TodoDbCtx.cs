using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDb.Domain;

namespace TodoDb
{
    public class TodoDbCtx : DbContext
    {
        public DbSet<Todo> todos { get; set; }
    }
}
