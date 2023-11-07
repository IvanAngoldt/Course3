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

        public double Output
        {
            get => outputdata;
        }

        // конструктор
        public Neuron(TypeNeuron typeNeuron, double[] wght, double[] inpt)
        { 
            type = typeNeuron;
            weight = wght;
            inputdata = inpt;
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public void Activator() 
        {
            double weightedSum = weight[0];
            for (int i = 0; i < inputdata.Length; i++)
            { 
                weightedSum += inputdata[i] * weight[i + 1];
            }
            outputdata = Sigmoid(weightedSum);
        }

        public void Activator(double[] input, double[] wght)
        {
            double weightedSum = wght[0];
            for (int i = 0; i < input.Length; i++)
            {
                weightedSum += input[i] * wght[i + 1];
            }
            outputdata = Sigmoid(weightedSum);
        }
    }
}
