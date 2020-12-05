using Haskap.LayeredArchitecture.DataAccess.EntityConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WorkflowEngine.Core.Entities;

namespace WorkflowEngine.DataAccessLayer.DbContexts.Configurations
{
    public class BaseEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity, Guid>
        where TEntity : BaseEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            

            //if (typeof(IHasClusteredIndex).IsAssignableFrom(typeof(TEntity)))
            //{
            //    builder.HasKey(x => x.Id).IsClustered(false);
            //    builder.HasIndex(x => (x as IHasClusteredIndex).ClusteredIndex).IsClustered();
            //}
        }
    }
}
