using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _35_1_Angoldt_Neironka
{
    public partial class FormMain : Form
    {
        // поля
        private int[] inputData = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // входные данные
        //private int[] inputData = new int[15];
        // свойства

        // конструктор
        public FormMain()
        {
            InitializeComponent();
            //inputData = new int[567];
        }

        void ChangeStatDate(Button b, int index)
        {
            if (b.BackColor == Color.White)
            {
                b.BackColor = Color.Black;
                inputData[index] = 1;
            }
            else
            {
                b.BackColor = Color.White;
                inputData[index] = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e) => ChangeStatDate(button1, 0); // клик по кнопке 1
 
        private void button2_Click(object sender, EventArgs e) => ChangeStatDate(button2, 1); // клик по кнопке 2

        private void button3_Click(object sender, EventArgs e) => ChangeStatDate(button3, 2); // клик по кнопке 3

        private void button4_Click(object sender, EventArgs e) => ChangeStatDate(button4, 3); // клик по кнопке 4

        private void button5_Click(object sender, EventArgs e) => ChangeStatDate(button5, 4); // клик по кнопке 5

        private void button6_Click(object sender, EventArgs e) => ChangeStatDate(button6, 5); // клик по кнопке 6

        private void button7_Click(object sender, EventArgs e) => ChangeStatDate(button7, 6); // клик по кнопке 7

        private void button8_Click(object sender, EventArgs e) => ChangeStatDate(button8, 7); // клик по кнопке 8

        private void button9_Click(object sender, EventArgs e) => ChangeStatDate(button9, 8); // клик по кнопке 9

        private void button10_Click(object sender, EventArgs e) => ChangeStatDate(button10, 9); // клик по кнопке 10

        private void button11_Click(object sender, EventArgs e) => ChangeStatDate(button11, 10); // клик по кнопке 11

        private void button12_Click(object sender, EventArgs e) => ChangeStatDate(button12, 11); // клик по кнопке 12

        private void button13_Click(object sender, EventArgs e) => ChangeStatDate(button13, 12); // клик по кнопке 13

        private void button14_Click(object sender, EventArgs e) => ChangeStatDate(button14, 13); // клик по кнопке 14

        private void button15_Click(object sender, EventArgs e) => ChangeStatDate(button15, 14); // клик по кнопке 15

        private void buttonSAVE_LERN_Click(object sender, EventArgs e)
        {
            string tmpStr = numericUpDown1.Value.ToString();

            for (int i = 0; i < inputData.Length; i++)
            {
                tmpStr +=" " + inputData[i].ToString();
            }
            label1.Text = tmpStr.ToString();
            tmpStr += "\n";
        }
    }
}
