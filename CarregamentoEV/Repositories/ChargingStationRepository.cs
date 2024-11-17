using CarregamentoEV.Data;
using CarregamentoEV.Models;
using Microsoft.EntityFrameworkCore;

namespace CarregamentoEV.Repositories
{
    public class ChargingStationRepository : IChargingStationRepository
    {
        private readonly ApplicationDbContext _context;

        public ChargingStationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChargingStation>> GetAllStationsAsync()
        {
            return await _context.ChargingStations.ToListAsync();
        }

        public async Task<ChargingStation> GetStationByIdAsync(int id)
        {
            return await _context.ChargingStations.FindAsync(id);
        }

        public async Task AddStationAsync(ChargingStation station)
        {
            _context.ChargingStations.Add(station);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStationAsync(ChargingStation station)
        {
            _context.ChargingStations.Update(station);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStationAsync(int id)
        {
            var station = await _context.ChargingStations.FindAsync(id);
            if (station != null)
            {
                _context.ChargingStations.Remove(station);
                await _context.SaveChangesAsync();
            }
        }
    }
}
