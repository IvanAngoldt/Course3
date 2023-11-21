using System;

namespace _35_1_Angoldt_Neironka.ModelNeuroNet
{
    class NeuroNet
    {
        // все слои нейросети

        private InputLayer input_Layer = null;
        private HiddenLayer hidden_Layer1 = new HiddenLayer(71, 15, TypeNeuron.Hidden, nameof(hidden_Layer1));
        private HiddenLayer hidden_Layer2 = new HiddenLayer(30, 71, TypeNeuron.Hidden, nameof(hidden_Layer2));
        private OutputLayer output_Layer = new OutputLayer(10, 30, TypeNeuron.Output, nameof(output_Layer));

        // среднее значение энергии ошибки ошибки эпохи обучения
        private double e_error_avr;
        public double E_error_avr
        {
            get => e_error_avr;
            set => e_error_avr = value;
        }

        public double[] fact;
        public NeuroNet(NetworkMod nm)
        {
            // input_Layer = new InputLayer(nm);
        }

        //прямой проход нейросети
        public void ForwardPass(NeuroNet net, double[] netInput)
        { 
            net.hidden_Layer1.Data = netInput;
            net.hidden_Layer1.Recognize(null, net.hidden_Layer2);
            net.hidden_Layer2.Recognize(null, net.output_Layer);
            net.output_Layer.Recognize(net, null);
        }
    }
}
