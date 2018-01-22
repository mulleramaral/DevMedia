namespace Client
{
    partial class frmPrincipal
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnInvocarServico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(24, 74);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(443, 20);
            this.txtResult.TabIndex = 0;
            // 
            // btnInvocarServico
            // 
            this.btnInvocarServico.Location = new System.Drawing.Point(24, 30);
            this.btnInvocarServico.Name = "btnInvocarServico";
            this.btnInvocarServico.Size = new System.Drawing.Size(131, 23);
            this.btnInvocarServico.TabIndex = 1;
            this.btnInvocarServico.Text = "Invocar Serviço";
            this.btnInvocarServico.UseVisualStyleBackColor = true;
            this.btnInvocarServico.Click += new System.EventHandler(this.btnInvocarServico_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 136);
            this.Controls.Add(this.btnInvocarServico);
            this.Controls.Add(this.txtResult);
            this.Name = "frmPrincipal";
            this.Text = "Cliente - WCF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnInvocarServico;
    }
}

