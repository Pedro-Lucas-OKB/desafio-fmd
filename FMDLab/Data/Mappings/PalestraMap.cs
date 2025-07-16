using FMDLab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMDLab.Data.Mappings;

public class PalestraMap : IEntityTypeConfiguration<Palestra>
{
    public void Configure(EntityTypeBuilder<Palestra> builder)
    {
        builder.ToTable("Palestras");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.Titulo)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnType("NVARCHAR");
        
        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasMaxLength(2000)
            .HasColumnType("NVARCHAR");
        
        builder.Property(p => p.DataHora)
            .IsRequired()
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()");
        
        // Relacionamentos
        
        builder.HasMany(p => p.Participantes)
            .WithOne(p => p.Palestra)
            .HasForeignKey(p => p.PalestraId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}