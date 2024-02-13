using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string fileName = @"..\..\mydata.txt";
        List<Todo> todoList = new List<Todo>();
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
                while (line != null)
                {
                    string[] myData = line.Split(';');
                    int difficulty;
                    if (!int.TryParse(myData[2], out difficulty))
                    {
                        MessageBox.Show("Input string error");
                        continue;
                    }
                    Todo task = new Todo(myData[0], myData[1], difficulty, myData[3]);
                    todoList.Add(task);

                    line = sr.ReadLine();
                }
            }

            lvList.ItemsSource = todoList;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach(Todo todo in todoList)
                {
                    sw.WriteLine(todo.ToDataString());
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtTask.Text == "")
            {
                MessageBox.Show("Input string error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime? selectedDate = dpDueDate.SelectedDate;
            if(selectedDate == null)
            {
                MessageBox.Show("Choose a date for the todo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Todo todo = new Todo(txtTask.Text, selectedDate.ToString(), int.Parse(slDifficulty.Value.ToString()), combStatus.Text);
            todoList.Add(todo);

            ResetValues();
      
        }

        private void ResetValues()
        {
            lvList.Items.Refresh();
            txtTask.Clear();
            dpDueDate.Text = "";
            slDifficulty.Value = 1;
            lvList.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(lvList.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select one item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtTask.Text == "")
            {
                MessageBox.Show("Input string error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Todo taskTobeUpdated = (Todo)lvList.SelectedItem;
            taskTobeUpdated.TaskName = txtTask.Text;
            taskTobeUpdated.Difficulty = int.Parse(slDifficulty.Value.ToString());
            taskTobeUpdated.DueDate = dpDueDate.Text;
            taskTobeUpdated.Status = combStatus.Text;

            ResetValues();
        }

        private void lvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            var selectedItem = lvList.SelectedItem;

            if(selectedItem is Todo)
            {
                Todo todo = (Todo)selectedItem;
                txtTask.Text = todo.TaskName;
                slDifficulty.Value = todo.Difficulty;
                dpDueDate.SelectedDate = DateTime.Parse(todo.DueDate);
                combStatus.Text = todo.Status;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvList.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select one item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Todo taskTobeDeleted = (Todo)lvList.SelectedItem;
            if(taskTobeDeleted != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure to delete the task?", "CONFIRMATION", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(result == MessageBoxResult.Yes)
                {
                    todoList.Remove(taskTobeDeleted);
                    ResetValues();
                }
            }
        }

        private void btnExportToFile_Click(object sender, RoutedEventArgs e)
        {
            //Display a SaveFileDialog so the user can save the file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Save the todos in a file";
            if(saveFileDialog.ShowDialog() == true)
            {
                string allData = "";
                foreach(Todo todo in todoList)
                {
                    allData += todo.ToString() + "\n";
                }
                File.WriteAllText(saveFileDialog.FileName, allData);
            }
        }
    }
}
