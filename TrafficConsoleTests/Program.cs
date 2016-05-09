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
            FitnessTestClass test = new FitnessTestClass();
            GeneticAlgorithm gen = new GeneticAlgorithm(10, 1, 5, 10,0.1, new TournamentGeneticSelectionMethod(2, CriterionOfSelection.MAX), test, new OnePlaceGeneticCrossOperator(2), new OnePlaceGeneticMutationOperator());
            gen.RunAlgorithm();
            Console.WriteLine(gen.ShowPopulation());
            Console.ReadKey();
            
        }

    }

    
}
