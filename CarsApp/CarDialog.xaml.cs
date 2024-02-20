using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarsApp
{
    /// <summary>
    /// Interaction logic for CarDialog.xaml
    /// </summary>
    public partial class CarDialog : Window
    {
        public event Action<Car> AddedNewCar;
        public Car curCar;
        public CarDialog(Car car)
        {
            InitializeComponent();

            //populate the combobox (dynamic)
            comboFuelType.ItemsSource = Enum.GetValues(typeof(Car.FuelTypeEnum));
            comboFuelType.SelectedIndex = 0;

            if(car != null) // I want to edit a car
            {
                tbMakeModel.Text = car.MakeModel;
                sliderEngineSize.Value = car.EngineSize;
                comboFuelType.SelectedItem = car.FuelType;
                curCar = car;

                btnSaveUpdate.Content = "Update";
            }
        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            string makeModel = tbMakeModel.Text;
            double engineSize = sliderEngineSize.Value;

            Car.FuelTypeEnum fuelType = (Car.FuelTypeEnum)comboFuelType.SelectedItem;

            //I need to know if I am saving or editing ??
            if(curCar != null)
            {
                curCar.MakeModel = makeModel;
                curCar.EngineSize = engineSize;
                curCar.FuelType = fuelType;
            }
            else
            {
                AddedNewCar?.Invoke(new Car(makeModel, engineSize, fuelType));
            }
           

            //it closes the dialog
            DialogResult = true;
        }
    }
}
