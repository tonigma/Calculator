using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string performence = "";
        bool isOperationPerfored = false;
        string firstNum, secondNum;
        double memoryTemp = 0;
        double num1;
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void clickOnButton(object sender, EventArgs e)
        {
            if (textbox_actionField.Text.Equals("0") || isOperationPerfored)
            {
                textbox_actionField.Clear();
            }
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textbox_actionField.Text.Contains("."))
                {

                    textbox_actionField.Text += "0" + button.Text;
                }

            }
            else
            {
                textbox_actionField.Text +=  button.Text;
            }
            
            isOperationPerfored = false;
        }

        private void oparationAction(object sender, EventArgs e)
        {
                Button button = (Button)sender;
            if (result != 0 && isOperationPerfored == false)
            {

                ButtonEquals.PerformClick();
                isOperationPerfored = true;
                performence = button.Text;
                lblShowOperation.Text = result + " " + performence;
            }
            else
            {
                performence = button.Text;
                result = double.Parse(textbox_actionField.Text);
                lblShowOperation.Text = result + " " + performence;
                isOperationPerfored = true;
            }
            num1 = double.Parse(textbox_actionField.Text);
            firstNum = lblShowOperation.Text;
        }

        private void ButtonCE_Click(object sender, EventArgs e)
        {
            lblShowOperation.Text = "";
            textbox_actionField.Text = "0";

        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            lblShowOperation.Text = "";
            textbox_actionField.Text = "0";
            result = 0;
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            secondNum = textbox_actionField.Text;
            lblShowOperation.Text = "";
   
            switch (performence)
            {
                case "+":
                    textbox_actionField.Text = (double.Parse(secondNum) + num1).ToString();
                    break;
                case "-":
                    textbox_actionField.Text = (num1 - double.Parse(textbox_actionField.Text)).ToString();
                    break;
                case "*":
                    textbox_actionField.Text = (num1 * double.Parse(textbox_actionField.Text)).ToString();
                    break;
                case "/":
                    textbox_actionField.Text = (num1 / double.Parse(textbox_actionField.Text)).ToString();
                    break;
                default:
                    break;
            }

            result = double.Parse(textbox_actionField.Text);
            isOperationPerfored = true;


            displeyHistory.AppendText(firstNum + " "+ secondNum + "=" + textbox_actionField.Text + "\n");
            lblTextHistory.Text = "";
        }

        private void ButtonClearHistory_Click(object sender, EventArgs e)
        {
            displeyHistory.Clear();
            if (lblTextHistory.Text.Equals(""))
            {
                lblTextHistory.Text = "There's no history yet.";
            }
            displeyHistory.ScrollBars = 0;
            displeyHistory.ScrollBars = RichTextBoxScrollBars.Vertical;
        }

        private void MemoryMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(($"The number in memory is: {memoryTemp}").ToString());
        }

        private void MemoryAddition_Click(object sender, EventArgs e)
        {
            memoryTemp = (memoryTemp + double.Parse(textbox_actionField.Text));
            
        }

        private void AddMemory_Click(object sender, EventArgs e)
        {
            memoryTemp = (double.Parse(textbox_actionField.Text));    
        }

        private void MemorySubtraction_Click(object sender, EventArgs e)
        {
            memoryTemp = (memoryTemp - double.Parse(textbox_actionField.Text));
        }

        private void MemoryClear_Click(object sender, EventArgs e)
        {
            memoryTemp = 0;
        }

        private void MemoryRecall_Click(object sender, EventArgs e)
        {
            textbox_actionField.Text = memoryTemp.ToString();
        }

        private void ButtonPercent_Click(object sender, EventArgs e)
        {
            if (performence.Equals("+"))
            {
                textbox_actionField.Text = (double.Parse(textbox_actionField.Text) * (result / 100)).ToString();
            }
            else if (performence.Equals("-"))
            {
                textbox_actionField.Text = (double.Parse(textbox_actionField.Text) * (result / 100)).ToString();
            }
            else if (performence.Equals("*"))
            {
                textbox_actionField.Text =  (double.Parse(textbox_actionField.Text) / 100).ToString();
            }
            else if (performence.Equals("/"))
            {
                textbox_actionField.Text =  (double.Parse(textbox_actionField.Text) / 100).ToString();
            }


        }

        private void DispleyHistory_TextChanged(object sender, EventArgs e)
        {

        }

        private void Textbox_actionField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
