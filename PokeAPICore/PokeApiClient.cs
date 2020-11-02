using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PokeAPICore
{
    /// <summary>
    /// Client class to consume PokeApi
    /// https://pokeapi.co/
    /// </summary>
    public class PokeApiClient
    {
        static readonly HttpClient client;

        static PokeApiClient()
        {
            client = new HttpClient();
            // Must end with forward slash
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Add("User-Agent", "Dillon's PokeAPI");
        }

        /// <summary>
        /// Retrieve pokemon by name
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException">Thrown when Pokemon is not found</exception>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonByName(string name)
        {
            name = name.ToLower(); // Pokemon name must be lowercase
            return await GetPokemonByNameOrId(name);
        }

        private static async Task<Pokemon> GetPokemonByNameOrId(string name)
        {
            string url = $"pokemon/{name}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Pokemon>(responseBody);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"{name} does not exist");
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        /// <summary>
        /// Gets a Pokemon by their PokeDex Id number
        /// </summary>
        /// <param name="id">The Id of the Pokemon</param>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonById(int id)
        {
            return await GetPokemonByNameOrId(id.ToString());
        }
    }
}
