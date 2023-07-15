using System.Collections.ObjectModel;
using System.Windows.Input;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    public class MainViewModel
    {

        public ObservableCollection<Project> Projects { get; set; } = new();
        public ObservableCollection<MyTask> Tasks { get; set; } = new();

        public MainViewModel()
        {
            LoadData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }


        public void LoadData()
        {
            List<Project> projects = App.ProjectRepo.GetItems();

            foreach (var projet in projects)
            {
                Projects.Add(projet);
            }

            List<MyTask> tasks = App.TaskRepo.GetItems();

            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }

            UpdateData();

        }

        public void UpdateData()
        {
            if (Projects == null)
                return;

            foreach (var p in Projects)
            {
                var tasks = from t in Tasks
                            where t.ProjectId == p.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;

                p.PendingTasks = notCompleted.Count();
                p.Percentage = (float)completed.Count() / (float)tasks.Count();
                p.TasksToString = p.PendingTasks > 1 ? $"{p.PendingTasks} tâches" : $"{p.PendingTasks} tâche";
            }

            if (Tasks == null)
                return;

            foreach (var t in Tasks)
            {
                var catColor =
                     (from c in Projects
                      where c.Id == t.ProjectId
                      select c.Color).FirstOrDefault();

                t.TaskColor = catColor;
                App.TaskRepo.UpdateItem(t);
            }
        }


        private void Tasks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }
    }
}

