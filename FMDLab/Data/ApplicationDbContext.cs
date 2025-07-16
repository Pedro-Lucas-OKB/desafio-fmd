using FMDLab.Data.Mappings;
using FMDLab.Models;
using Microsoft.EntityFrameworkCore;

namespace FMDLab.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Palestra> Palestras { get; set; } = null!;
    public DbSet<Participante> Participantes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=app.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ParticipanteMap());
        modelBuilder.ApplyConfiguration(new PalestraMap());
    }
}