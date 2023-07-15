using System.ComponentModel;
using SQLite;
using Tasker.Abstraction;

namespace Tasker.MVVM.Models
{
    [Table("Tasks")]
    public class MyTask : TableData, INotifyPropertyChanged
    {
        private bool _completed;

        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                OnPropertyChanged("Completed");
            }
        }

        public int ProjectId { get; set; }

        [Ignore]
        public string TaskColor { get; set; }

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

