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
    public class CreditCardConfiguration : BaseConfiguration<CreditCard>
    {
        public override void ConfigureFields(EntityTypeBuilder<CreditCard> builder)
        {
              
        }
    }
}
