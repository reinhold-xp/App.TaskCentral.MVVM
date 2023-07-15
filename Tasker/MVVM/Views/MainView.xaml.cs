using System.Collections.ObjectModel;
using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class MainView : ContentPage
{
    private MainViewModel _mainViewModel = new();

    public MainView()
    {
        InitializeComponent();
        BindingContext = _mainViewModel;
    }

    void CheckBox_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        _mainViewModel.UpdateData();
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var taskView = new NewTaskView
        {
            BindingContext = new NewTaskViewModel
            {
                Tasks = _mainViewModel.Tasks,
                Projects = _mainViewModel.Projects
            }
        };

        Navigation.PushAsync(taskView);
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ObservableCollection<MyTask> projectTasks = new();

        var projectEditView = new EditView();
        var project = (Project)e.Parameter;
        var tasks = from t in _mainViewModel.Tasks where t.ProjectId == project.Id    select t;

        foreach (var task in tasks)
        {
            projectTasks.Add(task);
        }

        projectEditView = new EditView
        {
            Title = project.Name,
            BindingContext = new EditViewModel
            {
                Project = project,
                NestedTasks = projectTasks,
                Tasks = _mainViewModel.Tasks,
                Projects = _mainViewModel.Projects
            }
        };

        Navigation.PushAsync(projectEditView);

    }
}

