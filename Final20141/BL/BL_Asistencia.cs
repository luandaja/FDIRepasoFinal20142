using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
namespace BL
{
    public class BL_Asistencia
    {
        public BL_Asistencia() { }

        public bool Agregar(Asistencia e)
        {
            bool estado = false;
            try
            {
                using (Entidades ctx = new Entidades())
                {
                    ctx.Asistencias.Add(e);
                    ctx.SaveChanges();
                    estado = true;
                }
            }
            catch (Exception)
            {
                estado = false;
            }
            return estado;
        }
        
        public int CalcularHoras(Asistencia e)
        {
            int horas;
            horas = e.salida.Value.Hour - e.ingreso.Hour;
            return horas;
        }

        public bool Modificar(Asistencia e)
        {
            bool estado = false;
            try
            {
                using (Entidades ctx = new Entidades())
                {
                    var aux = ctx.Asistencias.First(x => x.id == e.id);

                    aux.ingreso = e.ingreso;
                    aux.salida = e.salida;
                    aux.horastrabajadas = CalcularHoras(e);
                    aux.FK_Empleado = e.FK_Empleado;

                    ctx.SaveChanges();
                    estado = true;
                }
            }
            catch (Exception)
            {
                estado = false;
            }
            return estado;
        }
        public bool Eliminar(Asistencia e)
        {
            bool estado = false;
            try
            {
                using (Entidades ctx = new Entidades())
                {
                    ctx.Asistencias.Remove(ctx.Asistencias.First(x => x.id == e.id));
                    ctx.SaveChanges();
                    estado = true;
                }
            }
            catch (Exception)
            {
                estado = false;
            }   
            return estado;
        }
        public List<Asistencia> Mostrar()
        {
            List<Asistencia> lista = new List<Asistencia>();
            using (Entidades ctx = new Entidades())
            {
                lista = ctx.Asistencias.ToList();
            }
            return lista;
        }
        public List<Asistencia> Mostrar(DateTime LI, DateTime LS, Empleado e)
        {
            List<Asistencia> lista = new List<Asistencia>();
            using (Entidades ctx = new Entidades())
            {
                lista = ctx.Asistencias.ToList().FindAll(x=>x.ingreso.Date >= LI.Date &&
                                                            x.ingreso.Date <= LS.Date &&
                                                            x.FK_Empleado == e.id);

            }
            return lista;
        }
        public int MostrarHoras(DateTime LI, DateTime LS, Empleado e)
        {
            List<Asistencia> lista = new List<Asistencia>();
            int horasTrabajadasTotales=0;
            using (Entidades ctx = new Entidades())
            {
                lista = ctx.Asistencias.ToList().FindAll(x => x.ingreso.Date >= LI.Date &&
                                                              x.ingreso.Date <= LS.Date &&
                                                              x.FK_Empleado == e.id);
                //lista.ForEach(x => horasTrabajadasTotales += x.horastrabajadas.Value);
                foreach (var aux  in lista)
                {
                    if(aux!= null)
                        horasTrabajadasTotales += aux.horastrabajadas.Value;
                }
            }
            return horasTrabajadasTotales;
        }
        
        public bool ValidacionIngreso(Asistencia e)
        {
            bool estado = false;
            try
            {
                using (Entidades ctx = new Entidades())
                {
                    var aux = ctx.Asistencias.ToList().FindAll(x => x.FK_Empleado == e.FK_Empleado).ToList();

                    if (aux != null)
                    {
                        int contador = 0;
                        contador = aux.FindAll(x => x.ingreso.Date == e.ingreso.Date).Count;
                        if (contador > 0)
                            estado = false;
                        else
                            estado = true;
                    }
                    else
                    {
                        estado = true;
                    }
                }
            }
            catch (Exception)
            {
                estado = false;
            }
            return estado;
        }
        public bool ValidacionSalida(Asistencia e)
        {
            bool estado = false;
            try
            {
                using (Entidades ctx = new Entidades())
                {
                    var aux = ctx.Asistencias.ToList().FindAll(x => x.FK_Empleado == e.FK_Empleado).ToList();

                    if (aux != null)
                    {
                        bool existeIngreso;
                        existeIngreso = e.ingreso != null;
                        if (existeIngreso )
                        {
                            int contador = 0;
                            contador = aux.FindAll(x => x.salida.Value.Date == e.salida.Value.Date).Count;
                            if (contador > 0 || e.ingreso.Date< e.salida.Value.Date)
                                estado = false;
                            else
                                estado = true;
                        }
                        else
                        {
                            estado = false;
                        }
                    }
                    else
                    {
                        estado = true;
                    }
                }
            }
            catch (Exception)
            {
                estado = false;
            }
            return estado;  
        }
    }
}
