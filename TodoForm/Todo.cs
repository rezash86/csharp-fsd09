using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoForm
{
    public class Todo
    {
        public string TaskName { get; set; }
        public string DueDate { get; set; }
        public int Difficulty { get; set; }
        public string Status { get; set; }

        public Todo(string taskName, string dueDate, int difficulty, string status)
        {
            TaskName = taskName;
            DueDate = dueDate;
            Difficulty = difficulty;
            Status = status;
        }

        public override string ToString()
        {
            return string.Format("{0} by {1}/{2}, {3}", this.TaskName, this.DueDate, this.Difficulty, this.Status);
        }

        public string ToDataString()
        {
            return string.Format("{0};{1};{2};{3}", this.TaskName, this.DueDate, this.Difficulty, this.Status);
        }
    }
}
