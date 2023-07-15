using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    public class EditViewModel
    {
        public Project Project { get; set; }
        public ObservableCollection<MyTask> NestedTasks { get; set; }
        
        public ObservableCollection<Project> Projects { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public ICommand DeleteCommand =>
            new Command((Object obj) =>
            {

               if (obj.GetType() == typeof(MyTask))
                {
                    NestedTasks.Remove((MyTask) obj);
                    Tasks.Remove((MyTask) obj);
                    App.TaskRepo.DeletItem((MyTask)obj);
                }
                else if (obj.GetType() == typeof(Project))
                {
                    Projects.Remove((Project) obj);
                    App.ProjectRepo.DeletItem  ((Project) obj);
                }

            });

    }
}


