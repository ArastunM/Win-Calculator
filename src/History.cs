using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// History provides the functinality of History form contents
    /// </summary>
    public partial class History : Form
    {
        // pastCalculations: the last 3 past calculations
        public static string[] pastCalculations = new string[3];
        // slots: button slots storing pastCalculations
        private static Button[] slots;

        /// <summary>
        /// Constructing the History form
        /// </summary>
        public History()
        {
            InitializeComponent();
        }

        /// <summary>
        /// called upon History form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void History_Load(object sender, EventArgs e)
        {
            // setting config height and fitting
            double config_height = 0.647;
            double config_fitting = 0.955;

            // resizing History form to fit the main Calculator form
            Calculator mainForm = Program.calculatorForm;
            int width = Convert.ToInt32(mainForm.Size.Width * config_fitting);
            int height = Convert.ToInt32(mainForm.Size.Height * config_fitting * config_height);
            Size = new Size(width, height);

            this.CenterToParent();
            int yCoord = Convert.ToInt32(mainForm.Location.Y + mainForm.Height - Height * 1.022);
            Location = new Point(this.Location.X, yCoord);

            // initialising the slots
            slots = new Button[] { slot1, slot2, slot3 };

            // adding stored pastCalculations to the slots
            addCalcToSlot();
            // updating the visibility of the content based on pastCalculations
            updateVisibility();


        }

        /// <summary>
        /// called when unfocing from the form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivate(EventArgs e)
        {
            // History form is closed upon deactivation
            base.OnDeactivate(e);
            this.Controls.Clear();
            this.Close();
        }

        /// <summary>
        /// used to add past calculations to button slots
        /// </summary>
        private static void addCalcToSlot()
        {
            for (int j = 0; j < getFullIndexCount(pastCalculations); j++)
                slots[getFullIndexCount(slots)].Text = pastCalculations[j];
        }

        /// <summary>
        /// used to add a new calculation, 
        /// usually called from Calculator form
        /// </summary>
        /// <param name="details"></param>
        public static void addCalculation(string details)
        {
            int filledSlotCount = getFullIndexCount(pastCalculations);

            // in case pastCalculations is full all elements are shifted 1 index back
            // resulting the loss of the 1st index and addition of the current calculation
            if (filledSlotCount != pastCalculations.Length)
                pastCalculations[filledSlotCount] = details;
            else
                pastCalculations = (string[])shiftList(pastCalculations, details);
        }

        /// <summary>
        /// called upon slot click, 
        /// shows the clicked calculation in Calculator form
        /// </summary>
        /// <param name="content"></param>
        private void slot_Click(string content) {
            if (content.Split("\n").Length != 2) { return; }

            string calculation = content.Split("\n")[0].Trim() + " ",
                result = content.Split("\n")[1].Trim();
            CalculatorTools.setDefaultParameters(Convert.ToDouble(result));

            Program.calculatorForm.upperLabel.Text = calculation;
            Program.calculatorForm.label.Text = result;
            CalculatorTools.pastLeftSide = Convert.ToDouble(calculation.Split(" ")[2]);
            CalculatorTools.pastOperationSign = calculation.Split(" ")[1];
            
            // closing the History form
            this.Controls.Clear();
            this.Close();
        }

        private void slot1_Click(object sender, EventArgs e)
        { slot_Click((sender as Button).Text); }
        private void slot2_Click(object sender, EventArgs e)
        { slot_Click((sender as Button).Text); }
        private void slot3_Click(object sender, EventArgs e)
        { slot_Click((sender as Button).Text); }

        /// <summary>
        /// called upon remove history button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeHistoryButton_Click(object sender, EventArgs e)
        {
            // removing all stored past calculations
            pastCalculations = new string[3];
            foreach (Button slot in slots) {
                slot.Text = null;
            }
            updateVisibility();
        }

        /// <summary>
        /// updates the visibility of History form contents
        /// </summary>
        private void updateVisibility()
        {
            for (int i = 0; i < slots.Length; i++)
                slots[i].Visible = slots[i].Text != "";

            topLabel.Visible = !slots[0].Visible;
            removeHistoryButton.Visible = slots[0].Visible;
        }

        /// <summary>
        /// returns the amount of filled / full indexes in given list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static int getFullIndexCount(Object[] list)
        {
            int count = 0;

            foreach (Object element in list)
            {
                if (typeof(Button[]).IsInstanceOfType(list))
                {
                    Button adjustedElement = (Button)element;
                    count = adjustedElement.Text != "" ? ++count : count;
                }
                else if (typeof(string[]).IsInstanceOfType(list))
                {
                    string adjustedElement = (string)element;
                    count = adjustedElement != null ? ++count : count;
                }
            } return count;
        }

        /// <summary>
        /// shifts all elements of the list 1 index back, 
        /// adding a new element to emptied last index
        /// </summary>
        /// <param name="list"></param>
        /// <param name="newLastElement"></param>
        /// <returns></returns>
        private static Object[] shiftList(Object[] list, Object newLastElement)
        {
            for (int i = 0; i < getFullIndexCount(list) - 1; i++)
                list[i] = list[i + 1];
          
            list[getFullIndexCount(list) - 1] = newLastElement;
            return list;
        }
    }
}
