using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class PopulationLogger
    {
        private List<Tuple<List<Chromosome>, double>>_populations { get; set; }

        public PopulationLogger()
        {
            _populations = new List<Tuple<List<Chromosome>, double>>();
        }

        public void AddToPopulations(List<Chromosome> population, double sumOfFitness)
        {
            List<Chromosome> pop = new List<Chromosome>();
            population.ForEach(p => pop.Add(p));
            Tuple<List<Chromosome>, double> tuple = new Tuple<List<Chromosome>, double>(pop, sumOfFitness);
            _populations.Add(tuple);
        }

        public string ShowData()
        {
            string result = "";
            foreach(Tuple<List<Chromosome>,double> p in _populations)
            {
                p.Item1.ForEach(c => result += c.ToString());
                result += p.Item2 + "\n";
            }
            
            return result;         
        }
    }
}
