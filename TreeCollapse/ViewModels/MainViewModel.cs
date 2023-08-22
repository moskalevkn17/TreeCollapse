using System;
using System.Collections;
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
    public List<TreeItem> Nodes { get; set; } = new List<TreeItem>()
    {
        new TreeItem()
        {
            Name = "Outer 1",
            Items = { new TreeItem(){Name = "Child 1.1"}, new TreeItem(){Name = "Child 1.2"}}
        }, 
        new TreeItem()
        {
            Name = "Outer 2",
            Items = { new TreeItem(){Name = "Child 2.1"}, new TreeItem(){Name = "Child 2.2"}}
        }
    };

    private bool _isExpanded;

    public ICommand Toggle => new RelayCommand(() =>
    {
        foreach (var item in Nodes)
        {
            item.IsExpanded = !item.IsExpanded;
        }
    });
}

public class TreeItem : ViewModelBase
{
    public Color Back => Colors.Blue;
    public bool IsExpanded
    {
        get { return _isExpanded; }
        set { _isExpanded = value; OnPropertyChanged(); }
    }
    public string Name { get; set; } = "Node";
    
    public List<TreeItem> Items { get; set; } = new List<TreeItem>();
    
    private bool _isExpanded;
}


