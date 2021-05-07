
namespace JStudzinski_CapstoneA
{
    partial class MainScreen
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
            this.dgvAppts = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelAppt = new System.Windows.Forms.Button();
            this.btnModifyAppt = new System.Windows.Forms.Button();
            this.btnNewAppt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelCustomer = new System.Windows.Forms.Button();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelPet = new System.Windows.Forms.Button();
            this.btnEditPet = new System.Windows.Forms.Button();
            this.btnNewPet = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.bntChangeUser = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.cmbFrequency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSpecific = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.btnViewRpt = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAppts
            // 
            this.dgvAppts.AllowUserToAddRows = false;
            this.dgvAppts.AllowUserToDeleteRows = false;
            this.dgvAppts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvAppts.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvAppts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppts.Location = new System.Drawing.Point(254, 74);
            this.dgvAppts.MultiSelect = false;
            this.dgvAppts.Name = "dgvAppts";
            this.dgvAppts.ReadOnly = true;
            this.dgvAppts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppts.Size = new System.Drawing.Size(632, 318);
            this.dgvAppts.TabIndex = 0;
            this.toolTip1.SetToolTip(this.dgvAppts, "Here are scheduled or previous appointments.");
            this.dgvAppts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppts_CellClick);
            this.dgvAppts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAppts_CellFormatting);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnCancelAppt);
            this.groupBox1.Controls.Add(this.btnModifyAppt);
            this.groupBox1.Controls.Add(this.btnNewAppt);
            this.groupBox1.Location = new System.Drawing.Point(25, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 230);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appointment Management";
            // 
            // btnCancelAppt
            // 
            this.btnCancelAppt.Location = new System.Drawing.Point(23, 133);
            this.btnCancelAppt.Name = "btnCancelAppt";
            this.btnCancelAppt.Size = new System.Drawing.Size(141, 34);
            this.btnCancelAppt.TabIndex = 2;
            this.btnCancelAppt.Text = "Cancel Appointment";
            this.btnCancelAppt.UseVisualStyleBackColor = true;
            this.btnCancelAppt.Click += new System.EventHandler(this.btnCancelAppt_Click);
            // 
            // btnModifyAppt
            // 
            this.btnModifyAppt.Location = new System.Drawing.Point(23, 83);
            this.btnModifyAppt.Name = "btnModifyAppt";
            this.btnModifyAppt.Size = new System.Drawing.Size(141, 34);
            this.btnModifyAppt.TabIndex = 1;
            this.btnModifyAppt.Text = "Change Appointment";
            this.btnModifyAppt.UseVisualStyleBackColor = true;
            this.btnModifyAppt.Click += new System.EventHandler(this.btnModifyAppt_Click);
            // 
            // btnNewAppt
            // 
            this.btnNewAppt.Location = new System.Drawing.Point(23, 32);
            this.btnNewAppt.Name = "btnNewAppt";
            this.btnNewAppt.Size = new System.Drawing.Size(141, 34);
            this.btnNewAppt.TabIndex = 0;
            this.btnNewAppt.Text = "New Appointment";
            this.btnNewAppt.UseVisualStyleBackColor = true;
            this.btnNewAppt.Click += new System.EventHandler(this.btnNewAppt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelCustomer);
            this.groupBox2.Controls.Add(this.btnEditCustomer);
            this.groupBox2.Controls.Add(this.btnNewCustomer);
            this.groupBox2.Location = new System.Drawing.Point(25, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 191);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Management";
            // 
            // btnDelCustomer
            // 
            this.btnDelCustomer.Location = new System.Drawing.Point(23, 133);
            this.btnDelCustomer.Name = "btnDelCustomer";
            this.btnDelCustomer.Size = new System.Drawing.Size(141, 34);
            this.btnDelCustomer.TabIndex = 2;
            this.btnDelCustomer.Text = "Delete Customer";
            this.btnDelCustomer.UseVisualStyleBackColor = true;
            this.btnDelCustomer.Click += new System.EventHandler(this.btnDelCustomer_Click);
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Location = new System.Drawing.Point(23, 83);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(141, 34);
            this.btnEditCustomer.TabIndex = 1;
            this.btnEditCustomer.Text = "Edit Customer";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Location = new System.Drawing.Point(23, 32);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(141, 34);
            this.btnNewCustomer.TabIndex = 0;
            this.btnNewCustomer.Text = "New Customer";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(21, 22);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(65, 21);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "default";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDelPet);
            this.groupBox3.Controls.Add(this.btnEditPet);
            this.groupBox3.Controls.Add(this.btnNewPet);
            this.groupBox3.Location = new System.Drawing.Point(916, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 191);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dog Management";
            // 
            // btnDelPet
            // 
            this.btnDelPet.Location = new System.Drawing.Point(23, 133);
            this.btnDelPet.Name = "btnDelPet";
            this.btnDelPet.Size = new System.Drawing.Size(141, 34);
            this.btnDelPet.TabIndex = 2;
            this.btnDelPet.Text = "Delete Dog";
            this.btnDelPet.UseVisualStyleBackColor = true;
            this.btnDelPet.Click += new System.EventHandler(this.btnDelPet_Click);
            // 
            // btnEditPet
            // 
            this.btnEditPet.Location = new System.Drawing.Point(23, 83);
            this.btnEditPet.Name = "btnEditPet";
            this.btnEditPet.Size = new System.Drawing.Size(141, 34);
            this.btnEditPet.TabIndex = 1;
            this.btnEditPet.Text = "Edit Dog";
            this.btnEditPet.UseVisualStyleBackColor = true;
            this.btnEditPet.Click += new System.EventHandler(this.btnEditPet_Click);
            // 
            // btnNewPet
            // 
            this.btnNewPet.Location = new System.Drawing.Point(23, 32);
            this.btnNewPet.Name = "btnNewPet";
            this.btnNewPet.Size = new System.Drawing.Size(141, 34);
            this.btnNewPet.TabIndex = 0;
            this.btnNewPet.Text = "New Dog";
            this.btnNewPet.UseVisualStyleBackColor = true;
            this.btnNewPet.Click += new System.EventHandler(this.btnNewPet_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1000, 481);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 39);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.toolTip1.SetToolTip(this.btnExit, "Exit the program.");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteUser);
            this.groupBox4.Controls.Add(this.bntChangeUser);
            this.groupBox4.Controls.Add(this.btnNewUser);
            this.groupBox4.Location = new System.Drawing.Point(916, 271);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(187, 191);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "User Management";
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(23, 133);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(141, 34);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // bntChangeUser
            // 
            this.bntChangeUser.Location = new System.Drawing.Point(23, 83);
            this.bntChangeUser.Name = "bntChangeUser";
            this.bntChangeUser.Size = new System.Drawing.Size(141, 34);
            this.bntChangeUser.TabIndex = 1;
            this.bntChangeUser.Text = "Change User";
            this.bntChangeUser.UseVisualStyleBackColor = true;
            this.bntChangeUser.Click += new System.EventHandler(this.bntChangeUser_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(23, 32);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(141, 34);
            this.btnNewUser.TabIndex = 0;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // cmbFrequency
            // 
            this.cmbFrequency.FormattingEnabled = true;
            this.cmbFrequency.Items.AddRange(new object[] {
            "All",
            "Today",
            "Next 7 days",
            "Next 31 days"});
            this.cmbFrequency.Location = new System.Drawing.Point(254, 429);
            this.cmbFrequency.Name = "cmbFrequency";
            this.cmbFrequency.Size = new System.Drawing.Size(156, 25);
            this.cmbFrequency.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "View Appointments By:";
            // 
            // chkSpecific
            // 
            this.chkSpecific.AutoSize = true;
            this.chkSpecific.Location = new System.Drawing.Point(434, 439);
            this.chkSpecific.Name = "chkSpecific";
            this.chkSpecific.Size = new System.Drawing.Size(203, 21);
            this.chkSpecific.TabIndex = 8;
            this.chkSpecific.Text = "Show Only Your Appointments";
            this.toolTip1.SetToolTip(this.chkSpecific, "Check to this to view your appointments only.");
            this.chkSpecific.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(254, 474);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(141, 53);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.toolTip1.SetToolTip(this.btnRefresh, "Select from the list above and click to get appointments.");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbReports
            // 
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Items.AddRange(new object[] {
            "View Inactive Customers",
            "Active Customers Per City",
            "View All Customers"});
            this.cmbReports.Location = new System.Drawing.Point(712, 427);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(163, 25);
            this.cmbReports.TabIndex = 10;
            this.cmbReports.Text = "Select A Report";
            // 
            // btnViewRpt
            // 
            this.btnViewRpt.Location = new System.Drawing.Point(712, 467);
            this.btnViewRpt.Name = "btnViewRpt";
            this.btnViewRpt.Size = new System.Drawing.Size(141, 53);
            this.btnViewRpt.TabIndex = 11;
            this.btnViewRpt.Text = "View Report";
            this.toolTip1.SetToolTip(this.btnViewRpt, "Select a report from the list and click to view report.");
            this.btnViewRpt.UseVisualStyleBackColor = true;
            this.btnViewRpt.Click += new System.EventHandler(this.btnViewRpt_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Mark Completed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1132, 532);
            this.Controls.Add(this.btnViewRpt);
            this.Controls.Add(this.cmbReports);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.chkSpecific);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFrequency);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAppts);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.Shown += new System.EventHandler(this.MainScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelAppt;
        private System.Windows.Forms.Button btnModifyAppt;
        private System.Windows.Forms.Button btnNewAppt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelCustomer;
        private System.Windows.Forms.Button btnEditCustomer;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDelPet;
        private System.Windows.Forms.Button btnEditPet;
        private System.Windows.Forms.Button btnNewPet;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button bntChangeUser;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.ComboBox cmbFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSpecific;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.Button btnViewRpt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
    }
}