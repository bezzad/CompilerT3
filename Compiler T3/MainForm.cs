using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace Compiler_T3
{
    public partial class MainForm : Form
    {
        #region Graphics Code
        public MainForm()
        {
            Thread th = new Thread(new ThreadStart(DoSplash));
            th.Start();
            Thread.Sleep(3000);
            th.Abort();
            Thread.Sleep(1000);
            InitializeComponent();
        }

        private void DoSplash()
        {
            Splash sp = new Splash();
            sp.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPathe.Text = saveFileDialog1.FileName;
                List<string> lineS = new List<string>();
                for (int line = 0; line < dgvBody.RowCount - 1; line++)
                    lineS.Add(dgvBody[1, line].Value.ToString());
                try
                { System.IO.File.WriteAllLines(txtPathe.Text, lineS.ToArray()); }
                catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPathe.Text = openFileDialog1.FileName;
                try
                {
                    // rtxtBody.Lines = System.IO.File.ReadAllLines(txtPathe.Text);
                    int LineCounter = 1;
                    dgvBody.Rows.Clear();
                    foreach (string strLine in System.IO.File.ReadAllLines(txtPathe.Text))
                    {
                        string[] OneRow = new string[2];
                        OneRow[0] = LineCounter.ToString();
                        OneRow[1] = strLine;
                        dgvBody.Rows.Add(OneRow);
                    }
                    CheckRtxt();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
            }
        }

        private void CheckRtxt()
        {
            // clear by trust
            lblTrustGrammar.ForeColor = Color.Green;
            lblTrustGrammar.Text = "True";
            picBtnStart.Enabled = true;
            //
            for (int l = 0; l < dgvBody.RowCount - 1; l++)
            {
                try
                {
                    if (!dgvBody[1, l].Value.ToString().ValidateGrammar())
                    {
                        lblTrustGrammar.ForeColor = Color.Red;
                        lblTrustGrammar.Text = "False Grammar in Line " + (l + 1).ToString();
                        dgvBody[1, l].Selected = true;
                        picBtnStart.Enabled = false;
                        break;
                    }
                }
                catch
                {
                    lblTrustGrammar.ForeColor = Color.Red;
                    lblTrustGrammar.Text = "False Grammar in Line " + (l + 1).ToString();
                    dgvBody[1, l].Selected = true;
                    picBtnStart.Enabled = false;
                    break;
                }
            }
        }

        private void picBtnStart_MouseEnter(object sender, EventArgs e)
        {
            this.picBtnStart.Image = global::Compiler_T3.Properties.Resources.Start_Parser_MouseOver;
        }

        private void picBtnStart_MouseLeave(object sender, EventArgs e)
        {
            this.picBtnStart.Image = global::Compiler_T3.Properties.Resources.Start_Parser_Normal;
        }

        private void picBtnStart_MouseDown(object sender, MouseEventArgs e)
        {
            this.picBtnStart.Image = global::Compiler_T3.Properties.Resources.Start_Parser_MouseDown;
        }

        private void picBtnStart_MouseUp(object sender, MouseEventArgs e)
        {
            this.picBtnStart.Image = global::Compiler_T3.Properties.Resources.Start_Parser_MouseOver;
        }

        private void picBtnStart_EnabledChanged(object sender, EventArgs e)
        {
            this.picBtnStart.Image = (picBtnStart.Enabled) ?
                global::Compiler_T3.Properties.Resources.Start_Parser_Normal :
                global::Compiler_T3.Properties.Resources.Start_Parser_Disable;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread th = new Thread(new ThreadStart(DoSplash));
            th.Start();
            Thread.Sleep(3000);
            th.Abort();
            Thread.Sleep(1000);
            // About run
            About formAbout = new About();
            formAbout.ShowDialog();
            this.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("Help.pdf"); }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void dgvBody_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int orderCounter = 0; orderCounter < dgvBody.RowCount; orderCounter++)
                dgvBody.Rows[orderCounter].Cells[0].Value = orderCounter + 1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dgvBody.Rows[0].Cells[0].Value = 1;
        }

        private void dgvBody_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int orderCounter = 0; orderCounter < dgvBody.RowCount; orderCounter++)
                dgvBody.Rows[orderCounter].Cells[0].Value = orderCounter + 1;

            CheckRtxt();
        }

        Point lastActiveCell;
        private void dgvBody_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CheckRtxt();
            lastActiveCell = new Point(e.ColumnIndex, e.RowIndex);
            picEpsilon.Enabled = false;
        }

        private void dgvBody_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            picEpsilon.Enabled = true;
            lastActiveCell = new Point(e.ColumnIndex, e.RowIndex);
        }

        private void picEpsilon_Click(object sender, EventArgs e)
        {
            if (lastActiveCell.X != 1) return;
            this.ActiveControl.Text += "ɛ";
        }

        private void picEpsilon_MouseDown(object sender, MouseEventArgs e)
        {
            this.picEpsilon.Image = global::Compiler_T3.Properties.Resources.Epsilon_MouseDown;
        }

        private void picEpsilon_MouseUp(object sender, MouseEventArgs e)
        {
            this.picEpsilon.Image = global::Compiler_T3.Properties.Resources.Epsilon_MouseOver;
        }

        private void picEpsilon_MouseLeave(object sender, EventArgs e)
        {
            this.picEpsilon.Image = global::Compiler_T3.Properties.Resources.Epsilon_Normal;
        }

        private void picEpsilon_MouseEnter(object sender, EventArgs e)
        {
            this.picEpsilon.Image = global::Compiler_T3.Properties.Resources.Epsilon_MouseOver;
        }

        private void picEpsilon_EnabledChanged(object sender, EventArgs e)
        {
            this.picEpsilon.Image = (picEpsilon.Enabled) ?
                global::Compiler_T3.Properties.Resources.Epsilon_Normal :
                global::Compiler_T3.Properties.Resources.Epsilon_Disable;
        }
        #endregion

        #region Analysis Code

        private void picBtnStart_Click(object sender, EventArgs e)
        {
            if (dgvBody.RowCount <= 1)
            {
                MessageBox.Show("You have not entered any grammar!", "Error TextBox Empty"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> strBody = new List<string>();
            for (int l = 0; l < dgvBody.RowCount - 1; l++)
                strBody.Add(dgvBody[1, l].Value.ToString());
            Exponder(strBody.ToArray()); // Read and Analys Text File
            FirstFinder SolveFirst = new FirstFinder(nonTerminal, nonTerminalName);
            //
            FollowFinder SolveFollow = new FollowFinder(nonTerminal,
                nonTerminalName, SolveFirst.NonTerminalFirst, SolveFirst.NonTName);
            //
            GrammarAnalysis AnalysisTable = new GrammarAnalysis(nonTerminal,
                                        nonTerminalName, SolveFirst.NonTName,
                                        SolveFirst.NonTerminalFirst,
                                        SolveFollow.NonTerminalFollow,
                                        SolveFirst.NonTNum);
            //
            printFF(SolveFirst.NonTName, SolveFirst.NonTerminalFirst,
                SolveFollow.NonTerminalFollow, AnalysisTable.G_Analysis_Table,
                AnalysisTable.TerminalName);
        }

        private string[][] nonTerminal; // save right data of nonTerminal's
        private string[] nonTerminalName; // save nonTerminal's Name by FORMULA order


        /// <summary>
        /// nonTerminal 2D Array's Constructor 
        /// </summary>
        /// <param name="p"></param>
        private void Exponder(string[] grammarData)
        {
            // create Array Lenght
            nonTerminal = new string[grammarData.Length][];
            nonTerminalName = new string[grammarData.Length];
            List<string> lstBuffer = new List<string>();
            //
            // Convert String Array for One to One String 
            for (int Line = 0; Line < grammarData.Length; Line++)
            {
                // Convert a string (Line) to characters Array
                char[] chr_readLine = grammarData[Line].ToCharArray();
                //
                // create a locate for save any token or Terminal or nonTerminal
                string Buffer = string.Empty;
                lstBuffer.Clear();
                // Convert Char Array for One to One Char 
                foreach (char readLineChar in chr_readLine)
                {
                    if (readLineChar == ';') // end of grammar in this line
                    {
                        if (Buffer != "") // save old token 
                        {
                            lstBuffer.Add(Buffer);
                            Buffer = "";
                        }
                        break;
                    }
                    else if (char.IsWhiteSpace(readLineChar))
                    {
                        if (Buffer != "") // save old token 
                        {
                            lstBuffer.Add(Buffer);
                            Buffer = "";
                            continue;
                        }
                        continue;
                    }
                    else Buffer += readLineChar.ToString();
                }
                // read List data and save it
                nonTerminalName[Line] = lstBuffer[0]; // save nonTerminal Name's
                //
                // [0]=nonTerminal , [1]="->" , [2] ... is trminal or nonTerminal
                nonTerminal[Line] = new string[lstBuffer.Count - 2];

                for (int i = 0; i < nonTerminal[Line].Length; i++)
                {
                    nonTerminal[Line][i] = (string)lstBuffer[i + 2];
                }
            }
        }

        #endregion

        #region Print All Data Source
        struct NameFirstFollow
        {
            public string non_Terminal_Name;
            public string First;
            public string Follow;
        };
        /// <summary>
        /// show all processing data in data grid view
        /// </summary>
        /// <param name="nonTName"></param>
        /// <param name="nonTerminalFirst"></param>
        /// <param name="nonTerminalFollow"></param>
        /// <param name="g_Analysis_Table"></param>
        private void printFF(string[] nonTName,
                             string[][] nonTerminalFirst,
                             string[][] nonTerminalFollow,
                             string[][] g_Analysis_Table,
                             string[] TerminalName)
        {
            NameFirstFollow[] NFF = new NameFirstFollow[nonTName.Length];
            // 
            // Fill NFF Data ------------------------------------------------------------------------------
            for (int line = 0; line < nonTName.Length; line++)
            {
                NFF[line].non_Terminal_Name = nonTName[line];
                NFF[line].First = Array2String(nonTerminalFirst[line]);
                NFF[line].Follow = Array2String(nonTerminalFollow[line]);
            }
            // --------------------------------------------------------------------------------------------
            // Fill DataGridView dgvFF
            //
            dgvFF.Columns.Clear();
            var sacaner = NFF.Select(item1 => new { non_Terminal_Name = item1.non_Terminal_Name, First = item1.First, Follow = item1.Follow });
            dgvFF.DataSource = sacaner.ToList();
            //
            // Fill DataGridView dgvM
            //
            dgvM.Columns.Clear();
            // 
            // non_TerminalName
            // 
            this.non_TerminalName = new DataGridViewTextBoxColumn();
            this.non_TerminalName.Frozen = true;
            this.non_TerminalName.HeaderText = "non-Terminal Name";
            this.non_TerminalName.Name = "non_TerminalName";
            this.non_TerminalName.ReadOnly = true;
            this.non_TerminalName.Width = 164;
            this.dgvM.Columns.Add(non_TerminalName);
            //
            // Add other columns
            foreach (string terminal in TerminalName)
                dgvM.Columns.Add(terminal, terminal);
            //
            // Add Any Row Data (this data have non-Terminal Name)
            for (int row = 0; row < nonTName.Length; row++)
                dgvM.Rows.Add(g_Analysis_Table[row]);
        }

        /// <summary>
        /// Convert String Array to a String and like a liner string { str0, str1, ... }
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        private string Array2String(string[] strArray)
        {
            string buffer = "";
            for (int counter = 0; counter < strArray.Length; counter++)
                buffer += (counter != strArray.Length - 1) ? strArray[counter] + "  ,   " : strArray[counter];
            return buffer;
        }

        #endregion

    }
    public static class MyExtensions
    {
        public static bool ValidateGrammar(this string Grammar)
        {
            Regex exp = new Regex(@"^([A-Z][0-9a-z]*[\<' '>]+[\<'->'>][\<' '>]([\<' '>]+[^\<' '>]+)+[\;][\<' '>]*)$");
            return exp.IsMatch(Grammar);
        }
    }
}