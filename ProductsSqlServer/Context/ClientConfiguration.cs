using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductsSqlServer.Entities;

namespace ProductsSqlServer.Context
{

    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(client => client.Id);
            builder.HasMany(client => client.Orders)
                    .WithOne(order => order.Client)
                    .HasForeignKey(order => order.ClientId)
                    .IsRequired();
        }
    }
}
