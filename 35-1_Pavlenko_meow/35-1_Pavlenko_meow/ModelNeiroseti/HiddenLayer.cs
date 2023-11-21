﻿

namespace _35_1_Pavlenko_meow.ModelNeiroseti
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int non,int nopn,TypeNeyron tn, string type):base(non, nopn, tn, type) { }
       
        public override void Recognize(NeiroNet net,Layer nextLayer)
        {
            double[] hidden_out=new double[Neurons.Length];
            for (int i=0;i<Neurons.Length;i++)
            {
                hidden_out[i]=Neurons[i].Outputdata;
            }
            nextLayer.Data=hidden_out;
        }

        public override double[] BackwardPass(double[] gr_sums)
        {
            double[] gr_sum=new double[numofprevneurons];
            for (int j=0;j<gr_sum.Length;j++)
            {
                double sum = 0;
                for (int k = 0; k < Neurons.Length; k++)
                    sum += Neurons[k].Weight[j] * Neurons[k].Derivative * gr_sum[k];
                gr_sum[j]=sum;
            }
            for (int i=0;i<numofneurons;i++)
                for (int n=0;n<numofprevneurons+1;n++)
                {
                    double deltaw;
                    if (n==0)
                    {
                        deltaw = momentum * lastdelraweights[i, 0] + learningrate * Neurons[i].Derivative * gr_sums[i];
                    }
                    else
                    {
                        deltaw = momentum * lastdelraweights[i, n] + learningrate * Neurons[i].Inputdata[n - 1] * Neurons[i].Derivative * gr_sums[i];
                    }    
                }
            return gr_sum;
        }
    }
}
