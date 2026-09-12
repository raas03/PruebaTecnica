using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaModel.Model;

namespace PruebaTecnicaInfrastucture.Configuration
{
    public class Personconfiguration: IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "General");
            builder.HasKey(x => x.PersonId);
        }
    }
}
