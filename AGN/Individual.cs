using System;
using System.Collections.Generic;
using System.Text;

namespace AGN
{
    public class Individual
    {
        public double Fitness { get; set; }
        public string Chromossomes { get; set; }

        public Individual() { }

        public Individual(string chromossomes)
        {
            Chromossomes = chromossomes;
        }
    }
}