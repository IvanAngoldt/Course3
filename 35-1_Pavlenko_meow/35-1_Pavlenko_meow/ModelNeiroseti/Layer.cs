using System;
using System.IO;
using System.Windows.Forms;
using static System.Math;

namespace _35_1_Pavlenko_meow.ModelNeiroseti
{
    abstract class Layer
    {
        //поля
        protected string name_Layer;
        string pathDirWeights;
        string pathFileWeights;
        protected int numofneurons;
        protected int numofprevneurons;
        protected const double learningrate = 0.5;
        protected const double momentum = 0.05d;
        protected double[,] lastdelraweights;
        Neyron[] neurons;

        //свойства
        public Neyron[] Neurons
        {
            get { return neurons; }
            set { neurons = value; }
        }

        public double[] Data
        {
            set
            {
                for (int i=0;i<Neurons.Length;++i)
                {
                    Neurons[i].Inputdata = value;
                    Neurons[i].Activator(Neurons[i].Inputdata, Neurons[i].Weight);
                }
            }
        }


        //методы

        //конструктор
        protected Layer(int non, int nopn,TypeNeyron tn, string nm_Layer)
        {
            int i, j;
            numofneurons = non;
            numofprevneurons = nopn;
            neurons = new Neyron[non];
            name_Layer = nm_Layer;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\";
            pathFileWeights = pathDirWeights + name_Layer + "_memory.csv";

            double[,] Weights;

            if (File.Exists(pathFileWeights))
                Weights = WeightInitialize(MemoryMode.Get, pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathDirWeights);
                Weights = WeightInitialize(MemoryMode.Init, pathFileWeights);
            }

            lastdelraweights = new double[non, nopn + 1];

            for (i = 0; i < non; ++i)
            {
                double[] tmp_weights = new double[nopn + 1];
                for (j = 0; j < nopn + 1; ++j)
                {
                    tmp_weights[j] = Weights[i, j];
                }
                //neurons[i]=new Neyron(tmp_weights, tn);
            }
        }

        public double[,] WeightInitialize(MemoryMode mm,string path)
        {
            char[] delim = new char[] { ';' };
            string[] tmpStrWeights;
            string tmpStr;
            double[,] weights = new double[numofneurons, numofprevneurons + 1];
            switch (mm)
            {
                case MemoryMode.Get:
                    break;
                case MemoryMode.Set:
                    break;
                case MemoryMode.Init:
                    Random random=new Random();
                    double[] tmpArr=new double[numofneurons + 1];
                    tmpStrWeights = new string[numofneurons];
                    for (int i=0;i<numofneurons;i++)
                    {
                        for (int j = 0; j < numofprevneurons + 1; j++)
                            tmpArr[j] = 0.02 * random.NextDouble() - 0.01;

                        double tmpRatio = 1.0d / Math.Sqrt(Calc_Dispers(tmpArr) * (numofprevneurons + 1));
                        double tmpShift = Calc_Average(tmpArr);
                        weights[i, 0] = tmpArr[0];
                        tmpStr = weights[i,0].ToString();

                        for(int j = 1; j < numofprevneurons + 1; j++)
                        {
                            weights[i, j] = tmpArr[j];
                            tmpStr+=delim[0]+weights[i,j].ToString();
                        }
                        tmpStrWeights[i] = tmpStr;
                    }
                    File.WriteAllLines(path, tmpStrWeights);
                    break;
            }
            
            return weights;
        }

        protected double Calc_Average(double[] arr)
        {
            return arr.Sum() / arr.Length;
        }
        protected double Calc_Dispers(double[] arr)
        {
            double mean=Calc_Average(arr);
            double[] squareDifferences=new double[arr.Length];
            for (int i = 0;i< arr.Length;i++)
            {
                squareDifferences[i] = Math.Pow(arr[i] - mean, 2);
            }
            double dispersion = squareDifferences.Sum() / squareDifferences.Length;
            return dispersion;
        }

        abstract public void Recognize(NeiroNet net, Layer nextLayer);
        abstract public double[] BackwardPass(double[] stuff);


    }


    

    
}
