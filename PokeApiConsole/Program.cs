using PokeAPICore;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main()
        {
            PokeApiClient client = new PokeApiClient();
            Pokemon result = await client.GetPokemonByName("geodude");
            Console.WriteLine($"Pokemon Id: {result.id}" + 
                $"\nName: {result.name}" +
                $"\nWeight (in hectograms): {result.weight}" +
                $"\nHeight (in inches): {result.height}");
            Console.ReadKey();
        }
    }
}
