using System;
using System.Collections.Generic;
using System.Text;

namespace Perceptron
{
    class NeuralNet
    {
        public List<Layer> Layers;
        public double[] Output => Layers.Last().Output;
        /// <summary>
        /// Constructs a Feed Forward Neural Network object
        /// </summary>
        /// <param name="activation">the activation function used for computation by the neurons</param>
        /// <param name="inputCount">the number of inputs to the neural network</param>
        /// <param name="layerNeurons">an array representing how many neurons are in each of the hidden layers and output layer of the neural network</param>
        public NeuralNet(Func<double, double> activation, int inputCount, params int[] layerNeurons)
        {
            Layers = new List<Layer>();
            Layers[0] = new Layer(activation, inputCount, layerNeurons[0]);
            for (int i = 1; i < layerNeurons.Length; i++)
            {
                //the number of inputs of a layer is the number of outputs of the previous layer
                Layers.Add(new Layer(activation, Layers[i - 1].Perceptrons.Length, layerNeurons[i]));
            }
        }

        public double[] Compute(double[] data, int layer = 0)
        {
            if (layer == Layers.Count - 1)
            {
                return Layers[layer].Compute(data);
            }
            return Compute(Layers[layer].Compute(data), layer + 1);
        }

        public void Train(double[][] inputs, double[][] desiredOutputs, int populationSize, int maxGeneration = -1)
        {
            while(NetFitness(inputs, desiredOutputs) != 0)
            {

            }
        }

        public double NetFitness(double[][] inputs, double[][] desiredOutputs)
        {
            double fitness = 0;
            foreach (var input in inputs)
            {
                fitness += Compute(input);
            }
        }
    }
}
