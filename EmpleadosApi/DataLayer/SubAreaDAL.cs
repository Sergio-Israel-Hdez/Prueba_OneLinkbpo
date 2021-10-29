using Entities;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer
{
    public class SubAreaDAL
    {
        private EmpleadosContext _context = null;
        private IRepository<SubArea> _subarea = null;
        public SubAreaDAL()
        {
            this._context = new EmpleadosContext();
            _subarea = new BaseRepository<SubArea>(_context);
        }
        public List<SubArea> SelectCommand()
        {
            var result = _subarea.Get(
                filter: null,
                orderBy: null
                );
            return result.ToList();
        }
        public void InsertCommand(SubArea area)
        {
            SubArea newArea = new SubArea()
            {
                IdArea = area.IdArea,
                NombreSubArea = area.NombreSubArea
            };
            _subarea.Insert(newArea);
            _subarea.Save();
        }
        public void DeleteCommand(int idArea)
        {
            _subarea.Delete(idArea);
            _subarea.Save();
        }
        public SubArea SelectCommandBy_IdArea(int idArea)
        {
            var result = _subarea.GetById(idArea);
            return result;
        }
        public void UpdateCommand(SubArea area)
        {
            SubArea updateArea = _subarea.GetById(area.IdSubArea);
            updateArea.IdArea = area.IdArea;
            updateArea.NombreSubArea = area.NombreSubArea;
            _subarea.Update(updateArea);
            _subarea.Save();
        }
    }
}
