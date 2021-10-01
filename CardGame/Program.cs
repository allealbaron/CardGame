using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using CardGame.Model.Interfaces;
using CardGame.Model.RegularDealer;
using CardGame.Model.RegularShuffler;

using CardGame.Model.FrenchCards;
using CardGame.Model.SpanishCards;

namespace CardGame
{
    /// <summary>
    /// Program that simulates a deck game
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        public static void Main()
        {
            IHost host = CreateSpanishHostBuilder().Build();

            ExecuteCardExample(host.Services);

        }

        /// <summary>
        /// Creates a Host with the French classes
        /// </summary>
        /// <returns>Host Builder</returns>
        private static IHostBuilder CreateFrenchHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services.AddTransient<IDeck, FrenchDeck>()
                            .AddTransient<ICard, FrenchCard>()
                            .AddTransient<IShuffler, RegularShuffler>()
                            .AddTransient<IDealer, RegularDealer>()
                            );
        }


        /// <summary>
        /// Creates a Host with the Spanish classes
        /// </summary>
        /// <returns>Host Builder</returns>
        private static IHostBuilder CreateSpanishHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services.AddTransient<IDeck, SpanishDeck>()
                            .AddTransient<ICard, SpanishCard>()
                            .AddTransient<IShuffler, RegularShuffler>()
                            .AddTransient<IDealer, RegularDealer>()
                            );
        }

        /// <summary>
        /// Executes a card example
        /// </summary>
        /// <param name="services">Services used</param>
        public static void ExecuteCardExample(IServiceProvider services)
        {
            IServiceScope serviceScope = services.CreateScope();
            
            IServiceProvider provider = serviceScope.ServiceProvider;

            IDeck deck = provider.GetRequiredService<IDeck>();

            deck.Shuffle();

            int counter = 1;

            while (!deck.IsEmptyDeck())
            {
                Console.WriteLine("{0}: {1}", counter, deck.DealOneCard().ToString());
                counter++;
                deck.Shuffle();
            }

        }
    }
}