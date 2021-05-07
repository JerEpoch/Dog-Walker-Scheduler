
namespace JStudzinski_CapstoneA
{
    partial class InactiveCustomers
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
            this.dgvInactive = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInactive)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInactive
            // 
            this.dgvInactive.AllowUserToAddRows = false;
            this.dgvInactive.AllowUserToDeleteRows = false;
            this.dgvInactive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvInactive.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvInactive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInactive.Location = new System.Drawing.Point(33, 29);
            this.dgvInactive.MultiSelect = false;
            this.dgvInactive.Name = "dgvInactive";
            this.dgvInactive.ReadOnly = true;
            this.dgvInactive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInactive.Size = new System.Drawing.Size(838, 265);
            this.dgvInactive.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(352, 328);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 47);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close Report";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // InactiveCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 407);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvInactive);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InactiveCustomers";
            this.Text = "Inactive Customers";
            this.Load += new System.EventHandler(this.InactiveCustomers_Load);
            this.Shown += new System.EventHandler(this.InactiveCustomers_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInactive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInactive;
        private System.Windows.Forms.Button btnClose;
    }
}