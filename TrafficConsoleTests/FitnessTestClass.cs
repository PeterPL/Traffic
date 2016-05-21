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
        private double Quadro(double x, double y, double z)
        {
            return 2 * x - x * y + z;
        }
        public double GetFitness(Chromosome chromosome)
        {
            return Quadro(chromosome.Genes[0].ConvertToNumber(),chromosome.Genes[1].ConvertToNumber(),chromosome.Genes[2].ConvertToNumber());
        }
    }
}
