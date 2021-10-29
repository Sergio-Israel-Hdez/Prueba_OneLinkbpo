using Entities;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer
{
    public class AreaDAL
    {
        private EmpleadosContext _context = null;
        private IRepository<Area> _area = null;
        public AreaDAL()
        {
            this._context = new EmpleadosContext();
            _area = new BaseRepository<Area>(_context);
        }
        public List<Area> SelectCommand()
        {
            var result = _area.Get(
                filter: null,
                orderBy: null
                );
            return result.ToList();
        }
        public void InsertCommand(Area area)
        {
            Area newArea = new Area();
            newArea.NombreArea = area.NombreArea;
            _area.Insert(newArea);
            _area.Save();
        }
        public void DeleteCommand(int idArea)
        {
            _area.Delete(idArea);
            _area.Save();
        }
        public Area SelectCommandBy_IdArea(int idArea)
        {
            var result = _area.GetById(idArea);
            return result;
        }
        public void UpdateCommand(Area area)
        {
            Area updateArea = _area.GetById(area.IdArea);
            updateArea.NombreArea = area.NombreArea;
            _area.Update(updateArea);
            _area.Save();
        }
    }
}
