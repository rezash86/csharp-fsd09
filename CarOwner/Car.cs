using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwner
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string MakeModel { get; set; }

        public int OwnerId { get; set; }

        public Owner Owner { get; set; }

        public override string ToString()
        {
            return $"{Id}, {MakeModel}";
        }
    }
}
