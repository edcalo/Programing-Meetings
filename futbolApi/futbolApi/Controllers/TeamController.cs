using FutbolApi.BussinesLogic.Interfaces;
using FutbolApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FutbolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public TeamController(ITeamService teamService, IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(Player model) => Ok(await _playerService.Add(model));


        [HttpPost]
        public async Task<IActionResult> AddTeam(Team model) => Ok(await _teamService.Add(model));

        [HttpGet]
        public async Task<IActionResult> GetPlayers() => Ok(await _playerService.GetAll());


        [HttpGet]
        public async Task<IActionResult> GetTeams() => Ok(await _teamService.GetAll());

        [HttpGet]
        public async Task<IActionResult> FirtPlayer() => Ok(await _playerService.OptimizedQuery());
    }
}