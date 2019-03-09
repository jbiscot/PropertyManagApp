namespace RemaxWinApplication
{
    partial class frmPublic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPublic));
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridResult = new System.Windows.Forms.DataGridView();
            this.radioProperty = new System.Windows.Forms.RadioButton();
            this.radioAgent = new System.Windows.Forms.RadioButton();
            this.txtPropRef = new System.Windows.Forms.TextBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboBathrooms = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboBedrooms = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(532, 13);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(82, 28);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridResult);
            this.groupBox2.Location = new System.Drawing.Point(14, 282);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(601, 288);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // gridResult
            // 
            this.gridResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResult.Location = new System.Drawing.Point(11, 26);
            this.gridResult.Margin = new System.Windows.Forms.Padding(2);
            this.gridResult.MultiSelect = false;
            this.gridResult.Name = "gridResult";
            this.gridResult.ReadOnly = true;
            this.gridResult.RowTemplate.Height = 24;
            this.gridResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResult.Size = new System.Drawing.Size(580, 247);
            this.gridResult.TabIndex = 0;
            // 
            // radioProperty
            // 
            this.radioProperty.AutoSize = true;
            this.radioProperty.Checked = true;
            this.radioProperty.Location = new System.Drawing.Point(11, 50);
            this.radioProperty.Margin = new System.Windows.Forms.Padding(2);
            this.radioProperty.Name = "radioProperty";
            this.radioProperty.Size = new System.Drawing.Size(78, 17);
            this.radioProperty.TabIndex = 19;
            this.radioProperty.TabStop = true;
            this.radioProperty.Text = "by Property";
            this.radioProperty.UseVisualStyleBackColor = true;
            // 
            // radioAgent
            // 
            this.radioAgent.AutoSize = true;
            this.radioAgent.Location = new System.Drawing.Point(11, 28);
            this.radioAgent.Margin = new System.Windows.Forms.Padding(2);
            this.radioAgent.Name = "radioAgent";
            this.radioAgent.Size = new System.Drawing.Size(67, 17);
            this.radioAgent.TabIndex = 18;
            this.radioAgent.Text = "by Agent";
            this.radioAgent.UseVisualStyleBackColor = true;
            this.radioAgent.CheckedChanged += new System.EventHandler(this.radioAgent_CheckedChanged);
            // 
            // txtPropRef
            // 
            this.txtPropRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPropRef.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPropRef.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPropRef.Location = new System.Drawing.Point(11, 95);
            this.txtPropRef.Margin = new System.Windows.Forms.Padding(2);
            this.txtPropRef.Name = "txtPropRef";
            this.txtPropRef.Size = new System.Drawing.Size(114, 19);
            this.txtPropRef.TabIndex = 17;
            this.txtPropRef.Tag = "";
            this.txtPropRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(509, 136);
            this.btnClean.Margin = new System.Windows.Forms.Padding(2);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(82, 28);
            this.btnClean.TabIndex = 6;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(422, 136);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 28);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(477, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Bathrooms";
            // 
            // cboBathrooms
            // 
            this.cboBathrooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBathrooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBathrooms.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cboBathrooms.FormattingEnabled = true;
            this.cboBathrooms.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4+"});
            this.cboBathrooms.Location = new System.Drawing.Point(479, 94);
            this.cboBathrooms.Margin = new System.Windows.Forms.Padding(2);
            this.cboBathrooms.Name = "cboBathrooms";
            this.cboBathrooms.Size = new System.Drawing.Size(114, 21);
            this.cboBathrooms.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agent";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Bedrooms";
            // 
            // cboBedrooms
            // 
            this.cboBedrooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBedrooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBedrooms.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cboBedrooms.FormattingEnabled = true;
            this.cboBedrooms.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4+"});
            this.cboBedrooms.Location = new System.Drawing.Point(362, 94);
            this.cboBedrooms.Margin = new System.Windows.Forms.Padding(2);
            this.cboBedrooms.Name = "cboBedrooms";
            this.cboBedrooms.Size = new System.Drawing.Size(114, 21);
            this.cboBedrooms.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "City";
            // 
            // cboCity
            // 
            this.cboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(245, 94);
            this.cboCity.Margin = new System.Windows.Forms.Padding(2);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(114, 21);
            this.cboCity.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Type";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(128, 94);
            this.cboType.Margin = new System.Windows.Forms.Padding(2);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(114, 21);
            this.cboType.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Property Reference";
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataMember = "Employees";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioProperty);
            this.groupBox1.Controls.Add(this.radioAgent);
            this.groupBox1.Controls.Add(this.txtPropRef);
            this.groupBox1.Controls.Add(this.btnClean);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboBathrooms);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboBedrooms);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboCity);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboEmployee);
            this.groupBox1.Location = new System.Drawing.Point(14, 104);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(601, 173);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find your new home";
            // 
            // cboEmployee
            // 
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmployee.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(11, 136);
            this.cboEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(114, 21);
            this.cboEmployee.TabIndex = 0;
            // 
            // frmPublic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(628, 583);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPublic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remax";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPublic_FormClosed);
            this.Load += new System.EventHandler(this.frmPublic_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridResult;
        private System.Windows.Forms.RadioButton radioProperty;
        private System.Windows.Forms.RadioButton radioAgent;
        private System.Windows.Forms.TextBox txtPropRef;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboBathrooms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboBedrooms;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboEmployee;
    }
}