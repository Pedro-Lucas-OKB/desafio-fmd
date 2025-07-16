using FMDLab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMDLab.Data.Mappings;

public class ParticipanteMap : IEntityTypeConfiguration<Participante>
{
    public void Configure(EntityTypeBuilder<Participante> builder)
    {
        builder.ToTable("Participantes");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(120)
            .HasColumnType("NVARCHAR");
        
        builder.Property(p => p.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
        
        builder.Property(p => p.Telefone)
            .IsRequired()
            .HasColumnName("Telefone")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);
        
        // Relacionamentos
        
        builder.HasOne(p => p.Palestra)
            .WithMany(p => p.Participantes)
            .HasForeignKey(p => p.PalestraId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}