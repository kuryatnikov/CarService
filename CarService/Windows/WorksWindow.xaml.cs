using System;
using System.Collections;
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
using System.Windows.Shapes;
using CarService.Models;
using CarService.Windows.ViewModels;

namespace CarService.Windows
{
    /// <summary>
    /// Interaction logic for WorksWindow.xaml
    /// </summary>
    public partial class WorksWindow : Window
    {
        public WorksWindowViewModel ViewModel;
        private readonly ApplicationContext _db;
        private readonly Car _car;
        public WorksWindow(IEnumerable<EngWork> engWorks , ApplicationContext db, Car car, IEnumerable<Work> works)
        {
            _car = car;
            _db = db;
            ViewModel = new WorksWindowViewModel(engWorks, works);
            DataContext = ViewModel;
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }
        public bool? ShowDialog(Window owner)
        {
            Owner = owner;
            return ShowDialog();
        }

        private async void AddWorkClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedWork != null)
            {
                var work = new Work()
                {
                    CarNumber = _car.CarNumber,
                    Date = ViewModel.SelectedDate.ToShortDateString(),
                    WorkType = ViewModel.SelectedWork.WorkType
                };
                _db.Works.Add(work);
                await _db.SaveChangesAsync();
                this.Close();
            }
            else
            {
                var err = new ErrorWindow("Выберите тип работы!");
                err.ShowDialog(this);
            }
        }
    }
}
