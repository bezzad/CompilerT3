using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler_T3
{
    sealed class FollowFinder
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


        public string[][] NonTerminalFollow { get { return nonTerminalFollow; } } // ReadOnly for other class
        private string[][] nonTerminalFollow; // save Follow Data on any nonTerminal
        private List<string>[] lstFollow; // for save dynamical follow data in runTime
        //
        // for save dynamical other added follow data (calculate in End of Program's)
        private List<string>[] lstAddOtherFollow; 

        private string[][] nonTerminalFirst; // save First Data on any nonTerminal
        private string[] nonTName; // save nonTerminal Name without duplicate : E , R , T , ...

        public FollowFinder(string[][] nonTerminalP, string[] nonTerminalNameP,
                            string[][] NonTerminalFirstP, string[] NonTNameP)
        {
            nonTerminal = nonTerminalP;
            nonTerminalName = nonTerminalNameP;
            nonTerminalFirst = NonTerminalFirstP;
            nonTName = NonTNameP;

            // create Follow 2D Array by Length nonTName -----------------------
            nonTerminalFollow = new string[nonTName.Length][];

            lstFollow = new List<string>[nonTName.Length];
            for (int n = 0; n < nonTName.Length; n++)
                lstFollow[n] = new List<string>();
            
            lstAddOtherFollow = new List<string>[nonTName.Length];
            for (int n = 0; n < nonTName.Length; n++)
                lstAddOtherFollow[n] = new List<string>();

            StartFollowFinder(); // Find Follow in All nonTerminal
        }

        #region Follow

        /// <summary>
        /// Find All Follow token in All nonTerminal and save that in nonTerminalFollow[][] 2D Array
        /// </summary>
        private void StartFollowFinder()
        {
            // add $ following to 1'st grammar noneTerminal's 
            lstFollow[0].Add("$");
            //
            // Read one to one of grammars in right tokens
            for (int gr_index = 0; gr_index < nonTerminal.Length; gr_index++)
            {
                // Read one to one of right tokens
                for (int index = 0; index < nonTerminal[gr_index].Length; index++)
                {
                    // check token's is Terminal or none-Terminal ?
                    if (nonTName.Contains(nonTerminal[gr_index][index])) // token is a noneTerminal (Example: T, R, E, ...)
                    {
                        // copy tokens future's --------------------------------------------
                        List<string> copyOfTokensFuture = new List<string>();
                        for (int counter = index + 1; counter < nonTerminal[gr_index].Length; counter++)
                            copyOfTokensFuture.Add(nonTerminal[gr_index][counter]);
                        // -----------------------------------------------------------------
                        // send tokens future to find firsts
                        List<string> lstFirst = First(copyOfTokensFuture);
                        // check have Epsilon ++++++++++++++++++++++++++++++++++++++++++++++
                        if (lstFirst.Contains("ɛ")) // true = have Epsilon ==> + Follow(self Grammar Token's)
                        {
                            // delete epsilon because Follow for ever don't have Epsilon
                            lstFirst.Remove("ɛ");
                            //
                            // Add Follow data if that isn't duplicate data
                            if (!lstAddOtherFollow[Array.IndexOf(nonTName, nonTerminal[gr_index][index])].Contains(nonTerminalName[gr_index]))
                                lstAddOtherFollow[Array.IndexOf(nonTName, nonTerminal[gr_index][index])].Add(nonTerminalName[gr_index]);
                        }
                        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        // Add data
                        lstFollow[Array.IndexOf(nonTName, nonTerminal[gr_index][index])].AddRange(lstFirst);
                    }
                    else // token is a Terminal (Example: + , / , a , a0 , ...)
                        continue; // becouse not important for follow
                }
            }
            //
            // set Follow adding data and remove that ==========================================================
            //
            // +++++ delete self Follow Addation (Example nonTerminal[R] have: +Follow(E) , + Follow(R)  ++++++
            for (int gr_index = 0; gr_index < nonTName.Length; gr_index++)
            {
                // if (R: +Follow(R)) then remove (+Follow(R))
                if (lstAddOtherFollow[gr_index].Contains(nonTName[gr_index])) 
                    lstAddOtherFollow[gr_index].Remove(nonTName[gr_index]);
            }
            // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //
            int Length = 0; // for match by lstAddOtherFollow[].count
            bool newChecked = false;
            bool[] checkedList = new bool[nonTName.Length];
            do
            {
                newChecked = false;
                for (int line = 0; line < lstAddOtherFollow.Length; line++)
                {
                    // finded a nonTerminal without Follow addational
                    if (lstAddOtherFollow[line].Count == Length && !checkedList[line]) 
                    {
                        // search inside of other follow list for this noneTerminal and fill it. 
                        // because this nonTerminal havan't any other Follow
                        AddThis2OtherFollow(nonTName[line], line);
                        checkedList[line] = true;
                        newChecked = true;
                    }
                }
            } while (newChecked);
            // =================================================================================================
            // remove duplicate data in lstFollow %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            List<string>[] lstFollowWithoutDuplicate = new List<string>[lstFollow.Length];
            // copy list lstFollow without duplicate
            for (int copy = 0; copy < lstFollow.Length; copy++)
            {
                lstFollowWithoutDuplicate[copy] = new List<string>();
                foreach (string read in lstFollow[copy])
                    if (!lstFollowWithoutDuplicate[copy].Contains(read))
                        lstFollowWithoutDuplicate[copy].Add(read);
            }
            // copy to important Array
            for (int copy = 0; copy < lstFollow.Length; copy++)
                nonTerminalFollow[copy] = lstFollowWithoutDuplicate[copy].ToArray();
            // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        }

        /// <summary>
        /// Adding this follow information to other non-terminal non-terminals that have used it.
        /// </summary>
        /// <param name="noneTerminalName"></param>
        /// <param name="noneTerminalIndex"></param>
        private void AddThis2OtherFollow(string noneTerminalName, int noneTerminalIndex)
        {
            for (int gr_index = 0; gr_index < nonTName.Length; gr_index++)
            {
                // search used non-Terminal
                if (lstAddOtherFollow[gr_index].Contains(noneTerminalName))
                {
                    // in first Remove it
                    lstAddOtherFollow[gr_index].Remove(noneTerminalName);
                    //
                    // add that information to this finded non-Terminal
                    lstFollow[gr_index].AddRange(lstFollow[noneTerminalIndex]);
                }
            }
        }

        /// <summary>
        /// get First List of several string with or without Epsilon
        /// </summary>
        /// <param name="tokenS"></param>
        /// <returns></returns>
        private List<string> First(List<string> tokenS)
        {
            List<string> lstFirst = new List<string>();
            List<string> lstFirstWithoutDuplicate = new List<string>();
            bool haveEpsilon = true;

            if (tokenS.Count == 0)
            {
                lstFirst.Add("ɛ");
                return lstFirst;
            }
            else
            {
                foreach (string token in tokenS)
                {
                    if (nonTName.Contains(token)) // token is a nonTerminal
                    {
                        // add first list of nonTerminal token in lstFirst
                        lstFirst.AddRange(nonTerminalFirst[Array.IndexOf(nonTName, token)]);
                        //
                        // if first list of token have Epsilon be continued
                        if (!nonTerminalFirst[Array.IndexOf(nonTName, token)].Contains("ɛ"))
                        {
                            haveEpsilon = false;
                            break;
                        }
                    }
                    else // token is a Terminal
                    {
                        if (token != "ɛ")
                        {
                            lstFirst.Add(token);
                            haveEpsilon = false;
                            break;
                        }
                        else lstFirst.Add(token);
                    }
                }   
                // delete duplicate data! ================================
                foreach (string reader in lstFirst)
                    if (!lstFirstWithoutDuplicate.Contains(reader))
                        lstFirstWithoutDuplicate.Add(reader);
                // =======================================================
                // delete or save Epsilon "ɛ"
                if(!haveEpsilon)
                    try { lstFirstWithoutDuplicate.Remove("ɛ"); }
                    catch { }
            }

            return lstFirstWithoutDuplicate;
        }

        
        #endregion
    }
}
