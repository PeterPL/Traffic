using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class Gene
    {
        public int[] Bits { get; set; }

        public Gene(int[] inputOfGene)
        {
            Bits = new int[inputOfGene.Length];
            for (int i = 0; i < Bits.Length; i++)
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
            foreach (var x in Bits)
            {
                result += x + " ";

            }
            return result;
        }


    }
}
