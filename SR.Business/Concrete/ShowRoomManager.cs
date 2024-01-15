using SR.Business.Abstract;
using SR.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Business.Concrete
{
    public class ShowRoomManager : IShowRoomService
    {
        #region DIs
        private readonly IShowRoomDal _showRoomDal;
        public ShowRoomManager(IShowRoomDal showRoomDal)
        {
            _showRoomDal = showRoomDal;
        }
        #endregion
    }
}
