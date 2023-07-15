using System.ComponentModel;
using SQLite;
using Tasker.Abstraction;

namespace Tasker.MVVM.Models
{
    [Table("Projects")]
    public class Project : TableData, INotifyPropertyChanged
    {
        private float _percentage;
        private int _pendingTasks;
        private string _tasksToString = " ";
        public string Color { get; set; }

        [Ignore]
        public bool IsSelected { get; set; }

        [Ignore]
        public string TasksToString
        {
            get => _tasksToString;
            set
            {
                _tasksToString = value;
                OnPropertyChanged("TasksToString");
            }
        }

        [Ignore]
        public float Percentage
        {
            get => _percentage;
            set
            {
                _percentage = value;
                OnPropertyChanged("Percentage");
            }
        }

        [Ignore]
        public int PendingTasks
        {
            get => _pendingTasks;
            set
            {
                _pendingTasks = value;
                OnPropertyChanged("PendingTasks");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string myProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(myProperty));
            }
        }
    }
}

