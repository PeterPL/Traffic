using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic.Operators
{
    public class LocalOnePlaceGeneticCrossOperator : IGeneticCrossOperator
    {
        private Random _rand;

        public LocalOnePlaceGeneticCrossOperator()
        {
            _rand = new Random();
        }

        public List<Chromosome> Cross(Chromosome chromosomeOne, Chromosome chromosomeTwo)
        {
            int numberOfGenes = chromosomeOne.Genes.Count;

            List<Gene> childListOne = new List<Gene>();
            List<Gene> childListTwo = new List<Gene>();
            chromosomeOne.Genes.ForEach(g=> childListOne.Add(GeneGenerator.GetSpecificGene(g.Bits)));
            chromosomeTwo.Genes.ForEach(g => childListTwo.Add(GeneGenerator.GetSpecificGene(g.Bits)));

            Chromosome childChromosomeOne = ChromosomeGenerator.GetSpecificChromosome(childListOne);
            Chromosome childChromosomeTwo = ChromosomeGenerator.GetSpecificChromosome(childListTwo);

            //List<double> probabilitiesForGenes = GetProbabilitiesForGenes(numberOfGenes);
            for(int i=0; i<numberOfGenes;i++)
            {
                int randomPlace = _rand.Next(0, childChromosomeOne.Genes[i].Bits.Length);
                for(int j=0; j<childChromosomeOne.Genes[i].Bits.Length; j++)
                {
                    if (randomPlace > 0)
                        randomPlace -= 1;
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
            List<Chromosome> list = new List<Chromosome>();
            list.Add(childChromosomeOne);
            list.Add(childChromosomeTwo);
            return list;
        }

        private List<double> GetProbabilitiesForGenes(int numberOfGenes)
        {
            List<double> list = new List<double>();
            for(int i=0; i<numberOfGenes; i++)
            {
                list.Add(_rand.NextDouble());
            }
            return list;
        }
    }
}
