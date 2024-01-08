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
    public class ShowRoomConfiguration : BaseConfiguration<ShowRoom>
    {
        public override void ConfigureFields(EntityTypeBuilder<ShowRoom> builder)
        {
            builder.Property(e => e.Description).HasMaxLength(250);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Title).HasMaxLength(50);
        }
    }
}
