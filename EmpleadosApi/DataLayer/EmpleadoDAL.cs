using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class EmpleadoDAL
    {
        private EmpleadosContext _context = null;
        private IRepository<Empleado> _empleado = null;
        public EmpleadoDAL()
        {
            this._context = new EmpleadosContext();
            _empleado = new BaseRepository<Empleado>(_context);
        }
        public List<Empleado> SelectCommand()
        {
            var result = _empleado.Get(
                filter: null,
                orderBy: x => x.OrderBy(x => x.IdEmpleado)
                );
            return result.ToList();
            
        }
        public void InsertCommand(Empleado empleado)
        {            
            Empleado newEmpleado = new Empleado()
            {
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                NumeroDocumento = empleado.NumeroDocumento,
                IdDocumento = empleado.IdDocumento,
                IdArea = empleado.IdArea                
            };
            _empleado.Insert(newEmpleado);
            _empleado.Save();
        }
        public void DeleteCommand(int idEmpleado)
        {
            _empleado.Delete(idEmpleado);
            _empleado.Save();
        }
        public Empleado SelectCommandBy_IdEmpleado(int idEmpleado)
        {
            var result = _empleado.GetById(idEmpleado);
            return result;
        }
        public void UpdateCommand(Empleado empleado)
        {
            Empleado updateEmpleado = _empleado.GetById(empleado.IdEmpleado);
            updateEmpleado.Nombre = empleado.Nombre;
            updateEmpleado.Apellido = empleado.Apellido;
            updateEmpleado.NumeroDocumento = empleado.NumeroDocumento;
            updateEmpleado.IdDocumento = empleado.IdDocumento;
            updateEmpleado.IdArea = empleado.IdArea;
            _empleado.Update(updateEmpleado);
            _empleado.Save();

        }
    }
}
