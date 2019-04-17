using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp3.Models;
using WpfApp3.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace WpfApp3.Views
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl
    {
        ObservableDataSource<Point> planeLocations = null;
        private FlightBoardViewModel flightViewModel;
        public FlightBoard()
        {
            InitializeComponent();
            this.flightViewModel = new FlightBoardViewModel();
            flightViewModel.PropertyChanged += Vm_PropertyChanged;
            this.DataContext = flightViewModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);

            plotter.AddLineGraph(planeLocations, 2, "Route");
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            {
                Point p1 = new Point(0, 0);            // Fill here!
                planeLocations.AppendAsync(Dispatcher, p1);
            }
        }

    }

}

