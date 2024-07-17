namespace CedarTorque
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
            this.txtEqID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FormID = new System.Windows.Forms.Label();
            this.lblFormID = new System.Windows.Forms.Label();
            this.EQID = new System.Windows.Forms.Label();
            this.DoneBy = new System.Windows.Forms.Label();
            this.TorqueCalibratorID = new System.Windows.Forms.Label();
            this.TorqueSetting = new System.Windows.Forms.Label();
            this.StartCalDate = new System.Windows.Forms.Label();
            this.Location = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtTorqSetting = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtPreValue = new System.Windows.Forms.TextBox();
            this.PredataGridView = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPreAverage = new System.Windows.Forms.Label();
            this.lblPreMax = new System.Windows.Forms.Label();
            this.lblPreMin = new System.Windows.Forms.Label();
            this.lblPreOverallStatus = new System.Windows.Forms.Label();
            this.lblPreUpperSpec = new System.Windows.Forms.Label();
            this.lblPreLowerSpec = new System.Windows.Forms.Label();
            this.PreAverage = new System.Windows.Forms.Label();
            this.PreMax = new System.Windows.Forms.Label();
            this.PreMin = new System.Windows.Forms.Label();
            this.PreOverallStatus = new System.Windows.Forms.Label();
            this.PreUpperSpec = new System.Windows.Forms.Label();
            this.PreLowerSpec = new System.Windows.Forms.Label();
            this.btnPreComplete = new System.Windows.Forms.Button();
            this.btnPreRead = new System.Windows.Forms.Button();
            this.btnPreReset = new System.Windows.Forms.Button();
            this.btnSaveTorqueSetting = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPostValue = new System.Windows.Forms.TextBox();
            this.PostdataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPostAverage = new System.Windows.Forms.Label();
            this.lblPostMax = new System.Windows.Forms.Label();
            this.lblPostMin = new System.Windows.Forms.Label();
            this.lblPostOverallStatus = new System.Windows.Forms.Label();
            this.lblPostUpperSpec = new System.Windows.Forms.Label();
            this.lblPostLowerSpec = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnPostComplete = new System.Windows.Forms.Button();
            this.btnPostRead = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblCalDate = new System.Windows.Forms.Label();
            this.lblDoneBy = new System.Windows.Forms.Label();
            this.btnSaphire = new System.Windows.Forms.Button();
            this.comboBoxTorqCalID = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PredataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PostdataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEqID
            // 
            this.txtEqID.Location = new System.Drawing.Point(258, 111);
            this.txtEqID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEqID.Name = "txtEqID";
            this.txtEqID.Size = new System.Drawing.Size(159, 22);
            this.txtEqID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Torque Calibration Measurement Module";
            // 
            // FormID
            // 
            this.FormID.AutoSize = true;
            this.FormID.Location = new System.Drawing.Point(91, 91);
            this.FormID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FormID.Name = "FormID";
            this.FormID.Size = new System.Drawing.Size(54, 16);
            this.FormID.TabIndex = 5;
            this.FormID.Text = "Form ID";
            // 
            // lblFormID
            // 
            this.lblFormID.AutoSize = true;
            this.lblFormID.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblFormID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFormID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFormID.Location = new System.Drawing.Point(258, 72);
            this.lblFormID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormID.Name = "lblFormID";
            this.lblFormID.Size = new System.Drawing.Size(53, 18);
            this.lblFormID.TabIndex = 6;
            this.lblFormID.Text = "FormID";
            this.lblFormID.Visible = false;
            // 
            // EQID
            // 
            this.EQID.AutoSize = true;
            this.EQID.Location = new System.Drawing.Point(91, 120);
            this.EQID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EQID.Name = "EQID";
            this.EQID.Size = new System.Drawing.Size(58, 16);
            this.EQID.TabIndex = 7;
            this.EQID.Text = "Equip ID";
            // 
            // DoneBy
            // 
            this.DoneBy.AutoSize = true;
            this.DoneBy.Location = new System.Drawing.Point(590, 104);
            this.DoneBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DoneBy.Name = "DoneBy";
            this.DoneBy.Size = new System.Drawing.Size(59, 16);
            this.DoneBy.TabIndex = 8;
            this.DoneBy.Text = "Done By";
            // 
            // TorqueCalibratorID
            // 
            this.TorqueCalibratorID.AutoSize = true;
            this.TorqueCalibratorID.Location = new System.Drawing.Point(90, 152);
            this.TorqueCalibratorID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TorqueCalibratorID.Name = "TorqueCalibratorID";
            this.TorqueCalibratorID.Size = new System.Drawing.Size(128, 16);
            this.TorqueCalibratorID.TabIndex = 9;
            this.TorqueCalibratorID.Text = "Torque Calibrator ID";
            // 
            // TorqueSetting
            // 
            this.TorqueSetting.AutoSize = true;
            this.TorqueSetting.Location = new System.Drawing.Point(91, 182);
            this.TorqueSetting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TorqueSetting.Name = "TorqueSetting";
            this.TorqueSetting.Size = new System.Drawing.Size(95, 16);
            this.TorqueSetting.TabIndex = 10;
            this.TorqueSetting.Text = "Torque Setting";
            // 
            // StartCalDate
            // 
            this.StartCalDate.AutoSize = true;
            this.StartCalDate.Location = new System.Drawing.Point(590, 137);
            this.StartCalDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartCalDate.Name = "StartCalDate";
            this.StartCalDate.Size = new System.Drawing.Size(133, 16);
            this.StartCalDate.TabIndex = 11;
            this.StartCalDate.Text = "Start Calibration Date";
            // 
            // Location
            // 
            this.Location.AutoSize = true;
            this.Location.Location = new System.Drawing.Point(590, 168);
            this.Location.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(58, 16);
            this.Location.TabIndex = 12;
            this.Location.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(684, 165);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(159, 22);
            this.txtLocation.TabIndex = 13;
            // 
            // txtTorqSetting
            // 
            this.txtTorqSetting.Location = new System.Drawing.Point(258, 182);
            this.txtTorqSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTorqSetting.Name = "txtTorqSetting";
            this.txtTorqSetting.Size = new System.Drawing.Size(159, 22);
            this.txtTorqSetting.TabIndex = 14;
            this.txtTorqSetting.TextChanged += new System.EventHandler(this.txtTorqSetting_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
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
            this.groupBox1.Location = new System.Drawing.Point(35, 318);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1003, 390);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Precal Stage (±20%)";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(519, 90);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 7);
            this.flowLayoutPanel1.TabIndex = 31;
            // 
            // txtPreValue
            // 
            this.txtPreValue.Enabled = false;
            this.txtPreValue.Location = new System.Drawing.Point(57, 48);
            this.txtPreValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPreValue.Name = "txtPreValue";
            this.txtPreValue.Size = new System.Drawing.Size(199, 22);
            this.txtPreValue.TabIndex = 19;
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
            this.PredataGridView.Location = new System.Drawing.Point(31, 177);
            this.PredataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PredataGridView.Name = "PredataGridView";
            this.PredataGridView.ReadOnly = true;
            this.PredataGridView.RowHeadersWidth = 51;
            this.PredataGridView.Size = new System.Drawing.Size(933, 185);
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
            // lblPreAverage
            // 
            this.lblPreAverage.AutoSize = true;
            this.lblPreAverage.BackColor = System.Drawing.SystemColors.Control;
            this.lblPreAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreAverage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPreAverage.Location = new System.Drawing.Point(700, 126);
            this.lblPreAverage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreAverage.Name = "lblPreAverage";
            this.lblPreAverage.Size = new System.Drawing.Size(61, 18);
            this.lblPreAverage.TabIndex = 29;
            this.lblPreAverage.Text = "Average";
            // 
            // lblPreMax
            // 
            this.lblPreMax.AutoSize = true;
            this.lblPreMax.BackColor = System.Drawing.SystemColors.Control;
            this.lblPreMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreMax.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPreMax.Location = new System.Drawing.Point(421, 126);
            this.lblPreMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreMax.Name = "lblPreMax";
            this.lblPreMax.Size = new System.Drawing.Size(34, 18);
            this.lblPreMax.TabIndex = 28;
            this.lblPreMax.Text = "Max";
            // 
            // lblPreMin
            // 
            this.lblPreMin.AutoSize = true;
            this.lblPreMin.BackColor = System.Drawing.SystemColors.Control;
            this.lblPreMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreMin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPreMin.Location = new System.Drawing.Point(147, 126);
            this.lblPreMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreMin.Name = "lblPreMin";
            this.lblPreMin.Size = new System.Drawing.Size(30, 18);
            this.lblPreMin.TabIndex = 27;
            this.lblPreMin.Text = "Min";
            // 
            // lblPreOverallStatus
            // 
            this.lblPreOverallStatus.AutoSize = true;
            this.lblPreOverallStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblPreOverallStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreOverallStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPreOverallStatus.Location = new System.Drawing.Point(700, 96);
            this.lblPreOverallStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreOverallStatus.Name = "lblPreOverallStatus";
            this.lblPreOverallStatus.Size = new System.Drawing.Size(92, 18);
            this.lblPreOverallStatus.TabIndex = 26;
            this.lblPreOverallStatus.Text = "Overall Status";
            // 
            // lblPreUpperSpec
            // 
            this.lblPreUpperSpec.AutoSize = true;
            this.lblPreUpperSpec.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPreUpperSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreUpperSpec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPreUpperSpec.Location = new System.Drawing.Point(421, 97);
            this.lblPreUpperSpec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreUpperSpec.Name = "lblPreUpperSpec";
            this.lblPreUpperSpec.Size = new System.Drawing.Size(82, 18);
            this.lblPreUpperSpec.TabIndex = 25;
            this.lblPreUpperSpec.Text = "Upper Spec";
            // 
            // lblPreLowerSpec
            // 
            this.lblPreLowerSpec.AutoSize = true;
            this.lblPreLowerSpec.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPreLowerSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreLowerSpec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPreLowerSpec.Location = new System.Drawing.Point(147, 97);
            this.lblPreLowerSpec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreLowerSpec.Name = "lblPreLowerSpec";
            this.lblPreLowerSpec.Size = new System.Drawing.Size(80, 18);
            this.lblPreLowerSpec.TabIndex = 19;
            this.lblPreLowerSpec.Text = "Lower Spec";
            // 
            // PreAverage
            // 
            this.PreAverage.AutoSize = true;
            this.PreAverage.Location = new System.Drawing.Point(595, 126);
            this.PreAverage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PreAverage.Name = "PreAverage";
            this.PreAverage.Size = new System.Drawing.Size(59, 16);
            this.PreAverage.TabIndex = 24;
            this.PreAverage.Text = "Average";
            // 
            // PreMax
            // 
            this.PreMax.AutoSize = true;
            this.PreMax.Location = new System.Drawing.Point(328, 126);
            this.PreMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PreMax.Name = "PreMax";
            this.PreMax.Size = new System.Drawing.Size(32, 16);
            this.PreMax.TabIndex = 23;
            this.PreMax.Text = "Max";
            // 
            // PreMin
            // 
            this.PreMin.AutoSize = true;
            this.PreMin.Location = new System.Drawing.Point(53, 126);
            this.PreMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PreMin.Name = "PreMin";
            this.PreMin.Size = new System.Drawing.Size(28, 16);
            this.PreMin.TabIndex = 22;
            this.PreMin.Text = "Min";
            // 
            // PreOverallStatus
            // 
            this.PreOverallStatus.AutoSize = true;
            this.PreOverallStatus.Location = new System.Drawing.Point(595, 97);
            this.PreOverallStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PreOverallStatus.Name = "PreOverallStatus";
            this.PreOverallStatus.Size = new System.Drawing.Size(90, 16);
            this.PreOverallStatus.TabIndex = 21;
            this.PreOverallStatus.Text = "Overall Status";
            // 
            // PreUpperSpec
            // 
            this.PreUpperSpec.AutoSize = true;
            this.PreUpperSpec.Location = new System.Drawing.Point(328, 97);
            this.PreUpperSpec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PreUpperSpec.Name = "PreUpperSpec";
            this.PreUpperSpec.Size = new System.Drawing.Size(80, 16);
            this.PreUpperSpec.TabIndex = 20;
            this.PreUpperSpec.Text = "Upper Spec";
            // 
            // PreLowerSpec
            // 
            this.PreLowerSpec.AutoSize = true;
            this.PreLowerSpec.Location = new System.Drawing.Point(53, 97);
            this.PreLowerSpec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PreLowerSpec.Name = "PreLowerSpec";
            this.PreLowerSpec.Size = new System.Drawing.Size(78, 16);
            this.PreLowerSpec.TabIndex = 19;
            this.PreLowerSpec.Text = "Lower Spec";
            // 
            // btnPreComplete
            // 
            this.btnPreComplete.Enabled = false;
            this.btnPreComplete.Location = new System.Drawing.Point(599, 23);
            this.btnPreComplete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreComplete.Name = "btnPreComplete";
            this.btnPreComplete.Size = new System.Drawing.Size(200, 28);
            this.btnPreComplete.TabIndex = 2;
            this.btnPreComplete.Text = "Complete (0/5)";
            this.btnPreComplete.UseVisualStyleBackColor = true;
            this.btnPreComplete.Click += new System.EventHandler(this.btnPreComplete_Click);
            // 
            // btnPreRead
            // 
            this.btnPreRead.Location = new System.Drawing.Point(57, 23);
            this.btnPreRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreRead.Name = "btnPreRead";
            this.btnPreRead.Size = new System.Drawing.Size(200, 28);
            this.btnPreRead.TabIndex = 0;
            this.btnPreRead.Text = "Read";
            this.btnPreRead.UseVisualStyleBackColor = true;
            this.btnPreRead.Click += new System.EventHandler(this.btnPreRead_Click);
            // 
            // btnPreReset
            // 
            this.btnPreReset.Location = new System.Drawing.Point(815, 214);
            this.btnPreReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreReset.Name = "btnPreReset";
            this.btnPreReset.Size = new System.Drawing.Size(89, 34);
            this.btnPreReset.TabIndex = 1;
            this.btnPreReset.Text = "Reset";
            this.btnPreReset.UseVisualStyleBackColor = true;
            this.btnPreReset.Click += new System.EventHandler(this.btnPreReset_Click);
            // 
            // btnSaveTorqueSetting
            // 
            this.btnSaveTorqueSetting.Location = new System.Drawing.Point(718, 214);
            this.btnSaveTorqueSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveTorqueSetting.Name = "btnSaveTorqueSetting";
            this.btnSaveTorqueSetting.Size = new System.Drawing.Size(89, 34);
            this.btnSaveTorqueSetting.TabIndex = 31;
            this.btnSaveTorqueSetting.Text = "Save";
            this.btnSaveTorqueSetting.UseVisualStyleBackColor = true;
            this.btnSaveTorqueSetting.Click += new System.EventHandler(this.btnSaveTorqueSetting_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(35, 750);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1003, 394);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Postcal Stage (±10%)";
            this.groupBox2.Visible = false;
            // 
            // txtPostValue
            // 
            this.txtPostValue.Enabled = false;
            this.txtPostValue.Location = new System.Drawing.Point(57, 48);
            this.txtPostValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPostValue.Name = "txtPostValue";
            this.txtPostValue.Size = new System.Drawing.Size(199, 22);
            this.txtPostValue.TabIndex = 19;
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
            this.PostdataGridView.Location = new System.Drawing.Point(31, 175);
            this.PostdataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PostdataGridView.Name = "PostdataGridView";
            this.PostdataGridView.ReadOnly = true;
            this.PostdataGridView.RowHeadersWidth = 51;
            this.PostdataGridView.Size = new System.Drawing.Size(933, 185);
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
            // lblPostAverage
            // 
            this.lblPostAverage.AutoSize = true;
            this.lblPostAverage.BackColor = System.Drawing.SystemColors.Control;
            this.lblPostAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostAverage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPostAverage.Location = new System.Drawing.Point(700, 126);
            this.lblPostAverage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostAverage.Name = "lblPostAverage";
            this.lblPostAverage.Size = new System.Drawing.Size(61, 18);
            this.lblPostAverage.TabIndex = 29;
            this.lblPostAverage.Text = "Average";
            // 
            // lblPostMax
            // 
            this.lblPostMax.AutoSize = true;
            this.lblPostMax.BackColor = System.Drawing.SystemColors.Control;
            this.lblPostMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostMax.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPostMax.Location = new System.Drawing.Point(421, 126);
            this.lblPostMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostMax.Name = "lblPostMax";
            this.lblPostMax.Size = new System.Drawing.Size(34, 18);
            this.lblPostMax.TabIndex = 28;
            this.lblPostMax.Text = "Max";
            // 
            // lblPostMin
            // 
            this.lblPostMin.AutoSize = true;
            this.lblPostMin.BackColor = System.Drawing.SystemColors.Control;
            this.lblPostMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostMin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPostMin.Location = new System.Drawing.Point(147, 126);
            this.lblPostMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostMin.Name = "lblPostMin";
            this.lblPostMin.Size = new System.Drawing.Size(30, 18);
            this.lblPostMin.TabIndex = 27;
            this.lblPostMin.Text = "Min";
            // 
            // lblPostOverallStatus
            // 
            this.lblPostOverallStatus.AutoSize = true;
            this.lblPostOverallStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblPostOverallStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostOverallStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPostOverallStatus.Location = new System.Drawing.Point(700, 96);
            this.lblPostOverallStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostOverallStatus.Name = "lblPostOverallStatus";
            this.lblPostOverallStatus.Size = new System.Drawing.Size(92, 18);
            this.lblPostOverallStatus.TabIndex = 26;
            this.lblPostOverallStatus.Text = "Overall Status";
            // 
            // lblPostUpperSpec
            // 
            this.lblPostUpperSpec.AutoSize = true;
            this.lblPostUpperSpec.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPostUpperSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostUpperSpec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPostUpperSpec.Location = new System.Drawing.Point(421, 97);
            this.lblPostUpperSpec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostUpperSpec.Name = "lblPostUpperSpec";
            this.lblPostUpperSpec.Size = new System.Drawing.Size(82, 18);
            this.lblPostUpperSpec.TabIndex = 25;
            this.lblPostUpperSpec.Text = "Upper Spec";
            // 
            // lblPostLowerSpec
            // 
            this.lblPostLowerSpec.AutoSize = true;
            this.lblPostLowerSpec.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblPostLowerSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostLowerSpec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPostLowerSpec.Location = new System.Drawing.Point(147, 97);
            this.lblPostLowerSpec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostLowerSpec.Name = "lblPostLowerSpec";
            this.lblPostLowerSpec.Size = new System.Drawing.Size(80, 18);
            this.lblPostLowerSpec.TabIndex = 19;
            this.lblPostLowerSpec.Text = "Lower Spec";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(595, 126);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "Average";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 126);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Max";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 126);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Min";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(595, 97);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Overall Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(328, 97);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Upper Spec";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(53, 97);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "Lower Spec";
            // 
            // btnPostComplete
            // 
            this.btnPostComplete.Location = new System.Drawing.Point(599, 23);
            this.btnPostComplete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPostComplete.Name = "btnPostComplete";
            this.btnPostComplete.Size = new System.Drawing.Size(200, 28);
            this.btnPostComplete.TabIndex = 2;
            this.btnPostComplete.Text = "Complete (0/5)";
            this.btnPostComplete.UseVisualStyleBackColor = true;
            this.btnPostComplete.Click += new System.EventHandler(this.btnPostComplete_Click);
            // 
            // btnPostRead
            // 
            this.btnPostRead.Location = new System.Drawing.Point(57, 23);
            this.btnPostRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPostRead.Name = "btnPostRead";
            this.btnPostRead.Size = new System.Drawing.Size(200, 28);
            this.btnPostRead.TabIndex = 0;
            this.btnPostRead.Text = "Read";
            this.btnPostRead.UseVisualStyleBackColor = true;
            this.btnPostRead.Click += new System.EventHandler(this.btnPostRead_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.LightCoral;
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(539, 22);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(197, 34);
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
            this.lblCalDate.Location = new System.Drawing.Point(786, 134);
            this.lblCalDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalDate.Name = "lblCalDate";
            this.lblCalDate.Size = new System.Drawing.Size(58, 18);
            this.lblCalDate.TabIndex = 15;
            this.lblCalDate.Text = "CalDate";
            this.lblCalDate.Visible = false;
            // 
            // lblDoneBy
            // 
            this.lblDoneBy.AutoSize = true;
            this.lblDoneBy.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblDoneBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDoneBy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDoneBy.Location = new System.Drawing.Point(786, 104);
            this.lblDoneBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoneBy.Name = "lblDoneBy";
            this.lblDoneBy.Size = new System.Drawing.Size(58, 18);
            this.lblDoneBy.TabIndex = 35;
            this.lblDoneBy.Text = "DoneBy";
            // 
            // btnSaphire
            // 
            this.btnSaphire.BackColor = System.Drawing.Color.Red;
            this.btnSaphire.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaphire.Location = new System.Drawing.Point(750, 22);
            this.btnSaphire.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaphire.Name = "btnSaphire";
            this.btnSaphire.Size = new System.Drawing.Size(168, 34);
            this.btnSaphire.TabIndex = 36;
            this.btnSaphire.Text = "Connect to Saphire";
            this.btnSaphire.UseVisualStyleBackColor = false;
            this.btnSaphire.Visible = false;
            this.btnSaphire.Click += new System.EventHandler(this.actualSapphireClick);
            // 
            // comboBoxTorqCalID
            // 
            this.comboBoxTorqCalID.FormattingEnabled = true;
            this.comboBoxTorqCalID.Location = new System.Drawing.Point(258, 147);
            this.comboBoxTorqCalID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxTorqCalID.Name = "comboBoxTorqCalID";
            this.comboBoxTorqCalID.Size = new System.Drawing.Size(159, 24);
            this.comboBoxTorqCalID.TabIndex = 37;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(957, 116);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(8, 7);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
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
            this.groupBox4.Location = new System.Drawing.Point(35, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1003, 261);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1063, 1176);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Torque Cal Measurement Module";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PredataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PostdataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtEqID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FormID;
        private System.Windows.Forms.Label lblFormID;
        private System.Windows.Forms.Label EQID;
        private System.Windows.Forms.Label DoneBy;
        private System.Windows.Forms.Label TorqueCalibratorID;
        private System.Windows.Forms.Label TorqueSetting;
        private System.Windows.Forms.Label StartCalDate;
        private System.Windows.Forms.Label Location;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtTorqSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label PreLowerSpec;
        private System.Windows.Forms.Button btnPreComplete;
        private System.Windows.Forms.Button btnPreReset;
        private System.Windows.Forms.Button btnPreRead;
        private System.Windows.Forms.Label PreAverage;
        private System.Windows.Forms.Label PreMax;
        private System.Windows.Forms.Label PreMin;
        private System.Windows.Forms.Label PreOverallStatus;
        private System.Windows.Forms.Label PreUpperSpec;
        private System.Windows.Forms.Label lblPreLowerSpec;
        private System.Windows.Forms.Label lblPreUpperSpec;
        private System.Windows.Forms.Label lblPreOverallStatus;
        private System.Windows.Forms.Label lblPreMin;
        private System.Windows.Forms.Label lblPreMax;
        private System.Windows.Forms.Label lblPreAverage;
        private System.Windows.Forms.DataGridView PredataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.TextBox txtPreValue;
        private System.Windows.Forms.Button btnSaveTorqueSetting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPostValue;
        private System.Windows.Forms.DataGridView PostdataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label lblPostAverage;
        private System.Windows.Forms.Label lblPostMax;
        private System.Windows.Forms.Label lblPostMin;
        private System.Windows.Forms.Label lblPostOverallStatus;
        private System.Windows.Forms.Label lblPostUpperSpec;
        private System.Windows.Forms.Label lblPostLowerSpec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnPostComplete;
        private System.Windows.Forms.Button btnPostRead;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblCalDate;
        private System.Windows.Forms.Label lblDoneBy;
        private System.Windows.Forms.Button btnSaphire;
        private System.Windows.Forms.ComboBox comboBoxTorqCalID;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

