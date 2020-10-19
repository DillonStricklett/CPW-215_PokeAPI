using PokeAPICore;
using System;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main()
        {
            PokeApiClient client = new PokeApiClient();
            string result = await client.GetPokemonByName("geodude");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
