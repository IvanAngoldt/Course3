

namespace _35_1_Pavlenko_meow.ModelNeiroseti
{
    class OutputLayer : Layer
    {
        public OutputLayer(int non, int nopn, TypeNeyron tn, string type) : base(non, nopn, tn, type) { }


        public override void Recognize(NeiroNet net, Layer nextLayer)
        {
            double e_sum = 0;
            for (int i = 0; i < Neurons.Length; i++)
                e_sum += Neurons[i].Outputdata;
            for (int i = 0; i < Neurons.Length; i++)
                net.fact[i] = Neurons[i].Outputdata / e_sum;
        }
        public override double[] BackwardPass(double[] errors)
        {
            double[] gr_sum=new double[numofprevneurons + 1];
            for (int j = 0;j<gr_sum.Length;j++)
            {
                double sum=0;
                for (int k = 0;k<Neurons.Length;++k)
                    sum += Neurons[k].Weight[j] * errors[k];
                gr_sum[j] = sum;
            }
            for (int i=0;i<numofneurons;i++)
                for (int n=0;n<numofprevneurons+1;++n)
                {
                    double deltaw = (n==0)?(momentum*lastdelraweights[i,0]+learningrate*errors[i]):
                        (momentum*lastdelraweights[i,n]+learningrate*Neurons[i].Inputdata[n-1]*errors[i]);
                    lastdelraweights[i,n]=deltaw;
                    Neurons[i].Weight[n]+=deltaw;
                }
            return gr_sum;
        }
    }
}
