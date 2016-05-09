using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class GeneticOperator
    {
        public static Chromosome[] CrossOnOneSpecificPlace(Chromosome chromosomeOne, Chromosome chromosomeTwo, int place)
        {
                int numberOfGenes = chromosomeOne.Genes.Count;

                Chromosome childChromosomeOne = ChromosomeGenerator.GetSpecificChromosome(chromosomeOne.Genes);
                Chromosome childChromosomeTwo = ChromosomeGenerator.GetSpecificChromosome(chromosomeTwo.Genes);
            
                int whereIAm = place;
                for (int i = 0; i < numberOfGenes; i++)
                {
                    for (int j = 0; j < childChromosomeOne.Genes[i].Bits.Length; j++)
                    {
                        if (whereIAm > 0)
                                whereIAm -= 1;

                        else
                        {
                            int tempOne = childChromosomeOne.Genes[i].Bits[j];
                            int tempTwo = childChromosomeTwo.Genes[i].Bits[j];

                            if(tempOne != tempTwo)
                            {
                                childChromosomeOne.Genes[i].Bits[j] = tempTwo;
                                childChromosomeTwo.Genes[i].Bits[j] = tempOne;
                            }
                        }
                        
                    }
                }
                return new Chromosome[]{childChromosomeOne, childChromosomeTwo};
        }
      
        public static Chromosome MutateOnOnePlace(Chromosome chromosomeToMutate)
        {
            Chromosome mutatedChromosome = ChromosomeGenerator.GetSpecificChromosome(chromosomeToMutate.Genes);
            Random rand = new Random();
            int mutatePlace = rand.Next(0, mutatedChromosome.Length-1);
            int placeHelper = 0;
            for(int i = 0; i<mutatedChromosome.Genes.Count; i++)
            {
                for(int j=0; j<mutatedChromosome.Genes[i].Bits.Length; j++)
                {
                    if(placeHelper == mutatePlace)
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
