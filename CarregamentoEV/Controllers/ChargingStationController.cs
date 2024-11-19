using CarregamentoEV.Models;
using CarregamentoEV.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarregamentoEV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingStationController : Controller
    {
        private readonly IChargingStationRepository _repository;

        public ChargingStationController(IChargingStationRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stations = await _repository.GetAllStationsAsync();

            
            if (Request.Headers["Accept"] == "application/json")
                return Ok(stations);

            
            return View(stations);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var station = await _repository.GetStationByIdAsync(id);
            if (station == null) return NotFound();

            if (Request.Headers["Accept"] == "application/json")
                return Ok(station);

           
            return View(station);
        }

      
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChargingStation station)
        {
            if (!ModelState.IsValid) return View(station);

            await _repository.AddStationAsync(station);

           
            if (Request.Headers["Accept"] == "application/json")
                return CreatedAtAction(nameof(Details), new { id = station.Id }, station);

            return RedirectToAction(nameof(Index));
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ChargingStation station)
        {
            if (id != station.Id) return BadRequest();

            var existingStation = await _repository.GetStationByIdAsync(id);
            if (existingStation == null) return NotFound();

            existingStation.Nome = station.Nome;
            existingStation.Localizacao = station.Localizacao;
            existingStation.Disponivel = station.Disponivel;

            await _repository.UpdateStationAsync(existingStation);

            return NoContent();
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var station = await _repository.GetStationByIdAsync(id);
            if (station == null) return NotFound();

            await _repository.DeleteStationAsync(id);

            return NoContent();
        }
    }
}
