using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeAPICore;
using PokeApiWebsite.Models;

namespace PokeApiWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            PokeApiClient client = new PokeApiClient();
            Pokemon result = await client.GetPokemonById(1);

            List<string> resultMoves = new List<string>();
            foreach(Move currMove in result.moves)
            {
                resultMoves.Add(currMove.move.name);
            }

            resultMoves.Sort();

            //if it were a list of Pokemon
            // temp.OrderBy(p => p.name);

            PokeDexEntryViewModel entry = new PokeDexEntryViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Height = result.Height.ToString(),
                Weight = result.Weight.ToString(),
                PokeDexImageUrl = result.Sprites.FrontDefault,
                MoveList = resultMoves
            };

            return View(entry);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
