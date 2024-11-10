using System.Windows.Input;
using AssistantTima.Views.Controls;
using ReactiveUI;

namespace AssistantTima.ViewModels.Controls;

public class InformationButtonViewModel: ReactiveObject
{
    public InformationButtonViewModel(string name, string description, ViewModelBase viewModelBase)
    {
        Name = name;
        Description = description;
        Page = viewModelBase;
        OpenPageCommand = ReactiveCommand.Create(OpenPage);
        View = new InformationButtonView { DataContext = this };
    }
    public string Name { get; set; }

    public string Description { get; set; }

    public ViewModelBase Page { get; set; }
    public InformationButtonView View { get; set; }
    public ICommand OpenPageCommand { get; }

    private void OpenPage()
    {
        
    }
}