using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator

{
    /// <summary>
    /// CalculatorTools provides additional calculation tools for the Calculator App
    /// <example> adding and setting values, calculations and other operations </example>
    /// </summary>
    class CalculatorTools
    {
        // selectedOperationSign: currently selected operation (+-*/)
        public static string selectedOperationSign;
        // rightSide: right side of the current calculation / equation
        public static double rightSide;
        // leftSide: left side of the current calculation / equation
        public static double leftSide;

        // isFloatingPoint: whether current value is a floating point
        public static bool isFloatingPoint;
        // isDefaultValue: whether current value is default
        // default values are nullified upon another value entry
        public static bool isDefaultValue;

        // pastOperationSign: previous operation sign
        public static string pastOperationSign;
        // pastLeftSide: left side of the equation in previous calculation
        public static double pastLeftSide;

        /// <summary>
        /// Adds a new number to current calculation / equation
        /// </summary>
        /// <param name="num"> number to be added </param>
        /// <returns> added number </returns>
        public static string addNumber(string num)
        {
            string returnValue;
            // checking if number to add is a floating point
            if (num.Equals(".")) { return getFloatingValue(); }
            string numToAdd = isFloatingPoint ? "." + num : num;

            // adding to either right or left side of the calculation
            if (isNewCalculation())
            {
                if (isDefaultValue)
                {              
                    setDefaultParameters(Convert.ToDouble(numToAdd));
                    isDefaultValue = false;
                }
                else
                {
                    rightSide = Convert.ToDouble(Convert.ToString(rightSide) + numToAdd);
                }
            }
            else
            {
                if (isDefaultValue)
                {
                    leftSide = Convert.ToDouble(numToAdd);
                    isDefaultValue = false;
                }
                else
                {
                    leftSide = Convert.ToDouble(Convert.ToString(leftSide) + numToAdd);
                }
            }

            // returning added number as a string
            isFloatingPoint = false;
            returnValue = Convert.ToString(isNewCalculation() ? rightSide : leftSide);
            return returnValue;
        }

        /// <summary>
        /// setting a new number to current calculation / equation
        /// </summary>
        /// <param name="newNum"> new number to be set </param>
        public static void setNumber(string newNum)
        {
            // setting the number to either right or left side
            if (isNewCalculation())
                try
                {
                    rightSide = Convert.ToDouble(newNum);
                } catch(FormatException) { rightSide = 0; }
            else
                try
                {
                    leftSide = Convert.ToDouble(newNum);
                }
                catch (FormatException) { leftSide = 0; }
        }


        /// <summary>
        /// making a new calculation based on currently set variables
        /// </summary>
        /// <returns> calculation result </returns>
        public static double calculate()
        {
            double returnValue = 0;
            if (!isNewCalculation())
            {
                // calculation based on the selected operation
                switch (selectedOperationSign)
                {
                    case "+": { returnValue = rightSide + leftSide; break; }
                    case "-": { returnValue = rightSide - leftSide; break; }
                    case "×": { returnValue = rightSide * leftSide; break; }
                    case "÷": { returnValue = rightSide / leftSide; break; }
                }
                // ressetting calculation values
                setDefaultParameters(returnValue);
            } return returnValue;
        }

        /// <summary>
        /// resets calculation values
        /// </summary>
        /// <param name="newValue"> result of past calculation to be
        /// set as the right side </param>
        public static void setDefaultParameters(double newValue)
        {
            pastOperationSign = selectedOperationSign;
            selectedOperationSign = null;
            isDefaultValue = true;

            rightSide = newValue;
            pastLeftSide = leftSide;
            leftSide = 0;
        }

        /// <summary>
        /// checks if a new calculation has been started
        /// </summary>
        /// <returns> true if a new calculation has been started, false otherwise </returns>
        public static bool isNewCalculation()
        {
            return selectedOperationSign == null && leftSide == 0;
        }

        /// <summary>
        /// used to return current calculation side as a floating point
        /// </summary>
        /// <returns> floating point of current value </returns>
        public static string getFloatingValue()
        {
            isFloatingPoint = true;
            double returnValue = isNewCalculation() ? rightSide : leftSide;
            returnValue = isDefaultValue ? 0 : returnValue;
            return Convert.ToString(returnValue) + ".";
        }

        /// <summary>
        /// used to negate the current calculation side
        /// </summary>
        /// <returns> negated form of current value </returns>
        public static string negateNumber()
        {
            if (isNewCalculation())
            {
                rightSide = 0 - rightSide;
                return Convert.ToString(rightSide);
            } 
            else
            {
                leftSide = 0 - leftSide;
                return Convert.ToString(leftSide);
            }
        }

        /// <summary>
        /// used for more advanced calculator operations
        /// </summary>
        /// <param name="advancedOperator"> advanced operator to use </param>
        /// <returns> calculation result </returns>
        public static string calculateAdvanced(string advancedOperator)
        {
            if (!advancedOperator.Equals("%")) { Program.calculatorForm.upperLabel.Text = ""; }
            double returnValue = isNewCalculation() ? rightSide : leftSide;
            switch(advancedOperator)
            {
                case "x2": { returnValue *= returnValue; break; }
                case "√x": { returnValue = Math.Sqrt(returnValue); break; }
                case "1/x": { returnValue = 1 / returnValue; break; }
                case "%": { returnValue = rightSide * leftSide / 100; isDefaultValue = true; break; }
            }

            if (isNewCalculation()) { rightSide = returnValue; }
            else { leftSide = returnValue; }

            CalculatorTools.isDefaultValue = true;

            // returns the result of the calculation (to be set in label)
            return Convert.ToString(returnValue);
        }
    }
}
