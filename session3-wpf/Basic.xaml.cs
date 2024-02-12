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

namespace session3_wpf
{
    /// <summary>
    /// Interaction logic for Basic.xaml
    /// </summary>
    public partial class Basic : Window
    {
        public Basic()
        {
            InitializeComponent();
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            string name = TxtName.Text;
            string age = "";
            if (rbtnBelow18.IsChecked == true)
            {
                age = rbtnBelow18.Content.ToString();
            }
            if (rbtnOver18.IsChecked == true)
            {
                age = rbtnOver18.Content.ToString();
            }

            //the result selecteditem is an object and we need to cast it to a combo box item
            ComboBoxItem selectedContinent = (ComboBoxItem)cmbContinents.SelectedItem;
            string value = selectedContinent.Content.ToString();

            MessageBox.Show(string.Format($"hello {name} you are {age} and from {value}"), "My App", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
