namespace Capa_de_presentacion
{
    partial class Frm_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cliente));
            this.uC_Tienda1 = new Capa_de_presentacion.UC_Tienda();
            this.SuspendLayout();
            // 
            // uC_Tienda1
            // 
            this.uC_Tienda1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Tienda1.Location = new System.Drawing.Point(0, 0);
            this.uC_Tienda1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uC_Tienda1.Name = "uC_Tienda1";
            this.uC_Tienda1.Size = new System.Drawing.Size(907, 503);
            this.uC_Tienda1.TabIndex = 0;
            // 
            // Frm_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 503);
            this.Controls.Add(this.uC_Tienda1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Cliente";
            this.Text = "UCN Boutique";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_Tienda uC_Tienda1;
    }
}