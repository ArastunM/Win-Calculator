using System;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Calculator is main class of the Calculator App providing 
    /// functinality or link to functinality of all contents
    /// </summary>
    public partial class Calculator : Form
    {
        // calculatorMemory: class referred to for Memory buttond
        public static CalculatorMemory calculatorMemory;

        /// <summary>
        /// constructing the App
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// called upon form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            label.Text = "0";
            CalculatorTools.setDefaultParameters(0);
            calculatorMemory = new CalculatorMemory();
            this.ActiveControl = menuButton;

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
        }

        /// <summary>
        /// used to detect keyboard input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // refining raw key input using CalculatorKeyboard
            string[] result = CalculatorKeyboard.input(Convert.ToInt16(e.KeyCode));

            if (result[0] == null) { return; }

            // calling methods based on keyboard input
            switch (result[0])
            {
                case "0": { number_Click(result[1]); break; }
                case "1": { buttonEquals.PerformClick(); break; }
                case "2": { operation_Click(result[1]); break; }
                case "3": { buttonPercentage.PerformClick(); break; }
                case "4": { buttonDel.PerformClick(); break; }
            }
        }


        // Main Label
        private void label_Click(object sender, EventArgs e) { }
        // Side Label
        private void upperLabel_Click(object sender, EventArgs e) { }

        // Calculator Main NUMBER PAD Buttons
        /// <summary>
        /// called upon number entry
        /// </summary>
        /// <param name="number"> number pressed / entered </param>
        private void number_Click(string number)
        {
            bool preDefaultValue = CalculatorTools.isDefaultValue;
            label.Text = CalculatorTools.addNumber(number);

            if (label.Text.Equals(number)
                && preDefaultValue != CalculatorTools.isDefaultValue && CalculatorTools.isNewCalculation())
            {
                upperLabel.Text = "";
            }
        }
        private void button0_Click(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 0

        private void button1_Click_1(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 1

        private void button2_Click_1(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 2

        private void button3_Click(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 3

        private void button4_Click(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 4

        private void button5_Click(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 5

        private void button6_Click(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 6

        private void button1_Click(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 7

        private void button2_Click(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 8

        private void button9_Click(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // 9

        private void buttonComma_Click(object sender, EventArgs e)
        { number_Click((sender as Button).Text); } // .

        private void buttonNegate_Click(object sender, EventArgs e)
        {
            label.Text = CalculatorTools.negateNumber();
        }


        // Calculator Side NUMBER PAD Buttons
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            // only responding if the upperLabel is not empty
            if (upperLabel.Text.Length != 0)
            {
                if (!CalculatorTools.isNewCalculation())
                {
                    upperLabel.Text += label.Text + " = ";
                    label.Text = Convert.ToString(CalculatorTools.calculate());
                }
                else
                {
                    upperLabel.Text = label.Text + " + " + CalculatorTools.pastLeftSide + " = ";
                    CalculatorTools.rightSide = Convert.ToDouble(label.Text);
                    CalculatorTools.selectedOperationSign = CalculatorTools.pastOperationSign;
                    CalculatorTools.leftSide = CalculatorTools.pastLeftSide;
                    label.Text = Convert.ToString(CalculatorTools.calculate());
                }
                // adding the new calculation to History form
                History.addCalculation(upperLabel.Text.PadRight(4) + "\n" + label.Text.PadRight(4));
            }
        }

        /// <summary>
        /// used when an operation button is clicked
        /// </summary>
        /// <param name="usedOperator"> name of the operation clicked </param>
        private void operation_Click(string usedOperator)
        {
            if (CalculatorTools.isNewCalculation())
            {
                upperLabel.Text = label.Text + " " + usedOperator + " ";

                label.Text = Convert.ToString(CalculatorTools.rightSide);
                CalculatorTools.leftSide = CalculatorTools.rightSide;
                CalculatorTools.isDefaultValue = true;
            }
            else
            {
                if (!CalculatorTools.isDefaultValue)
                {
                    upperLabel.Text = Convert.ToString(CalculatorTools.calculate()) + " " + usedOperator + " ";
                    label.Text = "";

                    label.Text = Convert.ToString(CalculatorTools.rightSide);
                    CalculatorTools.leftSide = CalculatorTools.rightSide;
                    CalculatorTools.isDefaultValue = true;
                }
            }

            // setting the selectedOperationSign accordingly
            CalculatorTools.selectedOperationSign = usedOperator;
        }

        private void button11_Click(object sender, EventArgs e)
        { operation_Click((sender as Button).Text); } // +

        private void button12_Click(object sender, EventArgs e)
        { operation_Click((sender as Button).Text); } // -

        private void button13_Click(object sender, EventArgs e)
        { operation_Click((sender as Button).Text); } // ×

        private void button14_Click(object sender, EventArgs e)
        { operation_Click((sender as Button).Text); } // ÷

        // Delete button
        private void button15_Click(object sender, EventArgs e)
        {
            if (label.Text.Length != 0 && !CalculatorTools.isDefaultValue)
            {
                label.Text = label.Text.Substring(0, label.Text.Length - 1);
                CalculatorTools.setNumber(label.Text);
            }
        }

        /// <summary>
        /// used to clear all calculator entries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonC_Click(object sender, EventArgs e)
        {
            label.Text = "0"; upperLabel.Text = ""; CalculatorTools.setDefaultParameters(0);
        }

        /// <summary>
        /// used to clear the current calculator entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCE_Click(object sender, EventArgs e)
        {
            label.Text = "0";
            CalculatorTools.leftSide = 0;

            if (CalculatorTools.isNewCalculation())
            {
                upperLabel.Text = ""; CalculatorTools.setDefaultParameters(0);
            }
        }

        // Advanced calculations
        private void buttonSqrt_Click(object sender, EventArgs e)
        { label.Text = CalculatorTools.calculateAdvanced((sender as Button).Text); }

        private void buttonSquare_Click(object sender, EventArgs e)
        { label.Text = CalculatorTools.calculateAdvanced((sender as Button).Text); }

        private void buttonOneOver_Click(object sender, EventArgs e)
        { label.Text = CalculatorTools.calculateAdvanced((sender as Button).Text); }

        private void buttonPercentage_Click(object sender, EventArgs e)
        { label.Text = CalculatorTools.calculateAdvanced((sender as Button).Text); }


        // Memory buttons
        private void buttonMC_Click(object sender, EventArgs e)
        { calculatorMemory.clear(this); } // Memory Clear

        private void buttonMR_Click(object sender, EventArgs e)
        { label.Text = Convert.ToString(calculatorMemory.recall()); } // Memory Recall

        private void buttonMPlus_Click(object sender, EventArgs e)
        { calculatorMemory.add(this, Convert.ToDouble(label.Text)); } // Memory Add

        private void buttonMMin_Click(object sender, EventArgs e)
        { calculatorMemory.subtract(this, Convert.ToDouble(label.Text)); } // Memory Remove

        private void buttonMS_Click(object sender, EventArgs e)
        { calculatorMemory.store(this, Convert.ToDouble(label.Text)); } // Memory Store

        private void buttonMDown_Click(object sender, EventArgs e)
        {
            // TO BE IMPLEMENTED
        }

        /// <summary>
        /// used to History button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            // launches the History form
            new History().Show(this);
        }

        private void typeName_Click(object sender, EventArgs e)
        {
            // TO BE IMPLEMENTED
        }
    }
}
