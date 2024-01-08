using SR.Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Entities.Concrete.DbModels
{
    public class ShowRoomImages : BaseEntity
    {
        public int ShowRoomId { get; set; }
        public string ImagePath { get; set; }
        public int DisplayOrder { get; set; }
    }
}
