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
using System.Windows.Shapes;
using CarService.Models;
using CarService.Windows.ViewModels;

namespace CarService.Windows
{
    /// <summary>
    /// Interaction logic for AddWorkTypeWindow.xaml
    /// </summary>
    public partial class AddWorkTypeWindow : Window
    {
        public readonly AddWorkTypeWindowViewModel ViewModel;
        private readonly ApplicationContext _db;
        public AddWorkTypeWindow(IEnumerable<EngType> engTypes, ApplicationContext db)
        {
            _db = db;
            ViewModel = new AddWorkTypeWindowViewModel(engTypes);
            DataContext = ViewModel;
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        private async void OkClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedEngType != null && !ViewModel.SelectedEngType.Type.IsNullOrWhiteSpace() 
                                                  && !ViewModel.WorkType.IsNullOrWhiteSpace())
            {
                _db.EngWorks.Add(new EngWork()
                    {EngType = ViewModel.SelectedEngType.Type, WorkType = ViewModel.WorkType});
                await _db.SaveChangesAsync();


            this.Close();
            }
            else
            {
                var err = new ErrorWindow("Заполните поля!");
                err.ShowDialog(this);
            }
        }

        private async void AddEngineTypeClick(object sender, RoutedEventArgs e)
        {
            var addEngineTypeWindow = new AddEngineTypeWindow(_db);
            if (addEngineTypeWindow.ShowDialog(this) == true)
            {
                ViewModel.EngTypes = await _db.EngTypes.ToArrayAsync();
            }
        }

        public bool? ShowDialog(Window owner)
        {
            Owner = owner;
            return ShowDialog();
        }
    }
}
