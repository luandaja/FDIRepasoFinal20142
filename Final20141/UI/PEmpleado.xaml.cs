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
using DA;
using BL;
namespace UI
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class PEmpleado : Page
    {
        BL_Empleado bl = new BL_Empleado();
        public PEmpleado()
        {
            InitializeComponent();
            Refrescar();
        }

        void Refrescar()
        {
            dtg_Datos.ItemsSource = null;
            dtg_Datos.ItemsSource = bl.Mostrar();

        }

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {

            Empleado aux = new Empleado();
            aux.dni = txt_DNI.Text.Trim();
            aux.nombre = txt_Nombre.Text.Trim();
            aux.apellido = txt_Apellido.Text.Trim();
            aux.fechanac = dtp_Fecha.SelectedDate.Value;
            if(bl.Agregar(aux))
            {
                MessageBox.Show("Éxito");
                Refrescar();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_Modificar_Click(object sender, RoutedEventArgs e)
        {
            Empleado aux = dtg_Datos.SelectedItem as Empleado;
            aux.dni = txt_DNI.Text.Trim();
            aux.nombre = txt_Nombre.Text.Trim();
            aux.apellido = txt_Apellido.Text.Trim();
            aux.fechanac = dtp_Fecha.SelectedDate.Value;
            if (bl.Modificar(aux))
            {
                MessageBox.Show("Éxito");
                Refrescar();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado aux = dtg_Datos.SelectedItem as Empleado;
            if (bl.Eliminar(aux))
            {
                MessageBox.Show("Éxito");
                Refrescar();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
