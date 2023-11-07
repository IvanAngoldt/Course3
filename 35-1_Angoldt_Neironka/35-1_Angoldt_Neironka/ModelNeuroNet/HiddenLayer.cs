namespace _35_1_Angoldt_Neironka.ModelNeuroNet
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int non, int nopn, TypeNeuron nt, string type) : base(non, nopn, nt, type)
        {

        }
        public override void Recognize(NeuroNet net, Layer nextLayer)
        {
            double[] hidden_out = new double[Neurons.Length];
            for (int i = 0; i < Neurons.Length; ++i)
                hidden_out[i] = Neurons[i].Output;
            nextLayer.Data = hidden_out;
        }
        // 4eto cdelat
        
    }
}
