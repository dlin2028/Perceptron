using System;
using System.Collections.Generic;
using System.Text;

namespace Perceptron
{
    class Population
    {
        public NeuralNet BestNet => networks[0];

        private List<NeuralNet> networks;
        private int size;

        Random rng;

        public Population(Random rng, int size, int inputs, params int[] layerNeurons)
        {
            this.rng = rng;
            networks = new List<NeuralNet>();
            this.size = size;
            for (int i = 0; i < size; i++)
            {
                networks.Add(new NeuralNet(Activations.BinaryStep, inputs, layerNeurons));
                networks[networks.Count-1].Randomize(rng);
            }
        }

        public double[] Compute(double[] data)
        {
            return BestNet.Compute(data);
        }

        public void Train(double[][] inputs, double[][] desiredOutputs, int maxGeneration = -1)
        {
            int gen = 0;
            while(true)
            {
                networks.Sort((x, y) =>
                    x.Fitness(inputs, desiredOutputs)
                    .CompareTo(
                        y.Fitness(inputs, desiredOutputs)));

                if(networks[0].Fitness(inputs, desiredOutputs) == 0 || gen == maxGeneration)
                {
                    break;
                }

                for (int i = 1; i < networks.Count; i++)
                {
                    networks[i].Mutate(rng, 0.5);
                }

                networks[networks.Count-1].Randomize(rng);
            }
        }
    }
}
