using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session3_exc
{
     class Program
    {
        //https://www.tutorialsteacher.com/csharp/csharp-delegates
        public delegate void MyDelegate(string msg); // declare a delegate
        static MyDelegate del = MethodA;

        public delegate void ReportingDelegate(string message);

        static void ReportIntoAFile(string message)
        {
            //you can save in the DEBUG Folder

            File.AppendAllText(@"C:\test\log.txt", message);
        }

        static void ReportOnScreen(string message)
        {
            Console.WriteLine(message);
        }


        public delegate void CustomDelegate(int param1, string param2); //declare

        private static void MethodA(string msg)
        {
            Console.WriteLine("this message comes form Delegate " + msg);
        }

        static void Main(string[] args)
        {
            del.Invoke("Ciao");


            CustomDelegate cd = Print; //it is method reference and not a real call methid with paranthesis
            

            int guestAge = 15;
            if(guestAge < 18)
            {
                cd.Invoke(18, "Jack");
            }

            //CTRL E , C -> commenting
            cd = PrintHappy;
            cd.Invoke(12, "Jack");


            ReportingDelegate reportingDelegate = null;

            Random random = new Random();

            reportingDelegate += ReportIntoAFile;

            reportingDelegate += ReportOnScreen;

            foreach(var invocation in reportingDelegate.GetInvocationList())
            {
                Console.WriteLine(invocation.ToString());
            }



            //LINQ
            string[] names = { "Bill", "Steve", "James", "Mohan" };
            string foundName = "";
            foreach(string name in names)
            {
                if (name.Contains('a'))
                {
                    foundName = name;
                }
            }

            var linqQuery = from name in names 
                            where name.Contains('a')    
                            select name;


            foreach(var n in linqQuery)
            {
                Console.WriteLine(n);
            }



            Student[] studentArray = {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
                    new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
                    new Student() { StudentID = 7, StudentName = "Rob", Age = 19  } ,
                };

            List<Student> teenAgerStudents = studentArray.Where(std => std.Age > 12 && std.Age < 20).ToList() ;

            // Use LINQ to find first student whose name is Bill
            Student bill = studentArray.Where(std => std.StudentName.Equals("Bill")).FirstOrDefault() ;

            List<Student> sortedStudents = studentArray.Where(std => std.Age > 12)
                .OrderBy(std => std.StudentName).ToList() ;

        }

        private static void PrintHappy(int age, string name)
        {
            Console.WriteLine($"{name} can go to school after{age}");
        }

        private static void Print(int age, string name)
        {
            Console.WriteLine($"{name} cannot drink before{age}");
        }
    }

    class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int Age { get; set; }
    }
}
