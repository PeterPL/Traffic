using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class OnePlaceGeneticCrossOperator : IGeneticCrossOperator
    {
        private int _place;
        public OnePlaceGeneticCrossOperator(int place)
        {
            _place = place;
        }
        public List<Chromosome> Cross(Chromosome chromosomeOne, Chromosome chromosomeTwo)
        {
            int numberOfGenes = chromosomeOne.Genes.Count;

            Chromosome childChromosomeOne = ChromosomeGenerator.GetSpecificChromosome(chromosomeOne.Genes);
            Chromosome childChromosomeTwo = ChromosomeGenerator.GetSpecificChromosome(chromosomeTwo.Genes);

            int whereIAm = _place;
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

                        if (tempOne != tempTwo)
                        {
                            childChromosomeOne.Genes[i].Bits[j] = tempTwo;
                            childChromosomeTwo.Genes[i].Bits[j] = tempOne;
                        }
                    }

                }
            }
            List<Chromosome> list = new List<Chromosome>();
            list.Add(childChromosomeOne);
            list.Add(childChromosomeTwo);
            return list;
        }
    }
}
