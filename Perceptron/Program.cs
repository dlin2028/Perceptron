using System;
using System.Collections.Generic;

namespace Perceptron
{
    class Program
    {
        struct Datum
        {
            public double[] input;
            public double ouput;

            public Datum(double[] input, double output)
            {
                this.input = input;
                this.ouput = output;
            }
        }

        static void Main(string[] args)
        {
            Perceptron perceptron = new Perceptron(2);

            List<Datum> data = new List<Datum>();
            data.Add(new Datum(new double[] { 1, 1 }, 1));
            data.Add(new Datum(new double[] { 1, 0 }, 0));
            data.Add(new Datum(new double[] { 0, 1 }, 0));
            data.Add(new Datum(new double[] { 0, 0 }, 0));
            

            for (int i = 0; i < data.Count; i++)
            {
                double output = perceptron.Compute(data[i].input);
                Console.WriteLine(output);
                if (output != data[i].ouput)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        perceptron.Weights[j] = perceptron.Weights[j] + (data[i].ouput - output) * data[i].input[j];
                    }
                }
            }

            while(true)
            {
                Console.WriteLine(perceptron.Compute(
                    new double[] {
                        double.Parse(Console.ReadLine()),
                        double.Parse(Console.ReadLine())
                    }));
            }

        }
    }
}
