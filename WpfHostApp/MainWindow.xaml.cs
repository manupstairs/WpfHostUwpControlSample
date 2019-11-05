using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UWPClassLibrary;
using Windows.UI.Xaml.Controls;

namespace WpfHostApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void WindowsXamlHost_ChildChanged(object sender, EventArgs e)
        {
            // Hook up x:Bind source.
            global::Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost windowsXamlHost =
                sender as global::Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost;
            global::UWPClassLibrary.MyUserControl1 userControl =
                windowsXamlHost.GetUwpInternalObject() as global::UWPClassLibrary.MyUserControl1;

            if (userControl != null)
            {
                userControl.XamlIslandMessage = this.WPFMessage;
            }
        }

        public string WPFMessage
        {
            get
            {
                return "Binding from WPF to UWP XAML";
            }
        }

        private void WindowsXamlHost_ChildChanged_1(object sender, EventArgs e)
        {
            global::Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost windowsXamlHost =
                sender as global::Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost;
            global::UWPClassLibrary.SplitViewDemo userControl =
                windowsXamlHost.GetUwpInternalObject() as global::UWPClassLibrary.SplitViewDemo;

            if (userControl != null)
            {
                userControl.IconList = new ObservableCollection<NavItem>
            {
                new NavItem { Symbol= Symbol.Save},
                new NavItem { Symbol= Symbol.Scan},
                new NavItem { Symbol= Symbol.Share},
                new NavItem { Symbol= Symbol.Stop},
                new NavItem { Symbol= Symbol.Video},
                new NavItem { Symbol= Symbol.Volume},
            };
            }
        }
    }

    
}
