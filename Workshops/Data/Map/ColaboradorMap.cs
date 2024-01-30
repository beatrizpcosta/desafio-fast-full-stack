using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshops.Models;

namespace Workshops.Data.Map
{
    public class ColaboradorMap : IEntityTypeConfiguration<ColaboradorModel>

    {

        public void Configure(EntityTypeBuilder<ColaboradorModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
        }
    }
}
