using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PeopleDatabaseContext ctx = new PeopleDatabaseContext();

            Person person = new Person() { MyAge = new Random().Next(5, 60), Name = "MO", Salary = new Random().Next(5, 60) };
            ctx.people.Add(person);

            Home home = new Home() { Address = " main street " };
            ctx.homes.Add(home);
            
            ctx.SaveChanges();

            //fetch data by using LINQ

            Person fetchedPerson = (from p in ctx.people where p.PersonId == 1 select p).FirstOrDefault<Person>();
            if(fetchedPerson != null)
            {
                Console.WriteLine(fetchedPerson.Name);
                fetchedPerson.Salary = 10000;
                ctx.SaveChanges();

                Console.Write("it is updated");
            }

            var personTobeDeleted1 =(from p in ctx.people where p.PersonId == 2 select p).FirstOrDefault<Person>();
            var personTobeDeleted2 = ctx.people.Where(p => p.PersonId == 3).FirstOrDefault<Person>();

            if(personTobeDeleted1 != null)
            {
                ctx.people.Remove(personTobeDeleted1);
                ctx.SaveChanges();
            }
            else
            {
                Console.WriteLine("the recorde could not be founded");
            }

            //Fetch All the records
            List<Person> peoples = (from p in ctx.people select p).ToList<Person>();
            List<Person> peoples2 = ctx.people.ToList<Person>();

            peoples2.ForEach(p => Console.WriteLine($"{p.PersonId} and {p.Name} and {p.Salary}"));
        }
    }
}
