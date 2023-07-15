using System.Collections.ObjectModel;
using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
    public NewTaskView()
    {
        InitializeComponent();
    }
    private async void AddTaskClicked(object sender, EventArgs e)
    {

        var vm = BindingContext as NewTaskViewModel;
        var selectedProject = vm.Projects.Where(x => x.IsSelected == true).FirstOrDefault();
        List<MyTask> tasks = App.TaskRepo.GetItems();
        var nextId = 1;

        if (tasks.Count > 0)
            nextId = tasks.Max(x => x.Id) + 1;

        if (selectedProject == null)
        {
            await DisplayAlert("Attention", "vous devez sélectionner un projet", "OK");
            return;
        }

        var taskName =
            await DisplayPromptAsync($"{selectedProject.Name}", "définissez une tâche à réaliser", keyboard: Keyboard.Text);

        if (!string.IsNullOrEmpty(taskName))
        {
            var newTask = new MyTask
            {
                Id = nextId,
                Name = taskName,
                Completed = false,
                ProjectId = selectedProject.Id
            };

            vm.AddOrUpdateCommmand.Execute(newTask);
            await Navigation.PopAsync();
        }
    }


    private async void AddProjectClicked(object sender, EventArgs e)
    {
        List<Project> projects = App.ProjectRepo.GetItems();

        var nextId = 1;
        var vm = BindingContext as NewTaskViewModel;
        var r = new Random();

        Project newProject;

        if (projects.Count > 0)
            nextId = projects.Max(x => x.Id) + 1;

        string project =
             await DisplayPromptAsync("Nouveau", "définissez un nouveau projet",
             maxLength: 20,
             keyboard: Keyboard.Text);

        if (!string.IsNullOrEmpty(project))
        {
            newProject = new Project
            {
                Id = nextId,
                TasksToString = "0 tâche",
                Color = Color.FromRgb(
                    r.Next(0, 255),
                    r.Next(0, 255),
                    r.Next(0, 255)).ToHex(),
                Name = project
            };

            vm.AddOrUpdateCommmand.Execute(newProject);
        }
    }
}
