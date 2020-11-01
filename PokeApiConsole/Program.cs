using PokeAPICore;
using System;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main()
        {
            PokeApiClient client = new PokeApiClient();
            try
            {
                // Pokemon result = await client.GetPokemonByName("pikachu");
                Pokemon result = await client.GetPokemonById(-463);
                Console.WriteLine($"Pokemon Id: {result.Id}" +
                    $"\nName: {result.Name}" +
                    $"\nWeight (in hectograms): {result.Weight}" +
                    $"\nHeight (in inches): {result.Height}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("I'm sorry that Pokemon does not exist.");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Please try again later");
            }

            Console.ReadKey();
        }
    }
}
