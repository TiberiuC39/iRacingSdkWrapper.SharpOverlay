using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using iRacingSdkWrapper;
using iRacingSimulator.Drivers;
using Path = System.IO.Path;

namespace iRacingSimulator.Examples.IncidentLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Driver> _drivers;
        private readonly ObservableCollection<Incident> _incidents;
        private readonly ICollectionView _driversView, _incidentsView;

        public MainWindow()
        {
            InitializeComponent();

            _drivers = new ObservableCollection<Driver>();
            _incidents = new ObservableCollection<Incident>();
            _driversView = CollectionViewSource.GetDefaultView(_drivers);
            _incidentsView = CollectionViewSource.GetDefaultView(_incidents);

            driversGrid.ItemsSource = _driversView;
            incsGrid.ItemsSource = _incidentsView;

            _driversView.SortDescriptions.Add(new SortDescription("CarNumber", ListSortDirection.Ascending));
            _incidentsView.SortDescriptions.Add(new SortDescription("SessionTime", ListSortDirection.Descending));

            Sim.Instance.SessionInfoUpdated += OnSessionInfoUpdated;
            Sim.Instance.Start();
        }

        private void OnSessionInfoUpdated(object sender, SdkWrapper.SessionUpdatedEventArgs e)
        {
            SaveSessionInfo(e);
        }       

        private void SaveSessionInfo(SdkWrapper.SessionUpdatedEventArgs e)
        {
            var dir = "output";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            var path = Path.Combine(dir, $"sessioninfo_{e.UpdateTime.ToString("0")}.txt");

            var sessionInfo = JsonSerializer.Serialize(e.SessionInfo, new JsonSerializerOptions()
            {
                WriteIndented = true,
            });

            File.WriteAllText(path, sessionInfo);
        }
    }
}
