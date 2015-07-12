using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure
{
    public class UnitOfWorkDataModels
    {
        #region Fields
        private readonly ApplicationDbContext _context;

        #endregion

        public UnitOfWorkDataModels()
        {
            _context = new ApplicationDbContext();
        }

    }
}
