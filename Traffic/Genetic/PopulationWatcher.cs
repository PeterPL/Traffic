using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class PopulationWatcher
    {
        private List<Tuple<List<Chromosome>, double>> _populations;
        private List<Chromosome> _bestChromosomes;
        private CriterionOfSelection _criterion;

        public PopulationWatcher()
        {
            _populations = new List<Tuple<List<Chromosome>, double>>();
            _bestChromosomes = new List<Chromosome>();
        }

        public void SetCriterion(CriterionOfSelection criterionOfSelection)
        {
            _criterion = criterionOfSelection;
        }
        

        public void AddToPopulations(List<Chromosome> population, double sumOfFitness)
        {
            List<Chromosome> pop = new List<Chromosome>();
            population.ForEach(p => pop.Add(p));
            Tuple<List<Chromosome>, double> tuple = new Tuple<List<Chromosome>, double>(pop, sumOfFitness);
            _populations.Add(tuple);
        }
        public void AddToBestChromosomes(Chromosome bestChromosome)
        {
            _bestChromosomes.Add(bestChromosome);
        }

        public bool IsBeingChanged()
        {
            double sum = 0;
            double temp = 3;
            if (_populations.Count >= temp)
            {
                for (int i = _populations.Count - 1; i >= _populations.Count - temp; i--)
                {
                    sum += _populations[i].Item2;
                }
            }
            else return true;
            

            double avg = sum / temp;
            double item = _populations[_populations.Count - 1].Item2;
            if (avg < 0.95 * item || avg > 1.05 * item)
                return true;
            
            return false;
        }

        public string ShowData()
        {
            string result = "";

            for(int i=0; i<_populations.Count; i++)
            {
                result += i + " ";
                _populations[i].Item1.ForEach(c => result += c.ToString());
                result += _populations[i].Item2 +" # "+ _bestChromosomes[i].ToString() + "\n";
            }
            
            return result;         
        }

    }
}
