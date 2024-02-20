using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public class Car
    {
        public string MakeModel { get; set; }
        public double EngineSize { get; set; }

        //FuelType => string
        public FuelTypeEnum FuelType { get; set; } 

        public enum FuelTypeEnum { Gasoline, Diesel, Hybrid, Electric, Other}

        public Car(string makeModel, double engineSize, FuelTypeEnum fuelType)        {
            MakeModel = makeModel;
            EngineSize = engineSize;
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2}", this.MakeModel, this.EngineSize, this.FuelType);
        }

        public string ToDataString()
        {
            return string.Format("{0};{1};{2}", this.MakeModel, this.EngineSize, this.FuelType);
        }

        public string ToCSVString()
        {
            return string.Format("{0},{1},{2}", this.MakeModel, this.EngineSize, this.FuelType);
        }
    }
}
