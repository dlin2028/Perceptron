using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perceptron
{
    class Perceptron
    {
        public double[] Weights;
        public Func<double, double> activation;

        public double BiasWeight;

        public double Output;

        public Perceptron(Func<double, double> activation, int numberOfInputs)
        {
            Weights = new double[numberOfInputs];
        }

        public void RandomizeWeights(Random rng)
        {
            BiasWeight = rng.NextDouble();
            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = rng.NextDouble();
            }
        }

        public double Compute(double[] inputs)
        {
            if (inputs.Length != Weights.Length)
            {
                throw new Exception("wrong number of inputs");
            }

            double dotProduct = 0;
            for (int i = 0; i < Weights.Length; i++)
            {
                dotProduct += Weights[i] * inputs[i];
            }

            Output = activation(dotProduct);
            return Output;
        }


        public void Train(double[] inputs, double desiredOutput)
        {
            double output = Compute(inputs);
            double error = desiredOutput - output;
            for (int i = 0; i < inputs.Length; i++)
            {
                Weights[i] += error * inputs[i];
            }
            BiasWeight += error;
        }

        public void Train(List<Datum> data)
        {
            double mae;
            int epoch = 0;
            do
            {
                for (int i = 0; i < data.Count; i++)
                {
                    Train(data[i].input, data[i].ouput);
                }

                mae = 0;
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < data.Count; i++)
                {
                    double output = Compute(data[i].input);

                    Console.WriteLine($"{data[i].input[0]} ^ {data[i].input[1]} = {output}");

                    mae += Math.Abs(data[i].ouput - output);
                }
                mae /= data.Count;
                Console.WriteLine($"MAE: {mae:#.00}");
                Console.WriteLine($"Epoch: {epoch}");
                epoch++;
            } while (mae != 0);
        }

    }
}
