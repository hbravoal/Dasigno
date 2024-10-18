using Dasigno.Domain.Interfaces.Entities;
using Dasigno.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dasigno.Infrastructure.Persistence.EntityConfigurations;

public static class BaseEntityTypeConfiguration
{
    public static void ConfigureBase<TEntity, TId>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IEntity<TId>
        where TId : struct
    {
        builder.ToTable(typeof(TEntity).Name, UserContext.DEFAULT_SCHEMA);
        builder.HasKey(ci => ci.Id);
    }
}