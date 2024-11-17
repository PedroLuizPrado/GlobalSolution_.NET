namespace CarregamentoEV.Data
{
    using CarregamentoEV.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ChargingStation> ChargingStations { get; set; }
        public DbSet<ChargingSession> ChargingSessions { get; set; }
    }
}
