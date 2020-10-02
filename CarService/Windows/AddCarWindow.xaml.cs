using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        private readonly ApplicationContext _db;
        public AddCarWindowViewModel ViewModel;
        public Car Car;
        public AddCarWindow(IEnumerable<EngType> engTypes, ApplicationContext db)
        {
            _db = db;
            ViewModel = new AddCarWindowViewModel(engTypes);
            DataContext = ViewModel;
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        public AddCarWindow(IEnumerable<EngType> engTypes, ApplicationContext db, Car car)
        {
            _db = db;
            var enumerable = engTypes as EngType[] ?? engTypes.ToArray();
            var engType = enumerable.FirstOrDefault(_ => _.Type == car.EngType);
            ViewModel = new AddCarWindowViewModel(enumerable)
            {
                EngType = engType,
                Mark = car.CarBrand,
                Model = car.CarModel,
                Number = car.CarNumber
            };

            Car = car;
            DataContext = ViewModel;
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        private async void AddCarButtonClick(object sender, RoutedEventArgs e)
        {

            if (ViewModel.EngType != null && !ViewModel.Mark.IsNullOrWhiteSpace()
                                          && !ViewModel.Model.IsNullOrWhiteSpace() &&
                                          !ViewModel.Number.IsNullOrWhiteSpace())
            {
                if (Car == null)
                {
                    var car = new Car()
                    {
                        CarModel = ViewModel.Model,
                        CarBrand = ViewModel.Mark,
                        CarNumber = ViewModel.Number,
                        EngType = ViewModel.EngType.Type
                    };
                    _db.Phones.Add(car);
                }
                else
                {
                    _db.Phones.AddOrUpdate(new Car()
                    {
                        Id = Car.Id,
                        CarBrand = ViewModel.Mark,
                        CarModel = ViewModel.Model,
                        CarNumber = ViewModel.Number,
                        EngType = ViewModel.EngType.Type
                    });
                }

                await _db.SaveChangesAsync();
                DialogResult = true;
                this.Close();
            }
            else
            {
                var err = new ErrorWindow("Заполните поля!");
                err.ShowDialog(this);
            }
        }

        public bool? ShowDialog(Window owner)
        {
            Owner = owner;
            return ShowDialog();
        }
    }
}
