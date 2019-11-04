using System;
using System.Text;
using AGN;

namespace GENALG
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.Write("Waiting input: ");
            var input = Console.ReadLine();

            var AG = new AG(0.01M, input, 30);
            AG.StartPopulation();
            
            var generation = 0;

            while (AG.GetBestIndividual().Fitness < 100.00)
            {                
                AG.CalcFitness();
                AG.RouletteWheel();
                AG.Crossover();
                AG.RunMutation();

                Console.WriteLine($"Generation: {generation}");
                Console.WriteLine($"Best fitness: {AG.GetBestIndividual().Fitness}");
                Console.WriteLine($"Best individual: {AG.GetBestIndividual().Chromossomes}");            
                Console.WriteLine();
                generation++;
            }
        }
    }
}
