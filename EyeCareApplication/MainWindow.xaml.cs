using System;
using System.Collections.Generic;
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
using System.Threading;
using System.Timers;
using System.ComponentModel;

namespace EyeCareApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CanvasVisibility Canvasvisibility { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Canvasvisibility = new CanvasVisibility();
            Canvasvisibility.Visibility = Visibility.Hidden;
            DataContext = Canvasvisibility;
                    
            
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventAsync);
            aTimer.Interval = 1200000;
            aTimer.Enabled = true;
        }

        private async void OnTimedEventAsync(object source, ElapsedEventArgs e)
        {           
            Canvasvisibility.Visibility = Visibility.Visible;
            Console.WriteLine("visible");
            await Task.Delay(TimeSpan.FromSeconds(20));
            Canvasvisibility.Visibility = Visibility.Hidden;
            Console.WriteLine("hidden");
        }
    }

    public class CanvasVisibility : INotifyPropertyChanged
    {
        private Visibility _Visibility;              

        public Visibility Visibility
        {
            get { return _Visibility; }
            set
            {
                _Visibility = value;
                NotifyPropertyChanged("Visibility");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
