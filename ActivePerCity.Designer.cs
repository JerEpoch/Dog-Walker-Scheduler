
namespace JStudzinski_CapstoneA
{
    partial class ActivePerCity
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
            this.dgvActive = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.btnCity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActive
            // 
            this.dgvActive.AllowUserToAddRows = false;
            this.dgvActive.AllowUserToDeleteRows = false;
            this.dgvActive.AllowUserToResizeRows = false;
            this.dgvActive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvActive.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dgvActive.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActive.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvActive.Location = new System.Drawing.Point(26, 21);
            this.dgvActive.Name = "dgvActive";
            this.dgvActive.ReadOnly = true;
            this.dgvActive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActive.Size = new System.Drawing.Size(263, 303);
            this.dgvActive.TabIndex = 0;
            this.dgvActive.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActive_CellClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(193, 369);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 51);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(355, 21);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(605, 303);
            this.dgvCustomers.TabIndex = 2;
            // 
            // btnCity
            // 
            this.btnCity.Location = new System.Drawing.Point(26, 369);
            this.btnCity.Name = "btnCity";
            this.btnCity.Size = new System.Drawing.Size(121, 51);
            this.btnCity.TabIndex = 3;
            this.btnCity.Text = "Get Customers in City";
            this.btnCity.UseVisualStyleBackColor = true;
            this.btnCity.Click += new System.EventHandler(this.btnCity_Click);
            // 
            // ActivePerCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 462);
            this.Controls.Add(this.btnCity);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvActive);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ActivePerCity";
            this.Text = "Active Per City";
            this.Load += new System.EventHandler(this.ActivePerCity_Load);
            this.Shown += new System.EventHandler(this.ActivePerCity_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnCity;
    }
}