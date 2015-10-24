using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler_T3
{
    sealed class GrammarAnalysis
    {
        // g_Analysis_Table size is [non-Terminal.Length, Terminal.Length + 1]
        //
        // for Example M Table: (error is false and other are true homes in check_g_Analysis_Table Matrix)
        //
        //  M______________________________________________________________________     _
        //  |                   |           |           |            |     |       |    ˄   n
        //  | non-Terminal Name | Termina 0 | Trminal 1 | Terminal 2 | ... |   $   |    |   o
        //  |___________________|___________|___________|____________|_____|_______|    |   n
        //  |         E         |   error   |   error   |     0      | ... | error |    |   |
        //  |-------------------|-----------|-----------|------------|-----|-------|    |   T
        //  |         R         |     1     |     4     |     2      | ... |   3   |    |   e
        //  |-------------------|-----------|-----------|------------|-----|-------|    |   r
        //  |         T         |     5     |     5     |   error    | ... | error |    |   m
        //  |-------------------|-----------|-----------|------------|-----|-------|    |   i
        //  |         .         |   . . .   |   . . .   |    . . .   | ... | . . . |    |   n
        //  |         .         |   . . .   |   . . .   |    . . .   | ... | . . . |    |   a
        //  |         .         |   . . .   |   . . .   |    . . .   | ... | . . . |    |   l
        //  |___________________|___________|___________|____________|_____|_______|    ˅   .Length
        //                                                                              ¯
        //  |<-------------------------------------------------------------------->|
        //              Terminal.Length + 1 (non-Terminal Name Column's)
        //
        //  Attention: '$' Terminal's is Final member of Terminals
        //

        private string[][] g_Analysis_Table; // for return and get this class Processing
        public string[][] G_Analysis_Table { get { return g_Analysis_Table; } } // ReadOnly

        private string[][] nonTerminal;
        private string[] nonTerminalName;
        private string[] nonTName;
        private string[][] nonTerminalFirst;
        private string[][] nonTerminalFollow;
        private int[][] nonTNum;

        private string[] terminalName;
        public string[] TerminalName { get { return terminalName; } } // ReadOny
        

        /// <summary>
        /// Constructor of GrammarAnalysis Class
        /// </summary>
        /// <param name="nonTerminal"></param>
        /// <param name="nonTerminalName"></param>
        /// <param name="NonTName"></param>
        /// <param name="NonTerminalFirst"></param>
        /// <param name="NonTerminalFollow"></param>
        public GrammarAnalysis(string[][] nonTerminalP, string[] nonTerminalNameP,
                               string[] NonTNameP, string[][] NonTerminalFirstP,
                               string[][] NonTerminalFollowP, int[][] NonTNum)
        {
            nonTerminal = nonTerminalP;
            nonTerminalName = nonTerminalNameP;
            nonTName = NonTNameP;
            nonTNum = NonTNum;
            nonTerminalFirst = NonTerminalFirstP;
            nonTerminalFollow = NonTerminalFollowP;
            //
            // search any Terminal Name
            //
            List<string> lstTerminal = new List<string>();
            foreach (string[] strGrammer in nonTerminal)
                foreach (string token in strGrammer)
                    if (!nonTName.Contains(token)) // is a terminal
                        if (!lstTerminal.Contains(token)) // isn't duplicate
                            lstTerminal.Add(token);
            //
            // Add '$' to Terminal List
            lstTerminal.Add("$");
            //
            // Remove 'ɛ' of Terminal List
            try { lstTerminal.Remove("ɛ"); }
            catch { }
            //
            terminalName = new string[lstTerminal.Count];
            terminalName = lstTerminal.ToArray();
            //
            // create G_Analysis_Table 2D Array's and fill it by "error"
            g_Analysis_Table = new string[nonTName.Length][];
            for (int num = 0; num < nonTName.Length; num++)
            {
                // Each row of the array is equal to one plus the number of terminals.
                g_Analysis_Table[num] = new string[terminalName.Length + 1]; 
                //
                // Content of the first house each matrix array of 
                // rows equal with non-terminal is equal to the row. (Example: [E][][][][]...)
                g_Analysis_Table[num][0] = nonTName[num];
                // 
                // And content word error rest homes (Example: [E][error][error][error]...)
                for (int rest = 1; rest <= terminalName.Length; rest++)
                    g_Analysis_Table[num][rest] = "error";
            }
            // run Analysis Solver Funcation
            Analysis();
        }

        /// <summary>
        /// Fill g_Analysis_Table Matrix by other data
        /// </summary>
        private void Analysis()
        {
            // Read every single grammar of Grammar Array's. (Example: E -> T R )
            for (int grammarNumber = 0; grammarNumber < nonTerminalName.Length; grammarNumber++) 
            {
                // Place storage terminals extracted from the grammar reads for First Funcion's
                List<string> FirstTerminalS = new List<string>(); 
                //
                // A -> a :if b member's as First(a) then M[A, b] = this(A) grammar number's
                //
                FirstTerminalS = First(nonTerminal[grammarNumber]);
                //
                // Read every single terminal of Finded TerminalS. (Example: + , - , id , ...)
                foreach (string fiTerminal in FirstTerminalS)
                {
                    if (fiTerminal != "ɛ") // ɛ isn't a Terminal
                    {
                        // Search All TerminalS in the Terminal List's and find Index of terminal in Matrix
                        int indexOfTerminal = Array.IndexOf(terminalName, fiTerminal) + 1;
                        //
                        // Search this nonTermina Grammar Index in rows
                        int indexOfNonTerminal = Array.IndexOf(nonTName, nonTerminalName[grammarNumber]);
                        //
                        // M[A, b] = this grammar number's
                        g_Analysis_Table[indexOfNonTerminal][indexOfTerminal] =
                                (g_Analysis_Table[indexOfNonTerminal][indexOfTerminal] == "error") ?
                                (grammarNumber + 1).ToString() :
                                g_Analysis_Table[indexOfNonTerminal][indexOfTerminal] +
                                " ,  " + (grammarNumber + 1).ToString();
                    }
                    else
                    {
                        // Place storage terminals extracted from the grammar reads for Follow Funcion's
                        List<string> FollowTerminalS = new List<string>();
                        //
                        // Search this nonTermina Grammar Index in rows
                        int indexOfNonTerminal = Array.IndexOf(nonTName, nonTerminalName[grammarNumber]);
                        //
                        // copy of Follow(this nonTerminal)
                        FollowTerminalS = nonTerminalFollow[indexOfNonTerminal].ToList<string>();
                        //
                        // add that follow to Matrix
                        //
                        // Read every single terminal of Finded TerminalS in Follow list's.
                        foreach (string foTerminal in FollowTerminalS)
                        {
                            // get this terminal index's of Matrix
                            int indexOfTerminal = Array.IndexOf(terminalName, foTerminal) + 1;
                            //
                            // M[A, Follow(A)] = this grammar number's
                            g_Analysis_Table[indexOfNonTerminal][indexOfTerminal] =
                                (g_Analysis_Table[indexOfNonTerminal][indexOfTerminal] == "error") ?
                                (grammarNumber + 1).ToString() :
                                g_Analysis_Table[indexOfNonTerminal][indexOfTerminal] +
                                " ,  " + (grammarNumber + 1).ToString();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// get First List of several string with or without Epsilon
        /// </summary>
        /// <param name="tokenS"></param>
        /// <returns></returns>
        private List<string> First(string[] tokenS)
        {
            List<string> lstFirst = new List<string>();
            List<string> lstFirstWithoutDuplicate = new List<string>();
            bool haveEpsilon = true;

            if (tokenS.Length == 0)
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
                if (!haveEpsilon)
                    try { lstFirstWithoutDuplicate.Remove("ɛ"); }
                    catch { }
            }

            return lstFirstWithoutDuplicate;
        }

    }
}
