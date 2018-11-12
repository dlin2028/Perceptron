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
        static void Main(string[] args)
        {
            Console.ReadKey();
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
