using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwner
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [NotMapped]
        public int CarsNumber { get => CarsInGarage.Count; }

        [Required]
        public byte[] Photo { get; set; }

        public ICollection<Car> CarsInGarage { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }
}
