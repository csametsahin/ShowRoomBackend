using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SR.DataAccess.Concrete.Configurations.BaseConfiguration;
using SR.Entities.Concrete.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.DataAccess.Concrete.Configurations
{
    public class ShowRoomImagesConfiguration : BaseConfiguration<ShowRoomImages>
    {
        public override void ConfigureFields(EntityTypeBuilder<ShowRoomImages> builder)
        {
            builder.Property(e => e.ImagePath).HasMaxLength(100);
        }
    }
}
