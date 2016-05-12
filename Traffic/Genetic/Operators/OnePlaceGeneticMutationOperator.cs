using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class OnePlaceGeneticMutationOperator : IGeneticMutationOperator
    {
        private Random _rand;
        public OnePlaceGeneticMutationOperator()
        {
            _rand = new Random();
        }
        public Chromosome Mutate(Chromosome chromosome)
        {
            Chromosome mutatedChromosome = ChromosomeGenerator.GetSpecificChromosome(chromosome.Genes);
   
            int randomMutatePlace = _rand.Next(0, mutatedChromosome.Length);
            int placeHelper = 0;
            for (int i = 0; i < mutatedChromosome.Genes.Count; i++)
            {
                for (int j = 0; j < mutatedChromosome.Genes[i].Bits.Length; j++)
                {
                    if (placeHelper == randomMutatePlace)
                    {
                        if (mutatedChromosome.Genes[i].Bits[j] == 1)
                            mutatedChromosome.Genes[i].Bits[j] = 0;
                        else
                            mutatedChromosome.Genes[i].Bits[j] = 1;
                    }
                    placeHelper++;
                }
            }
            return mutatedChromosome;
        }
    }
}
