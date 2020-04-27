using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztuczna_siec_neuronowa
{
    public class NormalizatorColumnMinMax : INormalizator
    {
        public double normalize(double value, double min, double max)
        {
            value = (double)((value - min) / max - min);
            return value;
        }
    }
}
