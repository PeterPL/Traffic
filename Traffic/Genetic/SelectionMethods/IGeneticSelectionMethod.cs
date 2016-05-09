using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public interface IGeneticSelectionMethod
    {
        List<Chromosome> GetParents(List<Tuple<Chromosome, double>> fitnessesOfChromosomes );
       
    }
    
    public enum CriterionOfSelection
    {
        MIN,
        MAX
    }
}
