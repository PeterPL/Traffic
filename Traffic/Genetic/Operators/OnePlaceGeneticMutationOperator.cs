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
            List<Gene> listOfGenes = new List<Gene>();
            chromosome.Genes.ForEach(g => listOfGenes.Add(GeneGenerator.GetSpecificGene(g.Bits)));
            Chromosome mutatedChromosome = ChromosomeGenerator.GetSpecificChromosome(listOfGenes);

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
