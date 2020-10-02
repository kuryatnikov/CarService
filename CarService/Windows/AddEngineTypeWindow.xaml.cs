using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace CarService.Windows
{
    /// <summary>
    /// Interaction logic for AddEngineTypeWindow.xaml
    /// </summary>
    public partial class AddEngineTypeWindow : Window
    {
        private readonly ApplicationContext _db;
        public AddEngineTypeWindow(ApplicationContext db)
        {
            _db = db;
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        private async void OkClick(object sender, RoutedEventArgs e)
        {
            await _db.EngTypes.LoadAsync();
            if (!EngType.Text.IsNullOrWhiteSpace() && _db.EngTypes.FirstOrDefault(_ => _.Type == EngType.Text) == null)
            {
                _db.EngTypes.Add(new EngType() {Type = EngType.Text});
                await _db.SaveChangesAsync();
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
            this.Close();
        }

        public bool? ShowDialog(Window owner)
        {
            Owner = owner;
            return ShowDialog();
        }
    }
}
