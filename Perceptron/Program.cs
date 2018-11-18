using System;
using System.Collections.Generic;

namespace Perceptron
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

    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            
            //Input Data for XOR
            double[][] inputs = new double[][]
            {
                new[] { 0.0, 0.0 },
                new[] { 0.0, 1.0 },
                new[] { 1.0, 0.0 },
                new[] { 1.0, 1.0 }
            };

            //Output Data for XOR
            double[][] outputs = new double[][]
            {
                new[] { 0.0 },
                new[] { 1.0 },
                new[] { 1.0 },
                new[] { 0.0 }
            };
            /*
            List<double[]> inputs = new List<double[]>();
            List<double[]> outputs = new List<double[]>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    inputs.Add(new double[] { i, j });
                    outputs.Add(new double[] { i + j });
                }
            }*/


            //Train Network
            Population pop = new Population(random, 50, 2, 5, 5, 5);
            pop.Train(inputs, outputs);

            while (true)
            {
                Console.WriteLine(pop.Compute(new double[] {
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine())
                 })[0]);
            }

        }

    }
}

/*
Perceptron and = new Perceptron(2);
Perceptron or = new Perceptron(2);
Perceptron nand = new Perceptron(2);

List<Datum> data = new List<Datum>();
data.Add(new Datum(new double[] { 1, 1 }, 1));
data.Add(new Datum(new double[] { 1, 0 }, 0));
data.Add(new Datum(new double[] { 0, 1 }, 0));
data.Add(new Datum(new double[] { 0, 0 }, 0));
and.Train(data);

data = new List<Datum>();
data.Add(new Datum(new double[] { 1, 1 }, 1));
data.Add(new Datum(new double[] { 1, 0 }, 1));
data.Add(new Datum(new double[] { 0, 1 }, 1));
data.Add(new Datum(new double[] { 0, 0 }, 0));
or.Train(data);

data = new List<Datum>();
data.Add(new Datum(new double[] { 1, 1 }, 0));
data.Add(new Datum(new double[] { 1, 0 }, 1));
data.Add(new Datum(new double[] { 0, 1 }, 1));
data.Add(new Datum(new double[] { 0, 0 }, 1));
nand.Train(data);

List<List<Perceptron>> perceptrons = new List<List<Perceptron>>();
perceptrons.Add(new List<Perceptron>(new Perceptron[]{ or, nand }));
perceptrons.Add(new List<Perceptron>(new Perceptron[] { and }));

NeuralNet net = new NeuralNet(perceptrons);

while(true)
{
    Console.WriteLine(net.Compute(new double[] {
        double.Parse(
            Console.ReadLine()),
            double.Parse(Console.ReadLine())
    }));
}

*/
