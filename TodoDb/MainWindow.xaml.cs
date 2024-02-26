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
using TodoDb.Domain;
using static TodoDb.Domain.Todo;

namespace TodoDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //filling the combobox
            comboStatus.ItemsSource = Enum.GetValues(typeof(StatusEnum));
            LoadData();
        }

        private void LoadData()
        {
            tbTask.Text = "";
            sliderDifficulty.Value = 2;
            dpDueDate.Text = "";
            comboStatus.SelectedIndex = -1;
            lvTodos.SelectedIndex = -1;

            List<Todo> todos = Global.context.todos.ToList<Todo>();
            lvTodos.ItemsSource = todos;
            lvTodos.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // validate the data

            string task = tbTask.Text;
            int diff = (int)sliderDifficulty.Value;
            DateTime dueDate = (DateTime)dpDueDate.SelectedDate;
            Todo.StatusEnum status =(Todo.StatusEnum) comboStatus.SelectedItem;

            Todo todo = new Todo { Task = task, Difficulty = diff , DueDate= dueDate , Status = status};
            Global.context.todos.Add(todo);
            Global.context.SaveChanges();

            LoadData();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Todo todoTobeDeleted = (Todo)lvTodos.SelectedItem;

            Global.context.todos.Remove(todoTobeDeleted);
            Global.context.SaveChanges();

            LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Todo todoTobeUpdated = (Todo)lvTodos.SelectedItem;
            todoTobeUpdated.Task = tbTask.Text;
            todoTobeUpdated.Difficulty = (int)sliderDifficulty.Value;
            todoTobeUpdated.Status = (Todo.StatusEnum)comboStatus.SelectedItem;
            todoTobeUpdated.DueDate = (DateTime)dpDueDate.SelectedDate;

            Global.context.SaveChanges();

            LoadData();
        }

        private void lvTodos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvTodos.SelectedIndex == -1)
            {
                return;
            }

            Todo todo = (Todo) lvTodos.SelectedItem;
            tbTask.Text = todo.Task;
            sliderDifficulty.Value = todo.Difficulty;
            dpDueDate.SelectedDate = todo.DueDate;
            comboStatus.SelectedItem = todo.Status;

            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;

        }
    }
}
