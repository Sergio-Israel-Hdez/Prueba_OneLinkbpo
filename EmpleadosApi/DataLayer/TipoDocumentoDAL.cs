using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TipoDocumentoDAL
    {
        private EmpleadosContext _context = null;
        private IRepository<TipoDocumento> _tipoDocumento = null;
        public TipoDocumentoDAL()
        {
            this._context = new EmpleadosContext();
            _tipoDocumento = new BaseRepository<TipoDocumento>(_context);
        }
        public List<TipoDocumento> SelectCommand()
        {
            var result = _tipoDocumento.Get(
                filter: null,
                orderBy: null
                );
            return result.ToList();
        }
    }
}
