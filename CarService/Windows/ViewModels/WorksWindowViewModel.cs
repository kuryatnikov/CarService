using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Models;

namespace CarService.Windows.ViewModels
{
    public class WorksWindowViewModel : ViewModelBase
    {
        public WorksWindowViewModel(IEnumerable<EngWork> workTypes, IEnumerable<Work> works)
        {
            Works = works;
            WorkTypes = workTypes;
            SelectedDate = DateTime.Now;
            SelectedWork = WorkTypes.FirstOrDefault();
        }
        private IEnumerable<Work> _works;
        public IEnumerable<Work> Works
        {
            get => _works;
            set => SetProperty(ref _works, value);
        }
        private IEnumerable<EngWork> _workTypes;
        public IEnumerable<EngWork> WorkTypes
        {
            get => _workTypes;
            set => SetProperty(ref _workTypes, value);
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        private EngWork _selectedWork;
        public EngWork SelectedWork
        {
            get => _selectedWork;
            set => SetProperty(ref _selectedWork, value);
        }
    }
}
