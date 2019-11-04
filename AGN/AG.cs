using System;
using System.Collections.Generic;
using System.Linq;

namespace AGN
{
    public class AG
    {
        public IList<Individual> Population { get; set; }
        public decimal Mutation { get; set; }
        public string Input { get; set; }
        public int PopulationLenth { get; set; }

        public AG(decimal Mutation, string Input, int PopulationLenth)
        {
            Population = new List<Individual>();
            this.Input = Input;
            this.Mutation = Mutation;
            this.PopulationLenth = PopulationLenth;
        }

        public void StartPopulation()
        {
            for (int i = 0; i < PopulationLenth; i++)
            {
                var chromossome = "";
                for (int a = 0; a < Input.Length; a++)
                {
                    chromossome += GetNewChar();
                }
                Population.Add(new Individual(chromossome));
            }
        }

        private char GetNewChar()
        {
            var random = new Random();
            var r = random.Next(33, 170);
            return Convert.ToChar(r);
        }

        public void CalcFitness()
        {
            foreach (var individual in Population)
            {
                var fitness = 0.00;
                for (int i = 0; i < Input.Length; i++)
                {
                    if (individual.Chromossomes[i].Equals(Input[i]))
                    {
                        fitness++;
                    }
                }
                individual.Fitness = ((fitness * 100.00) / Input.Length);
            }
        }

        public Individual GetBestIndividual()
        {
            return Population.OrderByDescending(x => x.Fitness).FirstOrDefault();
        }

        public void RouletteWheel()
        {
            var newPopulation = new List<Individual>();
            var random = new Random();
            Population = Population.OrderByDescending(x => x.Fitness).ToList();

            for (int a = 0; a < PopulationLenth / 2; a++)
            {
                newPopulation.Add(Population[a]);
            }

            Population = newPopulation;
        }

        public void RunMutation()
        {
            foreach (var individual in Population)
            {
                var newChromossomes = "";
                var random = new Random();
                for (int i = 0; i < Input.Length; i++)
                {
                    newChromossomes += (Mutation >= Convert.ToDecimal(random.NextDouble()) ? GetNewChar() : individual.Chromossomes[i]);
                }
                individual.Chromossomes = newChromossomes;
            }
        }

        public void Crossover()
        {
            //var newPopulation = new List<Individual>();            
            for (int i = 0; Population.Count < PopulationLenth; i++)
            {
                var crossChromossomes = "";
                var father = Population[i];
                var mother = (i + 1 < Population.Count ? Population[i + 1] : Population[0]);

                var fatherChromossomes = father.Chromossomes.Substring(0, father.Chromossomes.Length / 2);
                var motherChromossomes = mother.Chromossomes.Substring(mother.Chromossomes.Length / 2, Convert.ToInt32(Math.Round(mother.Chromossomes.Length / 2.00, MidpointRounding.AwayFromZero)));

                crossChromossomes = fatherChromossomes + motherChromossomes;
                Population.Add(new Individual(crossChromossomes));

                crossChromossomes = motherChromossomes + fatherChromossomes;
                Population.Add(new Individual(crossChromossomes));
            }

            //Population = newPopulation;
        }
    }
}
