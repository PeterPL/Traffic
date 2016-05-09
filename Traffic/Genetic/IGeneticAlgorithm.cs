﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic
{
    interface IGeneticAlgorithm
    {
        void InitializePopulation();
        void RunAlgorithm();
    }
}
