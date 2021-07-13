using System;

namespace Calculator
{
    /// <summary>
    /// CalculatorKeyboard provides keyboard support for Calculator App
    /// </summary>
    public static class CalculatorKeyboard
    {
        // shiftOn: determines whether shift button has been enabled
        public static bool shiftOn = false;

        /// <summary>
        /// used to determine keyboard input
        /// </summary>
        /// <param name="inputCode"> keyboard input code </param>
        /// <returns> reuslt array containing pressed calculator button and its type </returns>
        public static string[] input(int inputCode)
        {
            string[] resultArray = new string[2];

            bool isDigit = 48 <= inputCode && inputCode <= 57;
            bool isComma = inputCode == 190;
            bool isPlus = shiftOn && inputCode == 187;
            bool isEqual = (!shiftOn && inputCode == 187) || inputCode == 13;
            bool isMinus = !shiftOn && inputCode == 189;
            bool isMultiply = shiftOn && inputCode == 56;
            bool isDivide = inputCode == 191;
            bool isDelete = inputCode == 8;
            bool isPercent = shiftOn && inputCode == 53;

            shiftOn = inputCode == 16;

            // returnValue [0] - type, [1] - value
            // types
            // 0 - numberPad
            // 1 - equals button
            // 2 - operation button
            // 3 - percentage button
            // 4 - delete button

            if (isPercent) { resultArray[0] = "3"; resultArray[1] = "%"; }
            else if (isDelete) { resultArray[0] = "4"; resultArray[1] = "del"; }
            else if (isDivide) { resultArray[0] = "2"; resultArray[1] = "÷"; }
            else if (isMultiply) { resultArray[0] = "2"; resultArray[1] = "×"; }
            else if (isMinus) { resultArray[0] = "2"; resultArray[1] = "-"; }
            else if (isEqual) { resultArray[0] = "1"; resultArray[1] = "="; }
            else if (isPlus) { resultArray[0] = "2"; resultArray[1] = "+"; }
            else if (isComma) { resultArray[0] = "0"; resultArray[1] = "."; }
            else if (isDigit) { resultArray[0] = "0"; resultArray[1] = Convert.ToString(inputCode - 48); }
            return resultArray;
        }
    }
}

