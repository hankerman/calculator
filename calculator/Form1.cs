using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        double a, b;
        bool isDot, isFirstValue, isClear;
        string znak;


        public Form1()
        {
            InitializeComponent();
            isDot = false;            
            isFirstValue = false;
            isClear = false;
            a = 0;
            b = 0;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //кнопка 1

            OutValue(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //кнопка 2

            OutValue(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //кнопка 3

            OutValue(button7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //кнопка 4

            OutValue(button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //кнопка 5

            OutValue(button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //кнопка 6

            OutValue(button11);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //кнопка 7

            OutValue(button13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //кнопка 8

            OutValue(button14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //кнопка 9

            OutValue(button15);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //кнопка 0

            OutValue(button18);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //кнопка .
                        
            if (!isDot)
            {
                isDot = true;
                OutValue(button17);
            }
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //кнопка +
            Action(button16);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //кнопка -
            Action(button12);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //кнопка *
            Action(button8);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //кнопка /
            Action(button4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //кнопка <
            if(label1.Text != "")
            {
                string temp = label1.Text.Remove(label1.Text.Length - 1);
                label1.Text = temp;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //кнопка C
            ClearLabel1();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //кнопка =
            Action(button19);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //кнопка CE
            ClearLabel1();
            label2.Text = "";            
            isFirstValue = false;
            isClear = false;
        }

        private void OutValue(Button button)
        {
            if (isClear)
            {
                ClearLabel1();
                Val(button);
                isClear = false;
            }
            else
            {
                Val(button);
            }
                        
        }
        
        private void Val(Button button)
        {
            if (label1.Text == "0" && isDot)
            {
                label1.Text += button.Text;
            }
            else if (label1.Text != "0" && button.Text != ".")
            {
                label1.Text += button.Text;
            }
            else if (button.Text == ".")
            {
                label1.Text = "0.";
            }
        }
        private void Action(Button button)
        {
            if (isFirstValue)
            {
                if(button.Text == "+")
                {
                    
                    Znak(button.Text);
                    
                }
                else if(button.Text == "-")
                {
                    
                    Znak(button.Text);
                    
                }
                else if(button.Text == "*")
                {
                   
                    Znak(button.Text);
                    
                }
                else if (button.Text == "/")
                {
                    
                    Znak(button.Text);
                    
                }
                else if (button.Text == "=")
                {
                    
                    Znak(button.Text);
                   

                }
            }
            else
            {
                string temp = label1.Text;
                temp.Replace('.', ',');
                a = Convert.ToDouble(temp);                
                znak = button.Text;
                label2.Text += temp + " ";
                isFirstValue = true;
                ClearLabel1();
            }
        }

        private void Znak(string value)
        {
            
            string temp = label1.Text;
            label2.Text += znak + " " + temp + " ";
            temp.Replace('.', ',');
            b = Convert.ToDouble(temp);
            a = Decision();
            temp = a.ToString();
            temp.Replace(',', '.');
            label1.Text = temp;            
            znak = value;
            isClear = true;
            
        }
                
        private double Decision()
        {
            double result = 0;
            if (znak == "+")
            {
                result = a + b;
            }else if (znak == "-")
            {
                result = a - b;
            }else if (znak == "*")
            {
                result = a * b;
            }else if(znak == "/")
            {
                if(b != 0)
                {
                    result = a / b;
                }
            }
            else if (znak == "=")
            {
                result = a;
            }
            return result;
        }
        private void ClearLabel1()
        {
            isDot = false;
            label1.Text = "";
        }
    }
}
