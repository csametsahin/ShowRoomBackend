using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SR.Core.DataAccess.Constants;
using SR.Entities.Concrete.BaseEntities;

namespace SR.DataAccess.Concrete.Configurations.BaseConfiguration
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            ConfigureFields(builder);
            builder.Property(c => c.CreatedDate).HasColumnType(EntityColumnTypes.DATETIME).HasDefaultValueSql(DefaultValues.GETDATE);

            builder.Property(c => c.CreatedBy)
                .HasDefaultValue(DefaultValues.FROMSYSTEM)
                .HasMaxLength(100);
            // is sparese means mostlye empty to save space on db
            builder.Property(c => c.UpdatedBy)
                .HasMaxLength(100)
                .IsSparse();
            builder.Property(c => c.UpdatedDate)
                .IsSparse();

            builder.Property(c => c.IsDeleted).HasDefaultValue(EntityColumnTypes.Bool);
            builder.HasQueryFilter(_ => !_.IsDeleted);
        }
        public abstract void ConfigureFields(EntityTypeBuilder<TEntity> builder);
    }

}
