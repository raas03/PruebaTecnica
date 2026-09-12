using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaModel.Model;

namespace PruebaTecnicaInfrastucture.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Students", "Academic");
            entityTypeBuilder.HasKey(x => x.StudentId);

        }
    }
}
