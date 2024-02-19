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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwoDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;

            //age and cityname
            int age = 0;
            string cityName = "";
            HelloDialog helloDialog = new HelloDialog(name);
            helloDialog.Owner = this; // it helps to open the new dialog near the parent position

            //I am going to introduct target method for my delegate
            //helloDialog.AssignResult += (a, c) => { age = a; cityName = c; };
            helloDialog.AssignResult += GetMessage;

            bool? result = helloDialog.ShowDialog();

            //if(result == true)
            //{
            //    lblResult.Content = $"Age : {age} and city: {cityName}";
            //}
        }

        private void GetMessage(int age, string citySelected)
        {
            lblResult.Content = $"Age : {age} and city: {citySelected}";
        }

    }
}
