using System;
using System.Windows.Input;
using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class EditView : ContentPage
{

    public EditView()
    {
        InitializeComponent();
    }

    async void Button_ClickedAsync(System.Object sender, System.EventArgs e)
    {
        MyTask taskToRemove;
        var vm = BindingContext as EditViewModel;
        bool answer = await DisplayAlert($"{vm.Project.Name}", "voulez-vous vraiment supprimer le projet ?", "Oui", "Non");

        if (!answer)
            return;

        for (int i = 0; i < vm.Tasks.Count; i++)
        {
            if (vm.Tasks[i].ProjectId == vm.Project.Id)
            {
                taskToRemove = vm.Tasks[i];
                vm.Tasks.Remove(taskToRemove);
                vm.DeleteCommand.Execute(taskToRemove);
                i--;
            }
        }

        vm.DeleteCommand.Execute(vm.Project);
        await Navigation.PopAsync();
    }

}
