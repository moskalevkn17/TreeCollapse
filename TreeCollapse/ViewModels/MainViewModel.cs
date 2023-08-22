using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Input;

namespace TreeCollapse.ViewModels;

public class MainViewModel : ViewModelBase
{
    public Color Back => Colors.Red;
    public bool IsExpanded 
    {
        get { return _isExpanded; }
        set { _isExpanded = value; OnPropertyChanged(); OnPropertyChanged("Nodes"); }
    }
    public List<Outer> Nodes { get; set; } = new List<Outer>() { new Outer(), new Outer() };

    private bool _isExpanded;

    public ICommand Toggle => new RelayCommand(() => 
    IsExpanded = !IsExpanded);
}

public class Outer : ViewModelBase
{
    public Color Back => Colors.Blue;
    public bool IsExpanded
    {
        get { return _isExpanded; }
        set { _isExpanded = value; OnPropertyChanged(); }
    }
    public string Name { get; set; } = "Outer";
    public List<Inner> Items { get; set; } = new List<Inner>() { new Inner(), new Inner() };
    private bool _isExpanded;
}

public class Inner
{
    public Color Back => Colors.Green;
    public string Name { get; set; } = "Inner";
}

