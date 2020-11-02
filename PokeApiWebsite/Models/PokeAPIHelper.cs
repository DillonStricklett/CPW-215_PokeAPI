using PokeAPICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApiWebsite.Models
{
    public static class PokeAPIHelper
    {
        /// <summary>
        /// Get a Pokemon by id, moves will be sorted 
        /// in alphabetical order.
        /// </summary>
        /// <param name="desiredId"></param>
        /// <returns></returns>
        public static async Task<Pokemon> GetById(int desiredId)
        {
            PokeApiClient client = new PokeApiClient();
            Pokemon result = await client.GetPokemonById(desiredId);

            // Sorts moves by name alphabetically
            result.moves.OrderBy(m => m.move.name);

            return result;
        }

        public static PokeDexEntryViewModel GetPokeDexEntryFromPokemon(Pokemon result)
        {
            PokeDexEntryViewModel entry = new PokeDexEntryViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Height = result.Height.ToString(),
                Weight = result.Weight.ToString(),
                PokeDexImageUrl = result.Sprites.FrontDefault,
                MoveList = result.moves
                .OrderBy(m => m.move.name)
                .Select(m => m.move.name)
                .ToArray()
            };
            return entry;
        }
    }
}
