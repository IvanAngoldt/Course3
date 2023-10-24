using System;
using System.IO;
using System.Windows.Forms;

namespace _35_1_Angoldt_Neironka.ModelNeuroNet
{
    abstract class Layer
    {
        protected string name_Layer;
        string pathDirWeights;
        string pathFileWeights;
        protected int numofneurons;
        protected int numofprevneurons;
        protected const double learningrate = 0.5d;
        protected const double momentum = 0.05d;
        protected double[,] lastdeltaweights;
        Neuron[] _neurons;

        public Neuron[] Neurons
        {
            get { return _neurons; }
            set { _neurons = value; }
        }
        public double[] Data
        {
            set
            {
                for (int i = 0; i < Neurons.Length; ++i) 
                {
                    Neurons[i].InputData = value;
                    Neurons[i].Activator(Neurons[i].InputData, Neurons[i].Weight);
                }
            }
        }

        // Конструктор
        protected Layer(int non, int nopn, TypeNeuron nt, string nm_Layer)
        {
            int i, j;
            numofneurons = non;
            numofprevneurons = nopn;
            Neurons = new Neuron[non];
            name_Layer = nm_Layer;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\";
            pathFileWeights = pathDirWeights + name_Layer + "_memory.csv";

            double[,] Weights;
        }

        public double[,] WeightInitialize(MemoryMod mm, string path)
        {
            switch (mm)
            {
                case MemoryMod.Get:
                    break;
                case MemoryMod.Set:
                    break;
                case MemoryMod.Init:
                    break;
                default:
                    break;
            }
            double[,] temp = { { } };
            return temp;
        }
    }
}
