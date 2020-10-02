using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using CarService.Models;
using CarService.Windows.ViewModels;

namespace CarService.Windows
{
    /// <summary>
    /// Логика взаимодействия для CarsWindow.xaml
    /// </summary>
    public partial class CarsWindow : Window
    {
        private readonly ApplicationContext _db;
        public CarsWindowViewModel ViewModel;
        public CarsWindow()
        {
            _db = new ApplicationContext();
            ViewModel = new CarsWindowViewModel();
            DataContext = ViewModel;
            ViewModel.Cars = _db.Phones.ToArray();
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        private async void AddCarButtonClick(object sender, RoutedEventArgs e)
        {
            await _db.EngTypes.LoadAsync();
            var engTypes = await _db.EngTypes.ToArrayAsync();
            var addCarWindow = new AddCarWindow(engTypes, _db);
            if (addCarWindow.ShowDialog(this) == true)
            {
                ViewModel.Cars = await _db.Phones.ToArrayAsync();
            }
        }

        private async void AddWorkTypeButtonClick(object sender, RoutedEventArgs e)
        {
            await _db.EngTypes.LoadAsync();
            var engTypes = await _db.EngTypes.ToArrayAsync();
            var addWorkTypeWindow = new AddWorkTypeWindow(engTypes, _db);
            addWorkTypeWindow.ShowDialog(this);
        }

        private async void ChangeCarButtonClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedCar != null)
            {
                var engTypes = await _db.EngTypes.ToArrayAsync();
                var addCarWindow = new AddCarWindow(engTypes, _db, ViewModel.SelectedCar);
                if (addCarWindow.ShowDialog(this) == true)
                {
                    ViewModel.Cars = await _db.Phones.ToArrayAsync();
                }
            }
            else
            {
                var err = new ErrorWindow("Выберите автомобиль из списка!");
                err.ShowDialog(this);
            }
        }

        private async void WorksButtonClick(object sender, RoutedEventArgs e)
        {
            await _db.EngWorks.LoadAsync();
            var engWorks = await _db.EngWorks.Where(_=>_.EngType == ViewModel.SelectedCar.EngType).ToArrayAsync();
            await _db.Works.LoadAsync();
            var works = await _db.Works.Where(_ => _.CarNumber == ViewModel.SelectedCar.CarNumber).ToArrayAsync();
            var worksWindow = new WorksWindow(engWorks, _db, ViewModel.SelectedCar, works);
            worksWindow.ShowDialog(this);
        }

        private async void DeleteCarClick(object sender, RoutedEventArgs e)
        {
            _db.Phones.Remove(ViewModel.SelectedCar);
            await _db.SaveChangesAsync();
            ViewModel.Cars = await _db.Phones.ToArrayAsync();
            ViewModel.SelectedCar = null;
        }
    }
}
