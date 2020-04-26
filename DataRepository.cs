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

        private double[][] data;
        public DataRepository()
        {
            data = readData();
        }
        public double[][] getExceptedValues()
        {
            double[][] ExceptedValues = new double[data.Length][];
            
            for (int i = 0; i < data.Length; i++)
            {
                ExceptedValues[i]= new double[3];
                ExceptedValues[i][0]= data[i][data[i].Length - 3];
                ExceptedValues[i][1] = data[i][data[i].Length -2 ];
                ExceptedValues[i][2] = data[i][data[i].Length - 1];
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

                data[i] = new double[tmp.Length +2];

                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    data[i][j] = Convert.ToDouble(tmp[j].Replace('.', ','));

                }
                switch (tmp[tmp.Length - 1])
                {
                    case "Iris-setosa":
                        data[i][tmp.Length - 1] = 1;
                        data[i][tmp.Length ] = 0;
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
            }
            return data;
        }
    }
}
