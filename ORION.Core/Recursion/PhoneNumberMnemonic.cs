using System;
using System.Collections.Generic;

namespace ORION.Core.Recursion
{
    /// <summary>
    /// Almost every digit is associated with some letters in
    /// the alphabetic; this allows certain phone number 8464747328
    /// can be written as timisgreat; similarly, the phone number 
    /// 2686463 can be written as antoine or as ant6463.
    /// 
    /// It's important to note that a phone number doesn't represent a single
    /// sequence of letters, but rather multiple combanations of letters. For
    /// instance, the digit 2 can represewnt threee different letters
    /// (a,b and c).
    /// 
    /// A mnemonic is defined as pattern of letters, ideas, or associations
    /// that assist in remembering something, Companies oftentimes use 
    /// a mnemonic for their phone number to make it easier to remember.
    /// 
    /// Given a stringified phone number of any non-zero, write a function
    /// that returns all mnemonics, in any order.
    /// 
    /// For example, a valid mnemonic may only contain letter and digits 0 and 1.
    /// in other words, if a digit is able to represent a number the it 
    /// must be .Digit 0 and 1 are the only two digits that don't have
    /// letter representation of the keypad.
    /// </summary>
    public static class PhoneNumberMnemonic
    {
        public static Dictionary<char, string[]> DIGIT_LETTERS = new Dictionary<char, string[]>
        {
            {'0', new string[]{"0"}},
            {'1', new string[]{"1"}},
            {'2', new string[]{"a","b","c"}},
            {'3', new string[]{"d","e","f"}},
            {'4', new string[]{"g","h","i"}},
            {'5', new string[]{"j","k","l"}},
            {'6', new string[]{"m","n","o"}},
            {'7', new string[]{"p","q","r","s"}},
            {'8', new string[]{"t","u","v"}},
            {'9', new string[]{"w","x","y","z"}}
        }; 

        // O(4^n*n) time | O(4^n*n) space - where
        // n is the length of the phone number.
        public static List<string> PhoneNumberMnemonics(string phoneNumber)
        {
            string[] currentMnenomic = new string[phoneNumber.Length];
            Array.Fill(currentMnenomic, "0");

            List<string> mnemonicsFound = new List<string>();
            PhoneNumberMnemonicHelper(0, phoneNumber, currentMnenomic, mnemonicsFound);
            return mnemonicsFound;
        }

        private static void PhoneNumberMnemonicHelper(int index, string phoneNumber, string[] currentMnenomic, List<string> mnemonicsFound)
        {
            
            if (index == phoneNumber.Length)
            {
                string mnemonic = String.Join("", currentMnenomic);
                mnemonicsFound.Add(mnemonic);
            }
            else
            {
                char digit = phoneNumber[index];
                string[] letters = DIGIT_LETTERS[digit];

                foreach (string letter in letters)
                {
                    currentMnenomic[index]= letter;
                    PhoneNumberMnemonicHelper(index + 1, phoneNumber, currentMnenomic, mnemonicsFound);
                }
            }
        }
    }
}