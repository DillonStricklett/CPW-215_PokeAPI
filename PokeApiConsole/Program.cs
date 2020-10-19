﻿using PokeAPICore;
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
                Pokemon result = await client.GetPokemonByName("pikachu");
                Console.WriteLine($"Pokemon Id: {result.id}" +
                    $"\nName: {result.name}" +
                    $"\nWeight (in hectograms): {result.weight}" +
                    $"\nHeight (in inches): {result.height}");
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