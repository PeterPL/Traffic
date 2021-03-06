﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class OnePlaceGeneticCrossOperator : IGeneticCrossOperator
    {
        private Random _rand;

        public OnePlaceGeneticCrossOperator()
        {
            _rand = new Random();
        }
        
        public List<Chromosome> Cross(Chromosome chromosomeOne, Chromosome chromosomeTwo)
        {
            int numberOfGenes = chromosomeOne.Genes.Count;
            int randomPlaceOfCross = _rand.Next(chromosomeOne.Length);

            List<Gene> childListOne = new List<Gene>();
            List<Gene> childListTwo = new List<Gene>();
            chromosomeOne.Genes.ForEach(g => childListOne.Add(GeneGenerator.GetSpecificGene(g.Bits)));
            chromosomeTwo.Genes.ForEach(g => childListTwo.Add(GeneGenerator.GetSpecificGene(g.Bits)));

            Chromosome childChromosomeOne = ChromosomeGenerator.GetSpecificChromosome(childListOne);
            Chromosome childChromosomeTwo = ChromosomeGenerator.GetSpecificChromosome(childListTwo);

            for (int i = 0; i < numberOfGenes; i++)
            {
                for (int j = 0; j < childChromosomeOne.Genes[i].Bits.Length; j++)
                {
                    if (randomPlaceOfCross > 0)
                        randomPlaceOfCross -= 1;

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
