using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsvHelper;
using System.Globalization;

namespace CarsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string fileName = @"..\..\cars.txt";
        List<Car> cars = new List<Car>();
        public MainWindow()
        {
            InitializeComponent();
            LoadFile();
        }

        private void LoadFile()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = sr.ReadLine();
                while(line != null)
                {
                    string[] myData = line.Split(';');
                    double engineSize;
                    if (!double.TryParse(myData[1], out engineSize))
                    {
                        MessageBox.Show("input string error, Go to the next line");
                        continue;
                    }
                    Car.FuelTypeEnum fuelType;
                    if (!Enum.TryParse(myData[2], out fuelType))
                    {
                        MessageBox.Show("there is an error to parse the data, Go to the next line");
                        continue;
                    }
                    Car car = new Car(myData[0], engineSize, fuelType);
                    cars.Add(car);
                    line = sr.ReadLine();
                }

                lvCars.ItemsSource = cars;
                tbStatus.Text = String.Format("You currently have {0} car(s)", lvCars.Items.Count);
            }
        }

        private void MenuItemExportToCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file(*.csv)|*.csv";
            saveFileDialog.Title = "Export to file";
            
            if(saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using(var writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(cars);
                        }
                    }
                }
                catch(IOException exception)
                {
                    MessageBox.Show("Error writing file: " + exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lvCars.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select one item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Car carToBeDeleted = (Car) lvCars.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Are you sure?", "CONFIRMATION", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(result == MessageBoxResult.Yes)
            {
                cars.Remove(carToBeDeleted);
                lvCars.Items.Refresh();
            }

            tbStatus.Text = String.Format("You currently have {0} car(s)", lvCars.Items.Count);
        }

        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            CarDialog carDialog = new CarDialog(null);
            carDialog.Owner = this;

            carDialog.AddedNewCar += (car) => { cars.Add(car); };

            bool? result = carDialog.ShowDialog();
            lvCars.Items.Refresh();
            tbStatus.Text = String.Format("You currently have {0} car(s)", lvCars.Items.Count);


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach(Car myCar in cars)
                {
                    writer.WriteLine(myCar.ToDataString());
                }
            }
        }

        private void MenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            if(lvCars.SelectedIndex == -1)
            {
                return;
            }

            Car car = (Car)lvCars.SelectedItem;
            CarDialog carDialog = new CarDialog(car);
            carDialog.Owner = this;

            bool? result = carDialog.ShowDialog();
            if(result == true)
            {
                lvCars.Items.Refresh();
            }
        }
    }
}
