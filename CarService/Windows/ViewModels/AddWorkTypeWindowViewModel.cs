using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Models;

namespace CarService.Windows.ViewModels
{
    public class AddWorkTypeWindowViewModel : ViewModelBase
    {
        public AddWorkTypeWindowViewModel(IEnumerable<EngType> engTypes)
        {
            EngTypes = engTypes;
        }

        private IEnumerable<EngType> _engTypes;

        public IEnumerable<EngType> EngTypes
        {
            get => _engTypes;
            set => SetProperty(ref _engTypes, value);
        }

        private EngType _selectedEngType;
        public EngType SelectedEngType
        {
            get => _selectedEngType;
            set => SetProperty(ref _selectedEngType, value);
        }

        private string _workType;
        public string WorkType
        {
            get => _workType;
            set => SetProperty(ref _workType, value);
        }

    }
}
