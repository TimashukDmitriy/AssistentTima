using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace AssistantTima.Views.Controls;

public partial class TopTitleBar : UserControl
{
    private Window _parentWindow;

    public TopTitleBar()
    {
        InitializeComponent();
        this.PointerPressed += OnPointerPressed;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    // Получаем родительское окно для управления
    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        _parentWindow = this.GetVisualRoot() as Window;
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        // Перемещение окна
        _parentWindow?.BeginMoveDrag(e);
    }

    // Команда для сворачивания окна
    public void MinimizeCommand(object sender, RoutedEventArgs e)
    {
        if (_parentWindow != null) _parentWindow.WindowState = WindowState.Minimized;
    }

    // Команда для максимизации/восстановления окна
    public void MaximizeCommand(object sender, RoutedEventArgs e)
    {
        if (_parentWindow != null)
        {
            _parentWindow.WindowState = _parentWindow.WindowState == WindowState.Maximized 
                ? WindowState.Normal 
                : WindowState.Maximized;
        }
    }

    // Команда для закрытия окна
    public void CloseCommand(object sender, RoutedEventArgs e)
    {
        _parentWindow?.Close();
    }
}
