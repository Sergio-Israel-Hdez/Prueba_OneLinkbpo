using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UsuarioDAL
    {
        private EmpleadosContext _context = null;
        private IRepository<Usuario> _usuario = null;
        public UsuarioDAL()
        {
            this._context = new EmpleadosContext();
            _usuario = new BaseRepository<Usuario>(_context);
        }
        public Usuario SelectCommand(string usuario,string password)
        {
            var result = _usuario.Get(
                filter: x=>x.Usuario1==usuario&&x.Password==password
                );
            return result.FirstOrDefault();
        }
    }
}
