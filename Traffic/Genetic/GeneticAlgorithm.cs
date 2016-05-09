﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    public class GeneticAlgorithm 
    {
      
        private List<Chromosome> _actualPopulation;
        private List<Tuple<Chromosome, double>> _fitnessOfActualPopulation;
        private IFitnessable _client;
        private IGeneticSelectionMethod _methodOfSelection;
        private int _numberOfEpochs;
        private Random _rand;
        private double _mutationProb;
        private IGeneticCrossOperator _crossOperator;
        private IGeneticMutationOperator _mutationOperator;

        public GeneticAlgorithm(int populationAmount, int numberOfGenes, int numberOfBitsOnGenes, int numberOfEpochs,double mutationProb, IGeneticSelectionMethod methodOfSelection, IFitnessable client, IGeneticCrossOperator crossOperator, IGeneticMutationOperator mutationOperator)
        {
            InitializePopulation(populationAmount, numberOfGenes, numberOfBitsOnGenes);
            _methodOfSelection = methodOfSelection;
            _client = client;
            _numberOfEpochs = numberOfEpochs;
            _mutationProb = mutationProb;
            _rand = new Random();
            _crossOperator = crossOperator;
            _mutationOperator = mutationOperator;
        }
        private void InitializePopulation(int numberOfChromosomes, int numberOfGenes, int lengthOfGenes)
        {
            _actualPopulation = new List<Chromosome>();
            for (int i = 0; i < numberOfChromosomes; i++)
            {
                Chromosome chromosome = ChromosomeGenerator.GetRandomChromosome(numberOfGenes, lengthOfGenes);
                _actualPopulation.Add(chromosome);
            }
        }
        
        public void RunAlgorithm()
        {
            for(int i=0; i<_numberOfEpochs; i++)
            {
                CalculateActualPopulationFitness();
                List<Chromosome> parents = _methodOfSelection.GetParents(_fitnessOfActualPopulation);
                MakeNewPopulation(parents);
            }
            
        }

        private void CalculateActualPopulationFitness()
        {
            _fitnessOfActualPopulation = new List<Tuple<Chromosome, double>>();
            _actualPopulation.ForEach(cr => _fitnessOfActualPopulation.Add(new Tuple<Chromosome, double>(cr, _client.GetFitness(cr))));
        }
        private void MakeNewPopulation(List<Chromosome> parents)
        {
            _actualPopulation = new List<Chromosome>();
            for(int i=0; i<parents.Count; i+=2)
            {
                List<Chromosome> children = _crossOperator.Cross(parents[i], parents[i + 1]);
                
                for(int j=0; j<children.Count; j++)
                {
                    double randForChromosome = _rand.NextDouble();
                    if (randForChromosome < _mutationProb)
                        children[j] = _mutationOperator.Mutate(children[j]);
                }
                _actualPopulation.Add(children[0]);_actualPopulation.Add(children[1]);
            }
        }

        public string ShowPopulation()
        {
            string result = "";
             _actualPopulation.ForEach(c => result+= c.ToString());
            return result;
        }
        

        
    }
}