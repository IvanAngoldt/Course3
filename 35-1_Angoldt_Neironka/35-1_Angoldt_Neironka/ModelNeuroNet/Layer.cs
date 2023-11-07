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
        Neuron[] neurons;

        public Neuron[] Neurons
        {
            get { return neurons; }
            set { neurons = value; }
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

            if (File.Exists(pathFileWeights))
                Weights = WeightInitialize(MemoryMod.Get, pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathDirWeights);
                Weights = WeightInitialize(MemoryMod.Init, pathFileWeights);
            }

            lastdeltaweights = new double[non, nopn + 1];

            for (i = 0; i < non; ++i)
            {
                double[] tmp_weights = new double[nopn + 1];
                for (j = 0; j < nopn + 1; ++j)
                {
                    tmp_weights[j] = Weights[i, j];
                }
                // Neurons[i] = new Neuron(nt, tmp_weights, );
            }
        }

        public double[,] WeightInitialize(MemoryMod mm, string path)
        {
            char[] delim = new char[] { ';', ' ', '_' };
            string tmpStr;
            string[] tmpStrWeights;
            double[,] weights = new double[numofneurons, numofprevneurons];

            switch (mm)
            {
                case MemoryMod.Get:
                    break;
                case MemoryMod.Set:
                    break;
                case MemoryMod.Init:
                    Random random = new Random();
                    double[] tmpArr = new double[numofprevneurons + 1];
                    tmpStrWeights = new string[numofprevneurons];

                    for (int i = 0; i < numofneurons; i++)
                    {
                        for (int j = 0; j < numofprevneurons + 1; j++)
                            tmpArr[j] = 0.02 * random.NextDouble() - 0.01;
                        weights[i, 0] = tmpArr[0];
                        tmpStr = weights[1, 0].ToString();

                        for (int j = 1; j < numofprevneurons + 1; j++)
                        {
                            weights[i, j] = tmpArr[j];
                            tmpStr += delim[0] + weights[i, j].ToString();
                        }
                        tmpStrWeights[i] = tmpStr;
                    }
                    File.WriteAllLines(path, tmpStrWeights);
                    break;
            }
            return weights;
        }
        abstract public void Recognize(NeuroNet net, Layer nextLayer);
        abstract public double[] BackwardPass(double[] stuff);
        public
    }
}
