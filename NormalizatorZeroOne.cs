using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztuczna_siec_neuronowa
{
    public class NormalizatorZeroOne : INormalizator
    {
        public double normalize(double value, double min, double max)
        {
            double newmin = 0;
            double newmax = 1;

            value = (double)((value - min) / (max - min) * (newmax - newmin) + newmin);
            return value;
        }
    }
}
