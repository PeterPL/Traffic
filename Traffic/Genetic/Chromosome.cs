using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class GeneticAlgorithm
    {
        List<Chromosome> _population;

        private void InitializePopulation(int numberOfChromosomes, int numberOfGenes, int lengthOfGenes)
        {
            _population = new List<Chromosome>();
            for(int i=0; i<numberOfChromosomes; i++)
            {
                Chromosome chromosome = ChromosomeGenerator.GetRandomChromosome(numberOfGenes, lengthOfGenes);
                _population.Add(chromosome);
            }
        }
    }
    public class Chromosome
    {
        public List<Gene> Genes { get; set; }
        public Chromosome()
        {
            Genes = new List<Gene>();
        }
        public int Length
        {
            get
            {
                int length = 0;
                Genes.ForEach(x => length += x.Bits.Length);
                return length;
            }
        }

        public override string ToString()
        {
            string result = "|";
            Genes.ForEach(x => result += x.ToString() + "|");
            return result;
        }

    }
    public class ChromosomeGenerator
    {
        public static Chromosome GetRandomChromosome(int numberOfGenes,int lengthOfGene)
        {
            Random rand = new Random();
            Chromosome chromosome = new Chromosome();
            for(int i=0; i<numberOfGenes; i++)
            {
                Gene gen = GeneGenerator.GetRandomGene(lengthOfGene);
                chromosome.Genes.Add(gen);
            }
            return chromosome;
        }
        public static Chromosome GetSpecificChromosome(List<Gene> genes)
        {
            Chromosome chromosome = new Chromosome();
            for(int i=0; i<genes.Count; i++)
            {
                chromosome.Genes.Add(genes[i]);
            }
            return chromosome;
        }
        
    }
    public class GeneGenerator
    {
        static Random rand;

        static GeneGenerator()
        {
            rand = new Random();
        }
        public static Gene GetSpecificGene(int[] input)
        {
            Gene gen = new Gene(input);
            return gen;
        }

        public static Gene GetRandomGene(int length)
        {
            int[] tab = new int[length];
            for (int i=0; i<length; i++)
            {
                tab[i] = rand.Next(0, 2);
            }
            return new Gene(tab);
        }
    }
    public class Gene
    {
        public int[] Bits { get; set; } 
        
        public Gene(int[] inputOfGene)
        {
            Bits = new int[inputOfGene.Length];
            for(int i=0; i<Bits.Length; i++)
            {
                Bits[i] = inputOfGene[i];
            }
        }
        
        public double ConvertToNumber()
        {
            int power = 0;
            double result = 0;
            for (var i = Bits.Length - 1; i >= 0; i--)
            {
                int tempValue = Bits[i];
                if (tempValue == 0)
                    result += 0;
                else if (tempValue == 1)
                    result += Math.Pow(2, power);
                power++;
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach(var x in Bits)
            {
                result += x+" ";
                
            }
            return result;
        }
        

    }
    

}
