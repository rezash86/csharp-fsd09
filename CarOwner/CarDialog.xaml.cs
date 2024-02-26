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

namespace CarOwner
{
    /// <summary>
    /// Interaction logic for CarDialog.xaml
    /// </summary>
    public partial class CarDialog : Window
    {
        Owner curOwner;
        public CarDialog(Owner owner)
        {
            InitializeComponent();
            this.curOwner = owner;
            lblDialogName.Content = owner.Name;
            FetchRecord();
        }

        private void FetchRecord()
        {
            lvDialogCars.ItemsSource = curOwner.CarsInGarage.ToList();
        }

        private void lvDialogCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvDialogCars.SelectedIndex == -1)
            {
                ClearDialogInputs();
                return;
            }
            Car c = (Car)lvDialogCars.SelectedItem;
            lblDialogId.Content = c.Id;
            tbDialogMakeModel.Text = c.MakeModel;
            btnDialogDelete.IsEnabled = true;
            btnDialogUpdate.IsEnabled = true;
        }

        private void btnDialogAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!IsDialogFieldsValid()) { return; };
            try
            {
                Car car = new Car
                {
                    MakeModel = tbDialogMakeModel.Text,
                    OwnerId = curOwner.Id
                };

                Global.ctx.Cars.Add(car);
                Global.ctx.SaveChanges();
                ClearDialogInputs();
                FetchRecord();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void ClearDialogInputs()
        {
            tbDialogMakeModel.Text = "";
            lblDialogId.Content = "";
            btnDialogDelete.IsEnabled = false;
            btnDialogUpdate.IsEnabled = false;
        }

        private bool IsDialogFieldsValid()
        {
            if (tbDialogMakeModel.Text.Length < 1)
            {
                MessageBox.Show("Please, fill in Make & Model", "Validation error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void btnDialogUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsDialogFieldsValid()) { return; };
            Car curCar = (Car)lvDialogCars.SelectedItem;
            if(curCar == null) { return; }

            try
            {
                curCar.MakeModel = tbDialogMakeModel.Text;
                Global.ctx.SaveChanges();
                ClearDialogInputs();
                FetchRecord();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void btnDialogDone_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnDialogDelete_Click(object sender, RoutedEventArgs e)
        {
            Car curCar = (Car)lvDialogCars.SelectedItem;
            if (curCar == null) { return; }
            if (MessageBoxResult.No == MessageBox.Show("Do you want to delete the record?\n" + curCar, "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            { return; }
            try
            {
                Global.ctx.Cars.Remove(curCar);
                Global.ctx.SaveChanges();
                ClearDialogInputs();
                FetchRecord();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Database operation failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
    }
}
