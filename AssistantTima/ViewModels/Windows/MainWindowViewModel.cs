using System.Collections.ObjectModel;
using AssistantTima.ViewModels.Controls;
using AssistantTima.Views.Controls;
using Avalonia.Controls;
using ReactiveUI;

namespace AssistantTima.ViewModels.Windows;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var button = new InformationButtonViewModel("Тренировки", "Это раздел тренировок", new ViewModelBase()).View;
            
        Buttons.Add(button);
    }
#pragma warning disable CA1822 // Mark members as static
#pragma warning restore CA1822 // Mark members as static
    
    private ObservableCollection<InformationButtonView> _buttons = [];

    public ObservableCollection<InformationButtonView> Buttons
    {
        get => _buttons;
        set => this.RaiseAndSetIfChanged(ref _buttons, value);
    }
}