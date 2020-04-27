using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztuczna_siec_neuronowa
{
    class DataRepository
    {

        public INormalizator normalizator = new NormalizatorZeroOne();

        private double[][] data;
        public DataRepository(INormalizator _normalizator)
        {
            normalizator = _normalizator;
            data = readData();
        }
        public double[][] getExceptedValues()
        {
            double[][] ExceptedValues = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                ExceptedValues[i] = new double[3];
                ExceptedValues[i][0] = data[i][data[i].Length - 3];
                ExceptedValues[i][1] = data[i][data[i].Length - 2];
                ExceptedValues[i][2] = data[i][data[i].Length - 1];
                //ExceptedValues[i] = new double[1];
                //ExceptedValues[i][0] = data[i][data[i].Length - 3];
                //if (data[i][data[i].Length - 3] == 1)
                //{
                //    ExceptedValues[i][0] = 0;
                //}
                //else if (data[i][data[i].Length - 2] == 1)
                //{
                //    ExceptedValues[i][0] = 0.5;
                //}
                //else if (data[i][data[i].Length - 1] == 1)
                //{
                //    ExceptedValues[i][0] = 1;
                //}

            }
            return ExceptedValues;
        }
        public double[][] getTrainValues()
        {
            double[][] TrainingData = new double[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                TrainingData[i] = new double[data[i].Length];
                for (int j = 0; j < data[i].Length - 1; j++)
                {
                    TrainingData[i][j] = data[i][j];

                }
            }

            return TrainingData;
        }
        private double[][] readData()
        {

            string[] lines = File.ReadAllLines(@"D:\Semestr 4\Systemy sztucznej inteligencji\IRIS2.txt");

            double[][] data = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');

                data[i] = new double[tmp.Length + 2];

                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    data[i][j] = Convert.ToDouble(tmp[j].Replace('.', ','));

                }
                switch (tmp[tmp.Length - 1])
                {
                    case "Iris-setosa":
                        data[i][tmp.Length - 1] = 1;
                        data[i][tmp.Length] = 0;
                        data[i][tmp.Length + 1] = 0;
                        break;
                    case "Iris-versicolor":
                        data[i][tmp.Length - 1] = 0;
                        data[i][tmp.Length] = 1;
                        data[i][tmp.Length + 1] = 0;

                        break;
                    case "Iris-virginica":
                        data[i][tmp.Length - 1] = 0;
                        data[i][tmp.Length] = 0;
                        data[i][tmp.Length + 1] = 1;
                        break;
                    default:
                        data[i][tmp.Length - 1] = 0;
                        data[i][tmp.Length] = 0;
                        data[i][tmp.Length + 1] = 0;
                        break;
                }



                double[] colMin = { 4.3, 2, 1, 0.1 };
                double[] colmax = { 7.9, 4.4, 6.9, 2.5 };
                double[] minMaxDiffs = { 3.6, 2.4, 5.9, 2.4 };
                var min = data[i].Min();
                var max = data[i].Max();
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    data[i][j] = normalizator.normalize(data[i][j], min, max);

                }
            }
            return data;
        }
        private double normalize(double value, double min, double diff)
        {

            value = (double)((value - min) / diff);
            //Console.WriteLine(value);
            return value;

        }
    }
}
