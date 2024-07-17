namespace LoginForm
{
    partial class ParentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            this.PostdataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPostMax = new System.Windows.Forms.Label();
            this.lblPreAverage = new System.Windows.Forms.Label();
            this.lblPreMax = new System.Windows.Forms.Label();
            this.lblPreMin = new System.Windows.Forms.Label();
            this.lblPreOverallStatus = new System.Windows.Forms.Label();
            this.lblPreUpperSpec = new System.Windows.Forms.Label();
            this.lblPreLowerSpec = new System.Windows.Forms.Label();
            this.lblPostMin = new System.Windows.Forms.Label();
            this.PreAverage = new System.Windows.Forms.Label();
            this.PreMin = new System.Windows.Forms.Label();
            this.PreOverallStatus = new System.Windows.Forms.Label();
            this.lblPostAverage = new System.Windows.Forms.Label();
            this.PreMax = new System.Windows.Forms.Label();
            this.txtPostValue = new System.Windows.Forms.TextBox();
            this.lblPostOverallStatus = new System.Windows.Forms.Label();
            this.btnSaphire = new System.Windows.Forms.Button();
            this.lblDoneBy = new System.Windows.Forms.Label();
            this.lblPostUpperSpec = new System.Windows.Forms.Label();
            this.lblPostLowerSpec = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblCalDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnPostComplete = new System.Windows.Forms.Button();
            this.txtPreValue = new System.Windows.Forms.TextBox();
            this.btnPostRead = new System.Windows.Forms.Button();
            this.PredataGridView = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreUpperSpec = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPreReset = new System.Windows.Forms.Button();
            this.txtEqID = new System.Windows.Forms.TextBox();
            this.comboBoxTorqCalID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FormID = new System.Windows.Forms.Label();
            this.lblFormID = new System.Windows.Forms.Label();
            this.EQID = new System.Windows.Forms.Label();
            this.DoneBy = new System.Windows.Forms.Label();
            this.btnSaveTorqueSetting = new System.Windows.Forms.Button();
            this.TorqueCalibratorID = new System.Windows.Forms.Label();
            this.TorqueSetting = new System.Windows.Forms.Label();
            this.StartCalDate = new System.Windows.Forms.Label();
            this.txtTorqSetting = new System.Windows.Forms.TextBox();
            this.Location = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PreLowerSpec = new System.Windows.Forms.Label();
            this.btnPreComplete = new System.Windows.Forms.Button();
            this.btnPreRead = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PostdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PredataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PostdataGridView
            // 
            this.PostdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PostdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PostdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.PostdataGridView.Location = new System.Drawing.Point(23, 142);
            this.PostdataGridView.Name = "PostdataGridView";
            this.PostdataGridView.ReadOnly = true;
            this.PostdataGridView.RowHeadersWidth = 51;
            this.PostdataGridView.Size = new System.Drawing.Size(700, 150);
            this.PostdataGridView.TabIndex = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Reading Index";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Reading Value (ibf.in)";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Deviation (%)";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Status";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // lblPostMax
            // 
            this.lblPostMax.AutoSize = true;
            this.lblPostMax.BackColor = System.Drawing.SystemColors.Control;
            this.lblPostMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostMax.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPostMax.Location = new System.Drawing.Point(316, 102);
            this.lblPostMax.Name = "lblPostMax";
            this.lblPostMax.Size = new System.Drawing.Size(29, 15);
            this.lblPostMax.TabIndex = 28;
            this.lblPostMax.Text = "Max";
            // 
            // lblPreAverage
            // 
            this.lblPreAverage.AutoSize = true;
            this.lblPreAverage.BackColor = System.Drawing.SystemColors.Control;
            this.lblPreAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreAverage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPreAverage.Location = new System.Drawing.Point(525, 102);
            this.lblPreAverage.Name = "lblPreAverage";
            this.lblPreAverage.Size = new System.Drawing.Size(49, 15);
            this.lblPreAverage.TabIndex = 29;
            this.lblPreAverage.Text = "Average";
            // 
            // lblPreMax
            // 
            this.lblPreMax.AutoSize = true;
            this.lblPreMax.BackColor = System.Drawing.SystemColors.Control;
            this.lblPreMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreMax.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPreMax.Location = new System.Drawing.Point(316, 102);
            this.lblPreMax.Name = "lblPreMax";
            this.lblPreMax.Size = new System.Drawing.Size(29, 15);
            this.lblPreMax.TabIndex = 28;
            this.lblPreMax.Text = "Max";
            // 
            // lblPreMin
            // 
            this.lblPreMin.AutoSize = true;
            this.lblPreMin.BackColor = System.Drawing.SystemColors.Control;
            this.lblPreMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreMin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPreMin.Location = new System.Drawing.Point(110, 102);
            this.lblPreMin.Name = "lblPreMin";
            this.lblPreMin.Size = new System.Drawing.Size(26, 15);
            this.lblPreMin.TabIndex = 27;
            this.lblPreMin.Text = "Min";
            // 
            // lblPreOverallStatus
            // 
            this.lblPreOverallStatus.AutoSize = true;
            this.lblPreOverallStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblPreOverallStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreOverallStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPreOverallStatus.Location = new System.Drawing.Point(525, 78);
            this.lblPreOverallStatus.Name = "lblPreOverallStatus";
            this.lblPreOverallStatus.Size = new System.Drawing.Size(75, 15);
            this.lblPreOverallStatus.TabIndex = 26;
            this.lblPreOverallStatus.Text = "Overall Status";
            // 
            // lblPreUpperSpec
            // 
            this.lblPreUpperSpec.AutoSize = true;
            this.lblPreUpperSpec.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPreUpperSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreUpperSpec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPreUpperSpec.Location = new System.Drawing.Point(316, 79);
            this.lblPreUpperSpec.Name = "lblPreUpperSpec";
            this.lblPreUpperSpec.Size = new System.Drawing.Size(66, 15);
            this.lblPreUpperSpec.TabIndex = 25;
            this.lblPreUpperSpec.Text = "Upper Spec";
            // 
            // lblPreLowerSpec
            // 
            this.lblPreLowerSpec.AutoSize = true;
            this.lblPreLowerSpec.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPreLowerSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreLowerSpec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPreLowerSpec.Location = new System.Drawing.Point(110, 79);
            this.lblPreLowerSpec.Name = "lblPreLowerSpec";
            this.lblPreLowerSpec.Size = new System.Drawing.Size(66, 15);
            this.lblPreLowerSpec.TabIndex = 19;
            this.lblPreLowerSpec.Text = "Lower Spec";
            // 
            // lblPostMin
            // 
            this.lblPostMin.AutoSize = true;
            this.lblPostMin.BackColor = System.Drawing.SystemColors.Control;
            this.lblPostMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostMin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPostMin.Location = new System.Drawing.Point(110, 102);
            this.lblPostMin.Name = "lblPostMin";
            this.lblPostMin.Size = new System.Drawing.Size(26, 15);
            this.lblPostMin.TabIndex = 27;
            this.lblPostMin.Text = "Min";
            // 
            // PreAverage
            // 
            this.PreAverage.AutoSize = true;
            this.PreAverage.Location = new System.Drawing.Point(446, 102);
            this.PreAverage.Name = "PreAverage";
            this.PreAverage.Size = new System.Drawing.Size(47, 13);
            this.PreAverage.TabIndex = 24;
            this.PreAverage.Text = "Average";
            // 
            // PreMin
            // 
            this.PreMin.AutoSize = true;
            this.PreMin.Location = new System.Drawing.Point(40, 102);
            this.PreMin.Name = "PreMin";
            this.PreMin.Size = new System.Drawing.Size(24, 13);
            this.PreMin.TabIndex = 22;
            this.PreMin.Text = "Min";
            // 
            // PreOverallStatus
            // 
            this.PreOverallStatus.AutoSize = true;
            this.PreOverallStatus.Location = new System.Drawing.Point(446, 79);
            this.PreOverallStatus.Name = "PreOverallStatus";
            this.PreOverallStatus.Size = new System.Drawing.Size(73, 13);
            this.PreOverallStatus.TabIndex = 21;
            this.PreOverallStatus.Text = "Overall Status";
            // 
            // lblPostAverage
            // 
            this.lblPostAverage.AutoSize = true;
            this.lblPostAverage.BackColor = System.Drawing.SystemColors.Control;
            this.lblPostAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostAverage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPostAverage.Location = new System.Drawing.Point(525, 102);
            this.lblPostAverage.Name = "lblPostAverage";
            this.lblPostAverage.Size = new System.Drawing.Size(49, 15);
            this.lblPostAverage.TabIndex = 29;
            this.lblPostAverage.Text = "Average";
            // 
            // PreMax
            // 
            this.PreMax.AutoSize = true;
            this.PreMax.Location = new System.Drawing.Point(246, 102);
            this.PreMax.Name = "PreMax";
            this.PreMax.Size = new System.Drawing.Size(27, 13);
            this.PreMax.TabIndex = 23;
            this.PreMax.Text = "Max";
            // 
            // txtPostValue
            // 
            this.txtPostValue.Enabled = false;
            this.txtPostValue.Location = new System.Drawing.Point(43, 39);
            this.txtPostValue.Name = "txtPostValue";
            this.txtPostValue.Size = new System.Drawing.Size(150, 20);
            this.txtPostValue.TabIndex = 19;
            // 
            // lblPostOverallStatus
            // 
            this.lblPostOverallStatus.AutoSize = true;
            this.lblPostOverallStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblPostOverallStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostOverallStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPostOverallStatus.Location = new System.Drawing.Point(525, 78);
            this.lblPostOverallStatus.Name = "lblPostOverallStatus";
            this.lblPostOverallStatus.Size = new System.Drawing.Size(75, 15);
            this.lblPostOverallStatus.TabIndex = 26;
            this.lblPostOverallStatus.Text = "Overall Status";
            // 
            // btnSaphire
            // 
            this.btnSaphire.BackColor = System.Drawing.Color.Red;
            this.btnSaphire.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaphire.Location = new System.Drawing.Point(562, 18);
            this.btnSaphire.Name = "btnSaphire";
            this.btnSaphire.Size = new System.Drawing.Size(126, 28);
            this.btnSaphire.TabIndex = 36;
            this.btnSaphire.Text = "Connect to Sapphire";
            this.btnSaphire.UseVisualStyleBackColor = false;
            this.btnSaphire.Visible = false;
            this.btnSaphire.Click += new System.EventHandler(this.actualSapphireClick);
            // 
            // lblDoneBy
            // 
            this.lblDoneBy.AutoSize = true;
            this.lblDoneBy.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblDoneBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDoneBy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDoneBy.Location = new System.Drawing.Point(590, 84);
            this.lblDoneBy.Name = "lblDoneBy";
            this.lblDoneBy.Size = new System.Drawing.Size(47, 15);
            this.lblDoneBy.TabIndex = 35;
            this.lblDoneBy.Text = "DoneBy";
            // 
            // lblPostUpperSpec
            // 
            this.lblPostUpperSpec.AutoSize = true;
            this.lblPostUpperSpec.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPostUpperSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostUpperSpec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPostUpperSpec.Location = new System.Drawing.Point(316, 79);
            this.lblPostUpperSpec.Name = "lblPostUpperSpec";
            this.lblPostUpperSpec.Size = new System.Drawing.Size(66, 15);
            this.lblPostUpperSpec.TabIndex = 25;
            this.lblPostUpperSpec.Text = "Upper Spec";
            // 
            // lblPostLowerSpec
            // 
            this.lblPostLowerSpec.AutoSize = true;
            this.lblPostLowerSpec.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPostLowerSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostLowerSpec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPostLowerSpec.Location = new System.Drawing.Point(110, 79);
            this.lblPostLowerSpec.Name = "lblPostLowerSpec";
            this.lblPostLowerSpec.Size = new System.Drawing.Size(66, 15);
            this.lblPostLowerSpec.TabIndex = 19;
            this.lblPostLowerSpec.Text = "Lower Spec";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(446, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Average";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(246, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Max";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Min";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(446, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Overall Status";
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.LightCoral;
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(404, 18);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(148, 28);
            this.btnReport.TabIndex = 32;
            this.btnReport.Text = "Generate report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.generateReport);
            // 
            // lblCalDate
            // 
            this.lblCalDate.AutoSize = true;
            this.lblCalDate.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblCalDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCalDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCalDate.Location = new System.Drawing.Point(590, 109);
            this.lblCalDate.Name = "lblCalDate";
            this.lblCalDate.Size = new System.Drawing.Size(47, 15);
            this.lblCalDate.TabIndex = 15;
            this.lblCalDate.Text = "CalDate";
            this.lblCalDate.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(246, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Upper Spec";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Lower Spec";
            // 
            // btnPostComplete
            // 
            this.btnPostComplete.Location = new System.Drawing.Point(449, 19);
            this.btnPostComplete.Name = "btnPostComplete";
            this.btnPostComplete.Size = new System.Drawing.Size(150, 23);
            this.btnPostComplete.TabIndex = 2;
            this.btnPostComplete.Text = "Complete (0/5)";
            this.btnPostComplete.UseVisualStyleBackColor = true;
            this.btnPostComplete.Click += new System.EventHandler(this.btnPostComplete_Click);
            // 
            // txtPreValue
            // 
            this.txtPreValue.Enabled = false;
            this.txtPreValue.Location = new System.Drawing.Point(43, 39);
            this.txtPreValue.Name = "txtPreValue";
            this.txtPreValue.Size = new System.Drawing.Size(150, 20);
            this.txtPreValue.TabIndex = 19;
            // 
            // btnPostRead
            // 
            this.btnPostRead.Location = new System.Drawing.Point(43, 19);
            this.btnPostRead.Name = "btnPostRead";
            this.btnPostRead.Size = new System.Drawing.Size(150, 23);
            this.btnPostRead.TabIndex = 0;
            this.btnPostRead.Text = "Read";
            this.btnPostRead.UseVisualStyleBackColor = true;
            this.btnPostRead.Click += new System.EventHandler(this.btnPostRead_Click);
            // 
            // PredataGridView
            // 
            this.PredataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PredataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PredataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Value,
            this.Deviation,
            this.Status});
            this.PredataGridView.Location = new System.Drawing.Point(23, 144);
            this.PredataGridView.Name = "PredataGridView";
            this.PredataGridView.ReadOnly = true;
            this.PredataGridView.RowHeadersWidth = 51;
            this.PredataGridView.Size = new System.Drawing.Size(700, 150);
            this.PredataGridView.TabIndex = 30;
            // 
            // Index
            // 
            this.Index.HeaderText = "Reading Index";
            this.Index.MinimumWidth = 6;
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Reading Value (ibf.in)";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Deviation
            // 
            this.Deviation.HeaderText = "Deviation (%)";
            this.Deviation.MinimumWidth = 6;
            this.Deviation.Name = "Deviation";
            this.Deviation.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // PreUpperSpec
            // 
            this.PreUpperSpec.AutoSize = true;
            this.PreUpperSpec.Location = new System.Drawing.Point(246, 79);
            this.PreUpperSpec.Name = "PreUpperSpec";
            this.PreUpperSpec.Size = new System.Drawing.Size(64, 13);
            this.PreUpperSpec.TabIndex = 20;
            this.PreUpperSpec.Text = "Upper Spec";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPreReset);
            this.groupBox4.Controls.Add(this.txtEqID);
            this.groupBox4.Controls.Add(this.comboBoxTorqCalID);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnSaphire);
            this.groupBox4.Controls.Add(this.FormID);
            this.groupBox4.Controls.Add(this.lblDoneBy);
            this.groupBox4.Controls.Add(this.lblFormID);
            this.groupBox4.Controls.Add(this.btnReport);
            this.groupBox4.Controls.Add(this.EQID);
            this.groupBox4.Controls.Add(this.DoneBy);
            this.groupBox4.Controls.Add(this.btnSaveTorqueSetting);
            this.groupBox4.Controls.Add(this.TorqueCalibratorID);
            this.groupBox4.Controls.Add(this.TorqueSetting);
            this.groupBox4.Controls.Add(this.lblCalDate);
            this.groupBox4.Controls.Add(this.StartCalDate);
            this.groupBox4.Controls.Add(this.txtTorqSetting);
            this.groupBox4.Controls.Add(this.Location);
            this.groupBox4.Controls.Add(this.txtLocation);
            this.groupBox4.Location = new System.Drawing.Point(31, 26);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(940, 265);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            // 
            // btnPreReset
            // 
            this.btnPreReset.Location = new System.Drawing.Point(611, 174);
            this.btnPreReset.Name = "btnPreReset";
            this.btnPreReset.Size = new System.Drawing.Size(67, 28);
            this.btnPreReset.TabIndex = 1;
            this.btnPreReset.Text = "Reset";
            this.btnPreReset.UseVisualStyleBackColor = true;
            this.btnPreReset.Click += new System.EventHandler(this.btnPreReset_Click);
            // 
            // txtEqID
            // 
            this.txtEqID.Location = new System.Drawing.Point(194, 90);
            this.txtEqID.Name = "txtEqID";
            this.txtEqID.Size = new System.Drawing.Size(120, 20);
            this.txtEqID.TabIndex = 1;
            // 
            // comboBoxTorqCalID
            // 
            this.comboBoxTorqCalID.CausesValidation = false;
            this.comboBoxTorqCalID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTorqCalID.FormattingEnabled = true;
            this.comboBoxTorqCalID.Location = new System.Drawing.Point(194, 119);
            this.comboBoxTorqCalID.Name = "comboBoxTorqCalID";
            this.comboBoxTorqCalID.Size = new System.Drawing.Size(120, 21);
            this.comboBoxTorqCalID.TabIndex = 37;
            this.comboBoxTorqCalID.SelectedIndexChanged += new System.EventHandler(this.comboBoxTorqCalID_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Torque Calibration Measurement Module";
            // 
            // FormID
            // 
            this.FormID.AutoSize = true;
            this.FormID.Location = new System.Drawing.Point(68, 74);
            this.FormID.Name = "FormID";
            this.FormID.Size = new System.Drawing.Size(44, 13);
            this.FormID.TabIndex = 5;
            this.FormID.Text = "Form ID";
            // 
            // lblFormID
            // 
            this.lblFormID.AutoSize = true;
            this.lblFormID.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblFormID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFormID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFormID.Location = new System.Drawing.Point(194, 58);
            this.lblFormID.Name = "lblFormID";
            this.lblFormID.Size = new System.Drawing.Size(43, 15);
            this.lblFormID.TabIndex = 6;
            this.lblFormID.Text = "FormID";
            this.lblFormID.Visible = false;
            // 
            // EQID
            // 
            this.EQID.AutoSize = true;
            this.EQID.Location = new System.Drawing.Point(68, 98);
            this.EQID.Name = "EQID";
            this.EQID.Size = new System.Drawing.Size(48, 13);
            this.EQID.TabIndex = 7;
            this.EQID.Text = "Equip ID";
            // 
            // DoneBy
            // 
            this.DoneBy.AutoSize = true;
            this.DoneBy.Location = new System.Drawing.Point(442, 84);
            this.DoneBy.Name = "DoneBy";
            this.DoneBy.Size = new System.Drawing.Size(48, 13);
            this.DoneBy.TabIndex = 8;
            this.DoneBy.Text = "Done By";
            // 
            // btnSaveTorqueSetting
            // 
            this.btnSaveTorqueSetting.Location = new System.Drawing.Point(538, 174);
            this.btnSaveTorqueSetting.Name = "btnSaveTorqueSetting";
            this.btnSaveTorqueSetting.Size = new System.Drawing.Size(67, 28);
            this.btnSaveTorqueSetting.TabIndex = 31;
            this.btnSaveTorqueSetting.Text = "Save";
            this.btnSaveTorqueSetting.UseVisualStyleBackColor = true;
            this.btnSaveTorqueSetting.Click += new System.EventHandler(this.btnSaveTorqueSetting_Click);
            // 
            // TorqueCalibratorID
            // 
            this.TorqueCalibratorID.AutoSize = true;
            this.TorqueCalibratorID.Location = new System.Drawing.Point(68, 124);
            this.TorqueCalibratorID.Name = "TorqueCalibratorID";
            this.TorqueCalibratorID.Size = new System.Drawing.Size(102, 13);
            this.TorqueCalibratorID.TabIndex = 9;
            this.TorqueCalibratorID.Text = "Torque Calibrator ID";
            // 
            // TorqueSetting
            // 
            this.TorqueSetting.AutoSize = true;
            this.TorqueSetting.Location = new System.Drawing.Point(68, 148);
            this.TorqueSetting.Name = "TorqueSetting";
            this.TorqueSetting.Size = new System.Drawing.Size(77, 13);
            this.TorqueSetting.TabIndex = 10;
            this.TorqueSetting.Text = "Torque Setting";
            // 
            // StartCalDate
            // 
            this.StartCalDate.AutoSize = true;
            this.StartCalDate.Location = new System.Drawing.Point(442, 111);
            this.StartCalDate.Name = "StartCalDate";
            this.StartCalDate.Size = new System.Drawing.Size(107, 13);
            this.StartCalDate.TabIndex = 11;
            this.StartCalDate.Text = "Start Calibration Date";
            // 
            // txtTorqSetting
            // 
            this.txtTorqSetting.Location = new System.Drawing.Point(194, 148);
            this.txtTorqSetting.Name = "txtTorqSetting";
            this.txtTorqSetting.Size = new System.Drawing.Size(120, 20);
            this.txtTorqSetting.TabIndex = 14;
            // 
            // Location
            // 
            this.Location.AutoSize = true;
            this.Location.Location = new System.Drawing.Point(442, 136);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(48, 13);
            this.Location.TabIndex = 12;
            this.Location.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(590, 133);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(120, 20);
            this.txtLocation.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPostValue);
            this.groupBox2.Controls.Add(this.PostdataGridView);
            this.groupBox2.Controls.Add(this.lblPostAverage);
            this.groupBox2.Controls.Add(this.lblPostMax);
            this.groupBox2.Controls.Add(this.lblPostMin);
            this.groupBox2.Controls.Add(this.lblPostOverallStatus);
            this.groupBox2.Controls.Add(this.lblPostUpperSpec);
            this.groupBox2.Controls.Add(this.lblPostLowerSpec);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnPostComplete);
            this.groupBox2.Controls.Add(this.btnPostRead);
            this.groupBox2.Location = new System.Drawing.Point(31, 751);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(940, 400);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Postcal Stage (±10%)";
            this.groupBox2.Visible = false;
            // 
            // PreLowerSpec
            // 
            this.PreLowerSpec.AutoSize = true;
            this.PreLowerSpec.Location = new System.Drawing.Point(40, 79);
            this.PreLowerSpec.Name = "PreLowerSpec";
            this.PreLowerSpec.Size = new System.Drawing.Size(64, 13);
            this.PreLowerSpec.TabIndex = 19;
            this.PreLowerSpec.Text = "Lower Spec";
            // 
            // btnPreComplete
            // 
            this.btnPreComplete.Enabled = false;
            this.btnPreComplete.Location = new System.Drawing.Point(449, 19);
            this.btnPreComplete.Name = "btnPreComplete";
            this.btnPreComplete.Size = new System.Drawing.Size(150, 23);
            this.btnPreComplete.TabIndex = 2;
            this.btnPreComplete.Text = "Complete (0/5)";
            this.btnPreComplete.UseVisualStyleBackColor = true;
            this.btnPreComplete.Click += new System.EventHandler(this.btnPreComplete_Click);
            // 
            // btnPreRead
            // 
            this.btnPreRead.Location = new System.Drawing.Point(43, 19);
            this.btnPreRead.Name = "btnPreRead";
            this.btnPreRead.Size = new System.Drawing.Size(150, 23);
            this.btnPreRead.TabIndex = 0;
            this.btnPreRead.Text = "Read";
            this.btnPreRead.UseVisualStyleBackColor = true;
            this.btnPreRead.Click += new System.EventHandler(this.btnPreRead_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPreValue);
            this.groupBox1.Controls.Add(this.PredataGridView);
            this.groupBox1.Controls.Add(this.lblPreAverage);
            this.groupBox1.Controls.Add(this.lblPreMax);
            this.groupBox1.Controls.Add(this.lblPreMin);
            this.groupBox1.Controls.Add(this.lblPreOverallStatus);
            this.groupBox1.Controls.Add(this.lblPreUpperSpec);
            this.groupBox1.Controls.Add(this.lblPreLowerSpec);
            this.groupBox1.Controls.Add(this.PreAverage);
            this.groupBox1.Controls.Add(this.PreMax);
            this.groupBox1.Controls.Add(this.PreMin);
            this.groupBox1.Controls.Add(this.PreOverallStatus);
            this.groupBox1.Controls.Add(this.PreUpperSpec);
            this.groupBox1.Controls.Add(this.PreLowerSpec);
            this.groupBox1.Controls.Add(this.btnPreComplete);
            this.groupBox1.Controls.Add(this.btnPreRead);
            this.groupBox1.Location = new System.Drawing.Point(31, 313);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 396);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Precal Stage (±20%)";
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(817, 862);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ParentForm";
            this.Text = "ParentForm";
            this.Load += new System.EventHandler(this.Parent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PostdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PredataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView PostdataGridView;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        public System.Windows.Forms.Label lblPostMax;
        public System.Windows.Forms.Label lblPreAverage;
        public System.Windows.Forms.Label lblPreMax;
        public System.Windows.Forms.Label lblPreMin;
        public System.Windows.Forms.Label lblPreOverallStatus;
        public System.Windows.Forms.Label lblPreUpperSpec;
        public System.Windows.Forms.Label lblPreLowerSpec;
        public System.Windows.Forms.Label lblPostMin;
        public System.Windows.Forms.Label PreAverage;
        public System.Windows.Forms.Label PreMin;
        public System.Windows.Forms.Label PreOverallStatus;
        public System.Windows.Forms.Label lblPostAverage;
        public System.Windows.Forms.Label PreMax;
        public System.Windows.Forms.TextBox txtPostValue;
        public System.Windows.Forms.Label lblPostOverallStatus;
        public System.Windows.Forms.Button btnSaphire;
        public System.Windows.Forms.Label lblDoneBy;
        public System.Windows.Forms.Label lblPostUpperSpec;
        public System.Windows.Forms.Label lblPostLowerSpec;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Button btnReport;
        public System.Windows.Forms.Label lblCalDate;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button btnPostComplete;
        public System.Windows.Forms.TextBox txtPreValue;
        public System.Windows.Forms.Button btnPostRead;
        public System.Windows.Forms.DataGridView PredataGridView;
        public System.Windows.Forms.DataGridViewTextBoxColumn Index;
        public System.Windows.Forms.DataGridViewTextBoxColumn Value;
        public System.Windows.Forms.DataGridViewTextBoxColumn Deviation;
        public System.Windows.Forms.DataGridViewTextBoxColumn Status;
        public System.Windows.Forms.Label PreUpperSpec;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Button btnPreReset;
        public System.Windows.Forms.TextBox txtEqID;
        public System.Windows.Forms.ComboBox comboBoxTorqCalID;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label FormID;
        public System.Windows.Forms.Label lblFormID;
        public System.Windows.Forms.Label EQID;
        public System.Windows.Forms.Label DoneBy;
        public System.Windows.Forms.Button btnSaveTorqueSetting;
        public System.Windows.Forms.Label TorqueCalibratorID;
        public System.Windows.Forms.Label TorqueSetting;
        public System.Windows.Forms.Label StartCalDate;
        public System.Windows.Forms.TextBox txtTorqSetting;
        public System.Windows.Forms.Label Location;
        public System.Windows.Forms.TextBox txtLocation;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label PreLowerSpec;
        public System.Windows.Forms.Button btnPreComplete;
        public System.Windows.Forms.Button btnPreRead;
        public System.Windows.Forms.GroupBox groupBox1;


    }
}