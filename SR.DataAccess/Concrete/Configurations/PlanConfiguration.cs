using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using SR.DataAccess.Concrete.Configurations.BaseConfiguration;
using SR.Entities.Concrete.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.DataAccess.Concrete.Configurations
{
    public class PlanConfiguration : BaseConfiguration<Plan>
    {
        public override void ConfigureFields(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(e => e.Description).HasMaxLength(250);
            builder.Property(e => e.Cost).IsRequired();
        }
    }
}
