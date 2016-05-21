using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class TournamentGeneticSelectionMethod:IGeneticSelectionMethod
    {
        private int _amountOfSingleTournament;
        private CriterionOfSelection _criterion;
        private Random _rand;
        public TournamentGeneticSelectionMethod(int amountOfSingleTournament)
        {
            _rand = new Random();
            _amountOfSingleTournament = amountOfSingleTournament;
        }

        public void SetCriterionOfSelection(CriterionOfSelection criterion)
        {
            _criterion = criterion;
        }

        public List<Chromosome>GetParents(List<Tuple<Chromosome, double>> fitnessesOfChromosomes)
        {
            List<Chromosome> parents = new List<Chromosome>();
            for(int i=0; i<fitnessesOfChromosomes.Count; i++)
            {
                List<Chromosome> groupOfChromosomes = new List<Chromosome>();
                groupOfChromosomes.Add(fitnessesOfChromosomes[i].Item1);
                for(int j=1; j<_amountOfSingleTournament; j++)
                {
                    int randomIndex = _rand.Next(0, fitnessesOfChromosomes.Count);
                    Chromosome cr = fitnessesOfChromosomes[randomIndex].Item1;
                    if (!groupOfChromosomes.Contains(cr))
                        groupOfChromosomes.Add(fitnessesOfChromosomes[randomIndex].Item1);
                    else j--;
                }
                parents.Add(ChooseBestChromosomeFromGroup(groupOfChromosomes, fitnessesOfChromosomes));
            }
            return parents;  
        }

        private Chromosome ChooseBestChromosomeFromGroup(List<Chromosome> chromosomes, List<Tuple<Chromosome, double>> fitnessesOfChromosomes)
        {
            List<double> values = new List<double>();
            for(int i=0; i<chromosomes.Count; i++)
            {
                values.Add(fitnessesOfChromosomes.Find(c => c.Item1 == chromosomes[i]).Item2);
            }
            double bestValue = 0;
            if (_criterion == CriterionOfSelection.MAX)
                bestValue = values.Max();
            else
               bestValue = values.Min();
            return fitnessesOfChromosomes.Find(c => c.Item2 == bestValue).Item1;
        }
        
    }
    
}
