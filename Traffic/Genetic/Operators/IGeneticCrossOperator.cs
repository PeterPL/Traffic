using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public interface IGeneticCrossOperator
    {
        List<Chromosome> Cross(Chromosome chromosomeOne, Chromosome chromosomeTwo);
    }
}
