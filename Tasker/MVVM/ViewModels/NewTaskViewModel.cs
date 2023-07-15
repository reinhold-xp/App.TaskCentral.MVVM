using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    public class NewTaskViewModel
    {

        public ObservableCollection<MyTask> Tasks { get; set; } = new();
        public ObservableCollection<Project> Projects { get; set; } = new();

        public ICommand AddOrUpdateCommmand =>
            new Command((Object obj) =>
            {
                if (obj.GetType() == typeof(Project))
                {
                    Projects.Add((Project)obj);
                    App.ProjectRepo.CreateItem((Project)obj);

                    Console.WriteLine(App.ProjectRepo.StatusMessage);
                }
                else if (obj.GetType() == typeof(MyTask))
                {
                    Tasks.Add((MyTask)obj);
                    App.TaskRepo.CreateItem((MyTask)obj);
                }

            });

    }
}

