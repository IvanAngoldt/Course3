using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_1_Angoldt_Neironka.ModelNeuroNet
{
    class Neuron
    {
        // поля
        TypeNeuron type;
        double[] weight;
        double[] inputdata;
        double outputdata;

        // свойства
        public double[] Weight
        {
            get { return weight; }
            set { weight = value; }
        }      
        
        public double[] InputData
        {
            get { return inputdata; }
            set { inputdata = value; }
        }

        // конструктор
        public Neuron(TypeNeuron typeNeuron, double[] wght, double[] inpt)
        { 
            type = typeNeuron;
            weight = wght;
            inputdata = inpt;
        }

        public void Activator() 
        {
        
        }
    }
}
