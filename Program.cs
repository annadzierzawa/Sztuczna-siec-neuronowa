﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztuczna_siec_neuronowa
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var data = new DataRepository(new NormalizatorZeroOne());

            var inputs = new List<double[]>(9);

            inputs.Add(new double[] { 4.6, 3.2, 1.4, 0.2 });
            inputs.Add(new double[] { 6.2, 3.4, 5.4, 2.3 });
            inputs.Add(new double[] { 5.3, 3.7, 1.5, 0.2 });
            inputs.Add(new double[] { 5.0, 3.3, 1.4, 0.2 });
            inputs.Add(new double[] { 6.2, 2.9, 4.3, 1.3 });
            inputs.Add(new double[] { 5.7, 2.8, 4.1, 1.3 });
            inputs.Add(new double[] { 5.1, 2.5, 3.0, 1.1 });
            inputs.Add(new double[] { 6.5, 3.0, 5.2, 2.0 });
            inputs.Add(new double[] { 5.9, 3.0, 5.1, 1.8 });
            

            var results = new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

            double[] colMin = { 4.3, 2, 1, 0.1 };
            double[] colmax = { 7.9, 4.4, 6.9, 2.5 };
            double[] minMaxDiffs = { 3.6, 2.4, 5.9, 2.4 };
            foreach (var input in inputs)
            {
                var min = input.Min();
                var max = input.Max();
                for (int i = 0; i < input.Length; i++)
                {
                    input[i] = data.normalizator.normalize(input[i], min, max);
                }
            }



            var network = new SimpleNeuralNetwork(4);

            var layerFactory = new NeuralLayerFactory();
            network.AddLayer(layerFactory.CreateNeuralLayer(8, new SigmoidActivationFunction(0.6), new WeightedSumFunction()));
            network.AddLayer(layerFactory.CreateNeuralLayer(6, new SigmoidActivationFunction(0.6), new WeightedSumFunction()));
            network.AddLayer(layerFactory.CreateNeuralLayer(3, new SigmoidActivationFunction(0.7), new WeightedSumFunction()));
            network.AddLayer(layerFactory.CreateNeuralLayer(3, new SigmoidActivationFunction(0.7), new WeightedSumFunction()));


            network.PushExpectedValues(data.getExceptedValues());

            network.Train(data.getTrainValues(), 1000);
            var idx = 0;
            foreach (var input in inputs)
            {
                network.PushInputValues(input);
                var outputs = network.GetOutput();
                var max = outputs.Max();
                var indexOfMax = outputs.FindIndex(x => x == max);
                Console.WriteLine("Value:");
                Console.WriteLine(outputs[0]);
                Console.WriteLine(outputs[1]);
                Console.WriteLine(outputs[2]);
                Console.WriteLine("Expected Value: ");
                Console.WriteLine(results[idx]);
               
                //if (indexOfMax == results[idx])
                //{

                //    Console.WriteLine(idx + " jest ok");
                //}
                //else
                //{
                //    Console.WriteLine(idx + " NIE jest ok");
                //}
                idx++;
            }
            //network.Train(data.getTrainValues(), 500);
            //idx = 0;
            //foreach (var input in inputs)
            //{
            //    network.PushInputValues(input);
            //    var outputs = network.GetOutput();
            //    var max = outputs.Max();
            //    var indexOfMax = outputs.FindIndex(x => x == max);
            //    if (indexOfMax == results[idx])
            //    {
            //        Console.WriteLine(idx + " jest ok");
            //    }
            //    else
            //    {
            //        Console.WriteLine(idx + " NIE jest ok");
            //    }
            //    idx++;
            //}
            //network.Train(data.getTrainValues(), 500);

            //idx = 0;
            //foreach (var input in inputs)
            //{
            //    network.PushInputValues(input);
            //    var outputs = network.GetOutput();
            //    var max = outputs.Max();
            //    var indexOfMax = outputs.FindIndex(x => x == max);
            //    if (indexOfMax == results[idx])
            //    {
            //        Console.WriteLine(idx + " jest ok");
            //    }
            //    else
            //    {
            //        Console.WriteLine(idx + " NIE jest ok");
            //    }
            //    idx++;
            //}



            System.Console.ReadKey();
        }

    }
}
