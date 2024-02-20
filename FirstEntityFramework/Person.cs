using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEntityFramework
{
    class Person
    {

        //https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/?redirectedfrom=MSDN

        [Key] //optional bcs : implicit key
        public int PersonId { get; set; }


        [Required]
        [StringLength(50)]

        public string Name { get; set; }

        public int MyAge { get; set; } 

        public double Salary { get; set; }
    }

    [Table("Home_table")]
    class Home
    {
        public int Id { get; set; }

        [MaxLength(80), MinLength(5)]
        public string Address { get; set; }
    }
}
