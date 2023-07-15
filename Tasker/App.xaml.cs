using Tasker.MVVM.Models;
using Tasker.MVVM.Views;
using Tasker.Repositories;


namespace Tasker;

public partial class App : Application
{
    public static BaseRepository<Project> ProjectRepo { get; private set; }
    public static BaseRepository<MyTask> TaskRepo { get; private set; }


    public App(BaseRepository<Project> projectRepo, BaseRepository<MyTask> taskRepo)
    {
        InitializeComponent();

        ProjectRepo = projectRepo;
        TaskRepo = taskRepo;

        MainPage = new NavigationPage(new MainView());

    }
}

