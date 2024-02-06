using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1_exc
{
    internal class Program
    {
        //https://www.tutorialsteacher.com/csharp/csharp-collection
        static List<Person> people = new List<Person>();
        const string DatafileName = @"..\..\people.txt";
        static void Main(string[] args)
        {
            //load data from file

            //create a switch
            int choice = GetMenuChoices();
            switch (choice)
            {
                case 1:
                    //you need to ask user to enter information
                    Console.WriteLine("Please enter your name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please enter your age");
                    string ageStr = Console.ReadLine();
                    int age;
                    if (!int.TryParse(ageStr, out age))
                    {
                        Console.WriteLine("Please enter a number for age");
                        return;
                    }
                    Console.WriteLine("Please enter your city");
                    string city = Console.ReadLine();

                    Person person = new Person(name, age, city);
                    people.Add(person);
                    Console.WriteLine("Person has been added");
                    break;
                case 2:
                    ListAllThePeople();
                    break;
                case 3:
                    //ask user to give a name
                    Console.WriteLine("Please eneter a name");
                    string searchName = Console.ReadLine();
                    FindPersonByName(searchName);
                    break;
                case 4:
                    Console.WriteLine("Please eneter a number for age");
                    string searchAgeText = Console.ReadLine();
                    int searchAge;
                    if (!int.TryParse(searchAgeText, out searchAge))
                    {
                        Console.WriteLine("the age is not correct");
                        return;
                    }

                    var listOfFound = FindPersonYoungerThan(searchAge);
                    foreach(var p in listOfFound)
                    {
                        Console.WriteLine(p);
                    }
                    break;
                case 0:
                    SaveToFile();
                    break;
                default:
                    Console.WriteLine("Wrong number");
                    break;
            }
        }

        private static void SaveToFile()
        {
           using(StreamWriter outputFile = new StreamWriter(DatafileName))
            {
                foreach(Person person in people)
                {
                    outputFile.WriteLine($"{person.Name};{person.Age};{person.City}");
                }
            }
        }

        private static List<Person> FindPersonYoungerThan(int searchAge)
        {
            List<Person> foundPeople = new List<Person>();
            foreach (Person person in people)
            {
                if(person.Age < searchAge)
                {
                    foundPeople.Add(person);
                }
            }

            return foundPeople;
        }

        private static string FindPersonByName(string searchName)
        {
            foreach (Person person in people)
            {
                if (person.Name.Contains(searchName))
                {
                    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
                    return $"the person found is {person.Name}"; //using $
                }
            }
            return $"the name {searchName} wasn't there";
        }

        private static void ListAllThePeople()
        {
            foreach(Person person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static int GetMenuChoices()
        {
            while (true)
            {
                Console.Write(
@"1- Add Person Info
2-List persons info
3-Find a person by name
4-Find all persons younger than age
0-Exit          
");
                string choiceStr = Console.ReadLine();
                int choice;
                //https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-8.0#system-int32-tryparse(system-string-system-int32@)
                if (!int.TryParse(choiceStr, out choice))
                {
                    Console.WriteLine("Value must be between 0 and 4");
                    continue;
                }
                return choice;

            }
        }
    }
}
