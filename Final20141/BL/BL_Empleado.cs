using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
namespace BL
{
    public class BL_Empleado
    {
        public BL_Empleado() { }

        public bool Agregar(Empleado e)
        {
            bool estado = false;
            try
            {
                using(Entidades ctx = new Entidades())
                {
                    ctx.Empleadoes.Add(e);
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
        public bool Modificar(Empleado e)
        {
            bool estado = false;
            try
            {
                using (Entidades ctx = new Entidades())
                {
                    var aux = ctx.Empleadoes.First(x => x.id == e.id);
                    aux.nombre = e.nombre;
                    aux.apellido = e.apellido;
                    aux.fechanac = e.fechanac;
                    aux.dni = e.dni;

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
        public bool Eliminar(Empleado e)
        {
            bool estado = false;
            try
            {
                using (Entidades ctx = new Entidades())
                {
                    ctx.Empleadoes.Remove(ctx.Empleadoes.First(x => x.id == e.id));
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
        public List<Empleado> Mostrar()
        {
            List<Empleado> lista = new List<Empleado>();
            using (Entidades ctx = new Entidades())
            {
                lista= ctx.Empleadoes.ToList();
            }
            return lista;
        }
    }
}
