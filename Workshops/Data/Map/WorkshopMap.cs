using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshops.Models;

namespace Workshops.Data.Map
{
    public class WorkshopMap : IEntityTypeConfiguration<WorkshopModel>

    {

        public void Configure(EntityTypeBuilder<WorkshopModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataRealizacao).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(500);
        }
    }
}