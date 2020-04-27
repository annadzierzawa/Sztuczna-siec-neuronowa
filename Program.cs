using System;
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
            var network = new SimpleNeuralNetwork(4);

            var layerFactory = new NeuralLayerFactory();
            network.AddLayer(layerFactory.CreateNeuralLayer(10, new RectifiedActivationFuncion(), new WeightedSumFunction()));
 
            network.AddLayer(layerFactory.CreateNeuralLayer(3, new SigmoidActivationFunction(0.7), new WeightedSumFunction()));

            var data = new DataRepository();

            network.PushExpectedValues(data.getExceptedValues());

            network.Train(data.getTrainValues() , 1000);

            var input = new double[] { 5.0, 3.4, 1.5, 0.2 };

            double[] colMin = { 4.3, 2, 1, 0.1 };
            double[] minMaxDiffs = { 3.6, 2.4, 5.9, 2.4 };
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = normalize(input[i], colMin[i], minMaxDiffs[i]);
            }
            network.PushInputValues(input);
            var outputs = network.GetOutput();
            System.Console.ReadKey();
        }

        private static double normalize(double value, double min, double diff)
        {

            value = (double)((value - min) / diff);
            //Console.WriteLine(value);
            return value;

        }
    }
}
