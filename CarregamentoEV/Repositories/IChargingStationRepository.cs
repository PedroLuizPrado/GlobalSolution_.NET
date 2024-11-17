using CarregamentoEV.Models;

namespace CarregamentoEV.Repositories
{
    public interface IChargingStationRepository
    {
        Task<IEnumerable<ChargingStation>> GetAllStationsAsync();
        Task<ChargingStation> GetStationByIdAsync(int id);
        Task AddStationAsync(ChargingStation station);
        Task UpdateStationAsync(ChargingStation station);
        Task DeleteStationAsync(int id);
    }
}
