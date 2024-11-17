using CarregamentoEV.Models;
using CarregamentoEV.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarregamentoEV.Controllers
{
    public class ChargingStationController : Controller
    {
        private readonly IChargingStationRepository _repository;

        public ChargingStationController(IChargingStationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var stations = await _repository.GetAllStationsAsync();
            return View(stations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var station = await _repository.GetStationByIdAsync(id);
            if (station == null) return NotFound();
            return View(station);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChargingStation station)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddStationAsync(station);
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var station = await _repository.GetStationByIdAsync(id);
            if (station == null) return NotFound();
            return View(station);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ChargingStation station)
        {
            if (id != station.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _repository.UpdateStationAsync(station);
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var station = await _repository.GetStationByIdAsync(id);
            if (station == null) return NotFound();
            return View(station);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteStationAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
