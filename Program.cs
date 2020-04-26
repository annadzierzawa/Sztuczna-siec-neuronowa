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
            network.AddLayer(layerFactory.CreateNeuralLayer(4, new RectifiedActivationFuncion(), new WeightedSumFunction()));
            network.AddLayer(layerFactory.CreateNeuralLayer(3, new SigmoidActivationFunction(0.6), new WeightedSumFunction()));

            var data = new DataRepository();

            network.PushExpectedValues(data.getExceptedValues());

            network.Train(data.getTrainValues() , 1000);

            network.PushInputValues(new double[] { 7.0, 3.2, 4.7, 1.4 });
            var outputs = network.GetOutput();
            System.Console.ReadKey();
        }
    }
}
