using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dasigno.Infrastructure.Persistence.EntityConfigurations;


public class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
    {
        builder.ConfigureBase<Domain.Entities.User, int>();
    }
}