using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic.Genetic;
namespace TrafficConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {

            Chromosome c1 = ChromosomeGenerator.GetRandomChromosome(3, 4);
            Chromosome c2 = ChromosomeGenerator.GetRandomChromosome(3, 4);
            Console.WriteLine(c1.ToString());
            Chromosome c3 = GeneticOperator.MutateOnOnePlace(c1);
            Console.WriteLine(c3);

            Console.ReadKey();
            
        }

    }
}
