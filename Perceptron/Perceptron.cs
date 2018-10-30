using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perceptron
{
    class Perceptron
    {
        public double[] Weights;
        double BiasWeight;

        public Perceptron(int numberOfInputs)
        {
            Weights = new double[numberOfInputs];
        }

        public double Compute(double[] inputs)
        {
            if (inputs.Length != Weights.Length)
            {
                throw new Exception("wrong number of inputs");
            }

            double dotProduct = inputs.Zip(Weights, (d1, d2) => d1 * d2).Sum();
            if(dotProduct + BiasWeight > 0)
            {
                return 1;
            }
            return 0;
        }
  
    }
}
