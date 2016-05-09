using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
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
            for (int i = 0; i < length; i++)
            {
                tab[i] = rand.Next(0, 2);
            }
            return new Gene(tab);
        }
    }
}
