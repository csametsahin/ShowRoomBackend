using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using SR.DataAccess.Concrete.Configurations.BaseConfiguration;
using SR.Entities.Concrete.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.DataAccess.Concrete.Mappings
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void ConfigureFields(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(50);
            builder.Property(e => e.Surname)
                .HasMaxLength(50);
            builder.Property(e => e.MailAddress)
                .HasMaxLength(80);
        }
    }
}
