using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Man_Empleado_Click(object sender, RoutedEventArgs e)
        {
            Page p = new PEmpleado();
            this.NavigationService.Navigate(p);
        }

        private void Ing_Empleado_Click(object sender, RoutedEventArgs e)
        {
            Page p = new IngresoEmpleado();
            this.NavigationService.Navigate(p);

        }

        private void Sal_Empleado_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rep_Empleado_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
