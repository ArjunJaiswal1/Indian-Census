﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaCensusDataDemo.DataDAO
{
    public class PopulationDataDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;

        public PopulationDataDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }
    }
}
