using System;

namespace Calculator
{
    /// <summary>
    /// CalculatorMemory provides the functionality of Memory buttons
    /// </summary>
    public class CalculatorMemory
    {
        // storedValue: currently stored value in the memory
        private double storedValue;

        /// <summary>
        /// constructing CalculatorMemory, intial storedValue set as 0
        /// </summary>
        public CalculatorMemory()
        { storedValue = 0; }

        /// <summary>
        /// used to store the current value in the memory
        /// </summary>
        /// <param name="calculator"> Calculator to refer to </param>
        /// <param name="valueToStore"> value to be stored </param>
        public void store(Calculator calculator, double valueToStore)
        {
            storedValue = valueToStore;
            CalculatorTools.isDefaultValue = true;
            updateButtonStatus(calculator, false);
        }

        /// <summary>
        /// used to subtract the current value from the memory
        /// </summary>
        /// <param name="calculator"> Calculator to refer to </param>
        /// <param name="valueToSubtractFrom"> value to subtract </param>
        public void subtract(Calculator calculator, double valueToSubtractFrom)
        {
            storedValue -= valueToSubtractFrom;
            CalculatorTools.isDefaultValue = true;
            updateButtonStatus(calculator, false);
        }

        /// <summary>
        /// used to add a new value to the memory
        /// </summary>
        /// <param name="calculator"> Calculator to refer to </param>
        /// <param name="valueToAddTo"> value to be added </param>
        public void add(Calculator calculator, double valueToAddTo)
        {
            storedValue += valueToAddTo;
            CalculatorTools.isDefaultValue = true;
            updateButtonStatus(calculator, false);
        }

        /// <summary>
        /// used to recall the currently stored value from the memory
        /// </summary>
        /// <returns> stored value </returns>
        public double recall()
        {
            CalculatorTools.isDefaultValue = true;
            return storedValue;
        }

        /// <summary>
        /// used to clear the memory
        /// </summary>
        /// <param name="calculator"> Calculator to refer to </param>
        public void clear(Calculator calculator)
        {
            storedValue = 0;
            CalculatorTools.isDefaultValue = true;
            updateButtonStatus(calculator, true);
        }

        /// <summary>
        /// used to update memory buttons status
        /// </summary>
        /// <param name="calculator"> Calculator to refer to </param>
        /// <param name="isEmpty"> whether the memory is empty / cleared </param>
        private void updateButtonStatus(Calculator calculator, bool isEmpty)
        {
            calculator.getButtonMR().Enabled = calculator.getButtonMC().Enabled = 
                calculator.getButtonMDown().Enabled = !isEmpty;
        }
    }
}