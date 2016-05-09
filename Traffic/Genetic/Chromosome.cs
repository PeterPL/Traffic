using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
   
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
 
}
