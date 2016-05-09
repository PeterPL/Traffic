using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class ChromosomeGenerator
    {
        public static Chromosome GetRandomChromosome(int numberOfGenes, int lengthOfGene)
        {
            Random rand = new Random();
            Chromosome chromosome = new Chromosome();
            for (int i = 0; i < numberOfGenes; i++)
            {
                Gene gen = GeneGenerator.GetRandomGene(lengthOfGene);
                chromosome.Genes.Add(gen);
            }
            return chromosome;
        }
        public static Chromosome GetSpecificChromosome(List<Gene> genes)
        {
            Chromosome chromosome = new Chromosome();
            for (int i = 0; i < genes.Count; i++)
            {
                chromosome.Genes.Add(genes[i]);
            }
            return chromosome;
        }

    }
}
