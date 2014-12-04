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
using BL;
using DA;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para IngresoEmpleado.xaml
    /// </summary>
    public partial class IngresoEmpleado : Page
    {
        BL_Asistencia bl = new BL_Asistencia();
        public IngresoEmpleado()
        {
            InitializeComponent();
            LlenarComboBox();
            Refrescar();
        }

        void LlenarComboBox()
        {
            List<int> horas = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                horas.Add(i);
            }
            List<int> minutos= new List<int>();
            for (int i = 0; i < 60; i++)
            {
                minutos.Add(i);
            }
            cbx_Hora.ItemsSource = horas;
            cbx_Minuto.ItemsSource = minutos;
            cbx_Hora.SelectedItem = cbx_Hora.Items[10];
            cbx_Minuto.SelectedItem = cbx_Minuto.Items[0];
        }
        void Refrescar()
        {
            dtg_Datos.ItemsSource = null;
            dtg_Datos.ItemsSource = bl.Mostrar();

        }

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {

            Asistencia aux = new Asistencia();
            DateTime dt = new DateTime(dtp_Fecha.SelectedDate.Value.Year,
                                       dtp_Fecha.SelectedDate.Value.Month,
                                       dtp_Fecha.SelectedDate.Value.Day,
                                       (int)cbx_Hora.SelectedItem,
                                       (int)cbx_Minuto.SelectedItem, 0);
            aux.ingreso = dt;

            var a = (new BL_Empleado()).Mostrar().FirstOrDefault(x => x.dni == txt_DNI.Text);
            if (a != null)
                aux.FK_Empleado = a.id;
            else
            {
                MessageBox.Show("Error");
                return;
            }
            if(!bl.ValidacionIngreso(aux))
            {
                MessageBox.Show("Error");
                return;
            }
            
            if (bl.Agregar(aux))
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
            Asistencia aux = dtg_Datos.SelectedItem as Asistencia;
            DateTime dt = new DateTime(dtp_Fecha.SelectedDate.Value.Year,
                                       dtp_Fecha.SelectedDate.Value.Month,
                                       dtp_Fecha.SelectedDate.Value.Day,
                                       (int)cbx_Hora.SelectedItem,
                                       (int)cbx_Minuto.SelectedItem, 0);
            aux.ingreso = dt;
            var a = (new BL_Empleado()).Mostrar().FirstOrDefault(x => x.dni == txt_DNI.Text);
            if (a != null && bl.ValidacionIngreso(aux))
                aux.FK_Empleado = a.id;
            else
            {
                MessageBox.Show("Error");
                return;
            }
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
            Asistencia aux = dtg_Datos.SelectedItem as Asistencia;
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
