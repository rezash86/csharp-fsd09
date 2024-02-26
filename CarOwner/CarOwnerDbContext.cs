using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwner
{
    public class CarOwnerDbContext : DbContext
    {
        const string DbName = "carsownerdatabases.mdf";
        static string DbPath = Path.Combine(Environment.CurrentDirectory, DbName);

        public CarOwnerDbContext() : base($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DbPath};Integrated Security=True;Connect Timeout=30")
        {

        }

        //Car
        public  DbSet<Car> Cars { get; set; }
        //Owner
        public  DbSet<Owner> Owners { get; set; }
    }
}
