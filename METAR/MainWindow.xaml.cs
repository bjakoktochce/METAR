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
using System.Timers;

namespace METAR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
        private static Timer aTimer;

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Height = 28;
            Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth;
            Metar.ICAOAirportCode = "EPKT";

            Left = System.Windows.SystemParameters.WorkArea.Width - Width;
            Top = System.Windows.SystemParameters.WorkArea.Height - 28;


            //ColorGray = "#FF302D2D";
            //this.MetarText.Content = Metar.GetCurrentMetar();
            //this.Status.Content = this.Status.Content = "Last updated: " + DateTime.Now.ToString();
            Update();

            aTimer = new System.Timers.Timer(1000 * 60 * 5);
            aTimer.Enabled = true;
            aTimer.Elapsed += OnTimedEvent;
        }

        private void Update()
        {
            this.MetarText.Content = Metar.GetCurrentMetar();
            this.Status.Content = "Last updated: " + DateTime.Now.ToString();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Update();
            });
        }

        private void ContextMenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ContextMenuOptions_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.Show();
        }

        private void ContextMenuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void ContextMenuUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ContextMenuAirport_Click(object sender, RoutedEventArgs e)
        {
            AirportWindow airportWindow = new AirportWindow();
            airportWindow.Show();
        }
    }
}
