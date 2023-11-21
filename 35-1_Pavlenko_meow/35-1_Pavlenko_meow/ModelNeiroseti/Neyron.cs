using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_1_Pavlenko_meow.ModelNeiroseti
{
    class Neyron
    {
        //поля
        TypeNeyron type;
        double[] weight;
        double[] inputdata;
        double outputdata;
        double derivative;

        //свойства
        public double[] Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double[] Inputdata
        {
            get { return inputdata; }
            set { inputdata = value; }
        }

        public double Outputdata
        {
            get { return outputdata; }
            set { outputdata = value; }
        }

        public double Derivative { get => derivative; }

        //конструктор
        public Neyron(TypeNeyron typeNeyron, double[] wght, double[] inpt)
        {
            type= typeNeyron;
            weight = wght;
            inputdata = inpt;
        }


        //функция активации
        private double Leaky(double x)
        {
            return Math.Max(0, x);
        }

        public void Activator()
        {
            double sum = weight[0];
            for (int i=0;i<inputdata.Length;i++)
            {
                sum+=inputdata[i]*weight[i + 1];
            }
            outputdata=Leaky(sum);
        }

        public void Activator(double[] input, double[] wght)
        {
            double sum = wght[0];
            for (int i = 0; i < inputdata.Length; i++)
            {
                sum += inputdata[i] * weight[i + 1];
            }
            outputdata = Leaky(sum);
        }
    }
}
