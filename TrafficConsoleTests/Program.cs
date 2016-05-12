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
            IGeneticSelectionMethod selection = new TournamentGeneticSelectionMethod(2, CriterionOfSelection.MAX);
            IGeneticMutationOperator mutation = new OnePlaceGeneticMutationOperator();
            IGeneticCrossOperator cross = new OnePlaceGeneticCrossOperator();
            GeneticAlgorithm gen = new GeneticAlgorithm(8, 1, 5, 100,0.8, selection, test, cross, mutation);
            gen.RunAlgorithm();
            Console.WriteLine(gen.ShowPopulation());
            Console.ReadKey();
            
        }

    }

    
}
