using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Compiler_T3
{
    sealed class FirstFinder
    {
        // Example: 1)  E -> T R;
        //          2)  R -> + T R;
        //          3)  R -> - T R;
        //          4)  R -> ɛ;
        //          5)  T -> F P;
        //          6)  P -> * F P;
        //          7)  P -> / F P;
        //          8)  P -> ɛ;
        //          9)  F -> id;
        //         10)  F -> num;
        //         11)  F -> ( E );
        //
        // According by Example:   (have Order)   1  2  3  4  5  6  7  8  9  10  11  (Number of Grammar)
        //                           Left Token : E  R  R  R  T  P  P  P  F  F   F   (nonTerminal Name with duplicate)
        //                         Right Tokens : T  +  -  ɛ  F  *  /  ɛ  id num ɛ   (none-Terminal or Terminal
        //                                        R  T  T     P  F  F                 without duplicate in
        //                                           R  R        P  P                 nonTerminal[][] 2D Array's)
        //
        //                  Left Token:  E  R  T  P  F   (nonTerminal without duplicate) nonTName
        // Number of Duplicate Grammar:  1  2  5  6  9   (Index Of Duplicate nonTerminal) nonTNum
        //                                  3     7  10
        //                                  4     8  11
        //
        //
        private string[][] nonTerminal; // save Part of right tokens in grammar
        private string[] nonTerminalName; // save Part of left token in grammar

        
        public string[][] NonTerminalFirst { get { return nonTerminalFirst; } } // ReadOnly for other class
        private string[][] nonTerminalFirst; // save First Data on any nonTerminal
        
        
        private string[] nonTName; // save nonTerminal Name without duplicate : E , R , T , ...
        public string[] NonTName { get { return nonTName; } } // readOnly
        bool[] nonTChecked; // save if a none-Terminal checked or no 
        private int[][] nonTNum; // save indexs of any nonTerminal type : E= 0; R= 2, 3, 4; ...
        public int[][] NonTNum { get { return nonTNum; } } // readOnly

        /// <summary>
        /// Class Constructor's
        /// </summary>
        /// <param name="nonTerminalP"></param>
        /// <param name="nonTerminalNameP"></param>
        public FirstFinder(string[][] nonTerminalP, string[] nonTerminalNameP)
        {
            nonTerminal = nonTerminalP;
            nonTerminalName = nonTerminalNameP;
            //
            #region Add nonTerminal Name in nonTName List without duplicate -----------------------------

            List<string> lstNonTName = new List<string>();
            foreach (string strNonTerminal in nonTerminalName)
            {
                if (!lstNonTName.Contains(strNonTerminal))
                    lstNonTName.Add(strNonTerminal);
            }
            nonTName = lstNonTName.ToArray();
            nonTNum = new int[NonTName.Length][];
            nonTChecked = new bool[NonTName.Length];
            //
            // Scan nonTName and Search that item's
            for (int s = 0; s < NonTName.Length; s++)
            {
                nonTNum[s] = SearchIndexOf(NonTName[s]); // Example for nonTerminal R: [2][3][4]
            }
            #endregion -------------------------------------------------------------------------
            //
            // create First 2D Array by Length nonTName
            nonTerminalFirst = new string[NonTName.Length][];
            //
            StartFirstFinder(); // Find First in all nonTerminal
        }

        /// <summary>
        /// get Index of any duplicate none-Terminal for string nonTerminal Name's
        /// </summary>
        /// <param name="nonTerminal"></param>
        /// <returns></returns>
        private int[] SearchIndexOf(string nonTerminal)
        {
            List<int> lstIndex = new List<int>();
            for (int index = 0; index < nonTerminalName.Length; index++)
            {
                if (nonTerminalName[index] == nonTerminal)
                    lstIndex.Add(index);
            }
            return lstIndex.ToArray();
        }

        #region First
        /// <summary>
        /// Find All First token in All nonTerminal and save that in nonTerminalFirst[][] 2D Array
        /// </summary>
        private void StartFirstFinder()
        {
            //
            // scan nonTName and . . .
            for (int num = 0; num < NonTName.Length; num++) // read R, E, T, . . . , any none-Terminal
            {
                nonTerminalFirst[num] = First(NonTName[num]).ToArray();
                nonTChecked[num] = true;
            }
        }

        private List<string> First(string none_Terminal_Name)
        {
            // lstFirstBuffer for save any first token for a none-Terminal in all grammar's
            List<string> lstFirstBuffer = new List<string>();
            List<string> lstFirstWithoutDuplicate = new List<string>();

            int index = -1; // index of none-Terminal in Array nonTName            
            //
            // none_Terminal_Name is Really noneTerminal (Example: E, R, T, ...)
            if (searchIndexOfNonTName(none_Terminal_Name, out index))
            {
                // 
                // check old checker
                if (nonTChecked[index]) // Already checked this none-Terminal and have data
                    return nonTerminalFirst[index].ToList<string>();
                else
                {
                    // read grammar:2, 3, 4, ... , & any grammar for a none-Terminal
                    foreach (int i_index in nonTNum[index]) 
                    {
                        // read one to one of right token (Example: -> + R T;)
                        foreach (string token in nonTerminal[i_index]) 
                        {
                            List<string> checker = First(token);
                            lstFirstBuffer.AddRange(checker);
                            if (checker.Contains("ɛ")) continue;
                            else break;
                        } 
                    }
                    // delete or save epsilon ɛ if don'd duplicate in any grammar First 
                    bool AllHaveEpsilon = false;
                    //
                    // Must Number Of Grammar Equal by number of Epsilon ɛ
                    int NumberOfEpsilon = nonTNum[index].Length;
                    //
                    // count number of epsilon in lstFirstBuffer
                    foreach (string epsilon in lstFirstBuffer)
                    {
                        if (epsilon == "ɛ")
                            NumberOfEpsilon--;
                    }
                    AllHaveEpsilon = (NumberOfEpsilon >= 0) ? true : false;
                    //
                    // delete All duplicate First ========================================================================
                    lstFirstWithoutDuplicate.Clear();
                    foreach (string readFirst in lstFirstBuffer)
                    {
                        if (!lstFirstWithoutDuplicate.Contains(readFirst)) // check duplicate token
                            lstFirstWithoutDuplicate.Add(readFirst);
                    }
                    if (!AllHaveEpsilon)
                        try // delete Epsilon if it not duplicate in all grammar
                        {
                            lstFirstWithoutDuplicate.Remove("ɛ");
                        }
                        catch { }
                    // ===================================================================================================

                    return lstFirstWithoutDuplicate;
                }

            }
            else // none_Terminal_Name is not noneTerminal and it is a Terminal (Example: + , a , a2 , ...)
            {
                lstFirstWithoutDuplicate.Add(none_Terminal_Name);
                return lstFirstWithoutDuplicate;
            }
        }


        private bool searchIndexOfNonTName(string token, out int index)
        {
            for (index = 0; index < NonTName.Length; index++)
                if (NonTName[index] == token)
                    return true;
            index = -1; // not found
            return false;
        }

        #endregion
    }
}
