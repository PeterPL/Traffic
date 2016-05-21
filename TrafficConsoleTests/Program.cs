using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic.Genetic;
using Traffic.Genetic.Operators;

namespace TrafficConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            FitnessTestClass test = new FitnessTestClass();
            IGeneticSelectionMethod selection = new TournamentGeneticSelectionMethod(2);
            IGeneticMutationOperator mutation = new LocalOnePlaceGeneticMutationOperator();
            IGeneticCrossOperator cross = new LocalOnePlaceGeneticCrossOperator();
            PopulationWatcher logger = new PopulationWatcher();
            GeneticAlgorithm gen = new GeneticAlgorithm(4, 3, 5, 100, 0.2, selection,CriterionOfSelection.MAX, test, cross, mutation);
            gen.SetLogger(logger);
            gen.RunAlgorithm();
            
            Console.WriteLine(logger.ShowData());
            Console.WriteLine(gen.BestChromosome.ToString());
            Console.ReadKey();
            
        }

    }

    
}
