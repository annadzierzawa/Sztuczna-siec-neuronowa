using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztuczna_siec_neuronowa
{
    public interface IActivationFunction
    {
        double CalculateOutput(double input);
    }
}
