using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Eremex.AvaloniaUI.Charts;

namespace TestEremex;

public class MyViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public SortedDateTimeDataAdapter DataAdapter { get; set; } = new();

    public MyViewModel()
    {
        Collection.Add("test");
        Collection.Add("test1");
        Collection.Add("test2");
        Collection.Add("test3");
        
        
        Collection2.Add(new ItemSelect( ){Id=1, Name="test"});
        Collection2.Add(new ItemSelect( ){Id=1, Name="test1"});
        Collection2.Add(new ItemSelect( ){Id=1, Name="test2"});
        Collection2.Add(new ItemSelect( ){Id=1, Name="test3"});
        Items.Add(new ItemData(){Id=1, Trigger = null});
        Items.Add(new ItemData(){Id=2, Trigger = "3test2"});
        Items.Add(new ItemData(){Id=3, Trigger = null});
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public ICommand ClearCommand { get; set; } = new RelayCommand(Test);

    private static void Test()
    {
        
    }

    public void ClearTest()
    {
        foreach (ItemData itemData in Items)
            itemData.Trigger = null;
        View.GridControl.CloseEditor();
    }
    

    public ObservableCollection<ItemData> Items { get; set; } = new();
    public ObservableCollection<string> Collection { get; set; } = new();
    public ObservableCollection<ItemSelect> Collection2 { get; set; } = new();
    public MainWindow View { get; set; }

    public void LoadData()
    {
        Collection.Clear();
        Collection.Add("1test");
        Collection.Add("2test1");
        Collection.Add("3test2");
        Collection.Add("4test3");
        
        Collection2.Clear();
        Collection2.Add(new ItemSelect( ){Id=1, Name="1test"});
        Collection2.Add(new ItemSelect( ){Id=1, Name="2test1"});
        Collection2.Add(new ItemSelect( ){Id=1, Name="3test2"});
        Collection2.Add(new ItemSelect( ){Id=1, Name="4test3"});
        OnPropertyChanged(nameof(Collection2));
        OnPropertyChanged(nameof(Collection));
    }
}

public class ItemSelect
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ItemData : INotifyPropertyChanged
{
    private string? _trigger;
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public int Id { get; set; }
    public string? Trigger
    {
        get => _trigger;
        set => SetField(ref _trigger, value);
    }
}