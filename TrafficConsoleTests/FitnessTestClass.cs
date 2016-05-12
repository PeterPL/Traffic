using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic.Genetic;

namespace TrafficConsoleTests
{
    public class FitnessTestClass : IFitnessable
    {
        private double Quadro(double x)
        {
            return 2*x;
        }
        public double GetFitness(Chromosome chromosome)
        {
            double temp = 0;
            int count = chromosome.Genes.Count;
            for(int i=0; i<count; i++)
            {
                temp = chromosome.Genes[i].ConvertToNumber();
            }
            return Quadro(temp);

        }
    }
}
