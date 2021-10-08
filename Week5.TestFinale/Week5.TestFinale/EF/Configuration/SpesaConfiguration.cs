using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.TestFinale.Model;

namespace Week5.TestFinale.EF.Configuration
{
    public class SpesaConfiguration : IEntityTypeConfiguration<Spesa>
    {
        public void Configure(EntityTypeBuilder<Spesa> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Data)
                .IsRequired();

            builder.Property(s => s.CategoriaId)
                .IsRequired();

            builder.Property(s => s.Descrizione)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(s => s.Utente)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Importo)
                .IsRequired();

            builder.Property(s => s.Approvato)
                .IsRequired();

            builder.HasCheckConstraint(
               "CK_Spesa_Importo",
               "Importo >= 0"
           );

            builder
               .HasOne(s => s.Categoria)
               .WithMany(c => c.Spese);
        }
    }
}
