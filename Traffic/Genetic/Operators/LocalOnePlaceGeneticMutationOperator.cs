using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic.Operators
{
    public class LocalOnePlaceGeneticMutationOperator : IGeneticMutationOperator
    {
        private Random _rand;
        public LocalOnePlaceGeneticMutationOperator()
        {
            _rand = new Random();
        }
        public Chromosome Mutate(Chromosome chromosome)
        {
            List<Gene> listOfGenes = new List<Gene>();
            chromosome.Genes.ForEach(g => listOfGenes.Add(GeneGenerator.GetSpecificGene(g.Bits)));
            Chromosome mutatedChromosome = ChromosomeGenerator.GetSpecificChromosome(listOfGenes);

            int numberOfGenes = mutatedChromosome.Genes.Count;
            for(int i=0; i<numberOfGenes; i++)
            {
                int randomPlace = _rand.Next(0, mutatedChromosome.Genes[i].Bits.Length-1);
                if (mutatedChromosome.Genes[i].Bits[randomPlace] == 0)
                    mutatedChromosome.Genes[i].Bits[randomPlace] = 1;
                else
                    mutatedChromosome.Genes[i].Bits[randomPlace] = 0;
            }
            return mutatedChromosome;
        }
    }
}
