using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CarService.Annotations;
using CarService.Models;

namespace CarService.Windows.ViewModels
{
    public class CarsWindowViewModel : ViewModelBase
    {
        private IEnumerable<Car> _cars;

        public IEnumerable<Car> Cars
        {
            get => _cars;
            set => SetProperty(ref _cars, value);
        }

        private Car _selectedCar;

        public Car SelectedCar
        {
            get => _selectedCar;
            set => SetProperty(ref _selectedCar, value);
        }

    }
}
