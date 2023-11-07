namespace _35_1_Angoldt_Neironka.ModelNeuroNet
{
    class OutputLayer : Layer
    {
        public OutputLayer(int non, int nopn, TypeNeuron nt, string type) : base(non, nopn, nt, type)
        {
            double e_sum = 0;
            for (int i = 0; i < Neurons.Length; i++)
                e_sum += Neurons[i].Output;
            for (int i = 0; i < Neurons.Length; i++)
                NeuroNet.fact[i] = Neurons[i].Output / e_sum;
        }
    }
}
