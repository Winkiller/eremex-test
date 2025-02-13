using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using Eremex.AvaloniaUI.Controls.Docking;
using Newtonsoft.Json;

namespace TestEremex;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        (DataContext as MyViewModel).View = this;
    }

}

