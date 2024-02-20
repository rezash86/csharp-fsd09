using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEntityFramework
{
    class PeopleDatabaseContext : DbContext
    {
        const string databaseName = "testDatabse.mdf";
        static string DbPath = Path.Combine(Environment.CurrentDirectory, databaseName);

        public PeopleDatabaseContext() : base($@"Data Source =(LocalDB)\MSSQLLocalDB;AttachDbFileName={DbPath};Integrated Security=True;Connect Timeout=30")
        {

        }

        public DbSet<Person> people { get; set; }

        public DbSet<Home> homes { get; set; }
    }
}
