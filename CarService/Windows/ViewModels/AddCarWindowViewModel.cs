using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Models;

namespace CarService.Windows.ViewModels
{
    public class AddCarWindowViewModel : ViewModelBase
    {
        public AddCarWindowViewModel(IEnumerable<EngType> engTypes)
        {
            EngTypes = engTypes;
            EngType = EngTypes.FirstOrDefault();
        }
        private IEnumerable<EngType> _engTypes;

        public IEnumerable<EngType> EngTypes
        {
            get => _engTypes;
            set => SetProperty(ref _engTypes, value);
        }

        private string _mark;

        public string Mark
        {
            get => _mark;
            set => SetProperty(ref _mark, value);
        }
        private string _model;

        public string Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }
        private string _number;

        public string Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        private EngType _engType;
        public EngType EngType
        {
            get => _engType;
            set => SetProperty(ref _engType, value);
        }
    }
}
