namespace Compiler_T3
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvFF = new System.Windows.Forms.DataGridView();
            this.dgvM = new System.Windows.Forms.DataGridView();
            this.txtPathe = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAbout = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnHelp = new System.Windows.Forms.Button();
            this.picEpsilon = new System.Windows.Forms.PictureBox();
            this.picBtnStart = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTrustGrammar = new System.Windows.Forms.Label();
            this.dgvBody = new System.Windows.Forms.DataGridView();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grammar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbGrammar = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEpsilon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBody)).BeginInit();
            this.grbGrammar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(12, 437);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.toolTip1.SetToolTip(this.btnSave, "Save Grammar Data in your Pathe\'s");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(93, 437);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "&Load";
            this.toolTip1.SetToolTip(this.btnLoad, "Load Grammar data as your Pathe\'s");
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvFF
            // 
            this.dgvFF.AllowUserToDeleteRows = false;
            this.dgvFF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFF.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvFF.BackgroundColor = System.Drawing.Color.White;
            this.dgvFF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFF.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFF.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFF.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFF.Location = new System.Drawing.Point(291, 27);
            this.dgvFF.Name = "dgvFF";
            this.dgvFF.ReadOnly = true;
            this.dgvFF.RowHeadersWidth = 30;
            this.dgvFF.Size = new System.Drawing.Size(418, 174);
            this.dgvFF.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dgvFF, "First and Follow Data Table");
            // 
            // dgvM
            // 
            this.dgvM.AllowUserToAddRows = false;
            this.dgvM.AllowUserToDeleteRows = false;
            this.dgvM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvM.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvM.BackgroundColor = System.Drawing.Color.White;
            this.dgvM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvM.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvM.ColumnHeadersHeight = 30;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvM.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvM.Location = new System.Drawing.Point(291, 228);
            this.dgvM.Name = "dgvM";
            this.dgvM.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvM.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvM.RowHeadersWidth = 30;
            this.dgvM.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvM.Size = new System.Drawing.Size(418, 171);
            this.dgvM.TabIndex = 3;
            this.toolTip1.SetToolTip(this.dgvM, "M Table \r\nParsing Table");
            // 
            // txtPathe
            // 
            this.txtPathe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathe.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPathe.Location = new System.Drawing.Point(174, 440);
            this.txtPathe.Name = "txtPathe";
            this.txtPathe.ReadOnly = true;
            this.txtPathe.Size = new System.Drawing.Size(400, 20);
            this.txtPathe.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtPathe, "Pathe of Grammer Data");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Grammar_Data.txt";
            this.saveFileDialog1.Filter = "Text files|*.txt";
            this.saveFileDialog1.Title = "Give a Pathe for save Grammar Data";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text files|*.txt|All files|*.*";
            this.openFileDialog1.Title = "Select Grammar Data Text file\'s";
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Location = new System.Drawing.Point(418, 411);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 1;
            this.btnAbout.Text = "&About";
            this.toolTip1.SetToolTip(this.btnAbout, "About Compiler T3");
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Location = new System.Drawing.Point(499, 411);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "&Help";
            this.toolTip1.SetToolTip(this.btnHelp, "Compiler T3 Workmanship\'s");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // picEpsilon
            // 
            this.picEpsilon.BackColor = System.Drawing.Color.Transparent;
            this.picEpsilon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEpsilon.Enabled = false;
            this.picEpsilon.Image = global::Compiler_T3.Properties.Resources.Epsilon_Disable;
            this.picEpsilon.Location = new System.Drawing.Point(212, 10);
            this.picEpsilon.Name = "picEpsilon";
            this.picEpsilon.Size = new System.Drawing.Size(55, 44);
            this.picEpsilon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEpsilon.TabIndex = 10;
            this.picEpsilon.TabStop = false;
            this.toolTip1.SetToolTip(this.picEpsilon, "Add Epsilon ɛ to Grammar Text\'s");
            this.picEpsilon.MouseLeave += new System.EventHandler(this.picEpsilon_MouseLeave);
            this.picEpsilon.Click += new System.EventHandler(this.picEpsilon_Click);
            this.picEpsilon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picEpsilon_MouseDown);
            this.picEpsilon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picEpsilon_MouseUp);
            this.picEpsilon.EnabledChanged += new System.EventHandler(this.picEpsilon_EnabledChanged);
            this.picEpsilon.MouseEnter += new System.EventHandler(this.picEpsilon_MouseEnter);
            // 
            // picBtnStart
            // 
            this.picBtnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picBtnStart.BackColor = System.Drawing.Color.Transparent;
            this.picBtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBtnStart.Enabled = false;
            this.picBtnStart.Image = global::Compiler_T3.Properties.Resources.Start_Parser_Disable;
            this.picBtnStart.Location = new System.Drawing.Point(593, 403);
            this.picBtnStart.Name = "picBtnStart";
            this.picBtnStart.Size = new System.Drawing.Size(128, 69);
            this.picBtnStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBtnStart.TabIndex = 8;
            this.picBtnStart.TabStop = false;
            this.toolTip1.SetToolTip(this.picBtnStart, "Start Parsing Grammar Data");
            this.picBtnStart.MouseLeave += new System.EventHandler(this.picBtnStart_MouseLeave);
            this.picBtnStart.Click += new System.EventHandler(this.picBtnStart_Click);
            this.picBtnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBtnStart_MouseDown);
            this.picBtnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBtnStart_MouseUp);
            this.picBtnStart.EnabledChanged += new System.EventHandler(this.picBtnStart_EnabledChanged);
            this.picBtnStart.MouseEnter += new System.EventHandler(this.picBtnStart_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "First && Follow Table:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parsing Table:";
            // 
            // lblTrustGrammar
            // 
            this.lblTrustGrammar.AutoSize = true;
            this.lblTrustGrammar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTrustGrammar.ForeColor = System.Drawing.Color.Green;
            this.lblTrustGrammar.Location = new System.Drawing.Point(6, 25);
            this.lblTrustGrammar.Name = "lblTrustGrammar";
            this.lblTrustGrammar.Size = new System.Drawing.Size(38, 18);
            this.lblTrustGrammar.TabIndex = 6;
            this.lblTrustGrammar.Text = "True";
            // 
            // dgvBody
            // 
            this.dgvBody.AllowUserToOrderColumns = true;
            this.dgvBody.AllowUserToResizeColumns = false;
            this.dgvBody.AllowUserToResizeRows = false;
            this.dgvBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvBody.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBody.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBody.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBody.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBody.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order,
            this.Grammar});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBody.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBody.GridColor = System.Drawing.Color.OrangeRed;
            this.dgvBody.Location = new System.Drawing.Point(6, 53);
            this.dgvBody.Name = "dgvBody";
            this.dgvBody.Size = new System.Drawing.Size(261, 370);
            this.dgvBody.TabIndex = 9;
            this.dgvBody.TabStop = false;
            this.dgvBody.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBody_CellBeginEdit);
            this.dgvBody.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvBody_RowsAdded);
            this.dgvBody.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBody_CellEndEdit);
            this.dgvBody.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvBody_RowsRemoved);
            // 
            // Order
            // 
            this.Order.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Order.FillWeight = 20F;
            this.Order.Frozen = true;
            this.Order.HeaderText = "Number";
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            this.Order.ToolTipText = "Number of Grammar";
            this.Order.Width = 81;
            // 
            // Grammar
            // 
            this.Grammar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Grammar.HeaderText = "Grammar";
            this.Grammar.Name = "Grammar";
            // 
            // grbGrammar
            // 
            this.grbGrammar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grbGrammar.Controls.Add(this.dgvBody);
            this.grbGrammar.Controls.Add(this.picEpsilon);
            this.grbGrammar.Controls.Add(this.lblTrustGrammar);
            this.grbGrammar.Location = new System.Drawing.Point(12, 2);
            this.grbGrammar.Name = "grbGrammar";
            this.grbGrammar.Size = new System.Drawing.Size(273, 429);
            this.grbGrammar.TabIndex = 11;
            this.grbGrammar.TabStop = false;
            this.grbGrammar.Text = "Grammar Data";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 472);
            this.Controls.Add(this.grbGrammar);
            this.Controls.Add(this.picBtnStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPathe);
            this.Controls.Add(this.dgvM);
            this.Controls.Add(this.dgvFF);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(610, 380);
            this.Name = "MainForm";
            this.Text = "Compiler T3";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEpsilon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBody)).EndInit();
            this.grbGrammar.ResumeLayout(false);
            this.grbGrammar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvFF;
        private System.Windows.Forms.DataGridView dgvM;
        private System.Windows.Forms.TextBox txtPathe;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTrustGrammar;
        private System.Windows.Forms.PictureBox picBtnStart;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn non_TerminalName;
        private System.Windows.Forms.DataGridView dgvBody;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grammar;
        private System.Windows.Forms.PictureBox picEpsilon;
        private System.Windows.Forms.GroupBox grbGrammar;
    }
}

