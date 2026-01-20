namespace Capa_de_presentacion
{
    partial class UC_Ventas
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxProductos = new System.Windows.Forms.GroupBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxDatosVenta = new System.Windows.Forms.GroupBox();
            this.cmbTipoPago = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxDetalles = new System.Windows.Forms.GroupBox();
            this.dataGridViewDetalles = new System.Windows.Forms.DataGridView();
            this.groupBoxHistorial = new System.Windows.Forms.GroupBox();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.dataGridViewCompras = new System.Windows.Forms.DataGridView();
            this.panelSuperior.SuspendLayout();
            this.panelOpciones.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.groupBoxProductos.SuspendLayout();
            this.groupBoxDatosVenta.SuspendLayout();
            this.panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).BeginInit();
            this.groupBoxHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.Controls.Add(this.panelOpciones);
            this.panelSuperior.Controls.Add(this.panelTotal);
            this.panelSuperior.Controls.Add(this.groupBoxProductos);
            this.panelSuperior.Controls.Add(this.groupBoxDatosVenta);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1032, 200);
            this.panelSuperior.TabIndex = 0;
            // 
            // panelOpciones
            // 
            this.panelOpciones.Controls.Add(this.btnCancelar);
            this.panelOpciones.Controls.Add(this.btnRegistrarVenta);
            this.panelOpciones.Controls.Add(this.btnNuevaVenta);
            this.panelOpciones.Controls.Add(this.label8);
            this.panelOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOpciones.Location = new System.Drawing.Point(820, 0);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(212, 200);
            this.panelOpciones.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(15, 150);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(180, 35);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarVenta.Location = new System.Drawing.Point(15, 100);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(180, 35);
            this.btnRegistrarVenta.TabIndex = 2;
            this.btnRegistrarVenta.Text = "💾 Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevaVenta.Location = new System.Drawing.Point(15, 50);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(180, 35);
            this.btnNuevaVenta.TabIndex = 1;
            this.btnNuevaVenta.Text = "➕ Nueva Venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = false;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(11, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Opciones";
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotal.Controls.Add(this.lblTotalValor);
            this.panelTotal.Controls.Add(this.label7);
            this.panelTotal.Location = new System.Drawing.Point(620, 10);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(190, 80);
            this.panelTotal.TabIndex = 2;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.Green;
            this.lblTotalValor.Location = new System.Drawing.Point(5, 35);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(180, 35);
            this.lblTotalValor.TabIndex = 1;
            this.lblTotalValor.Text = "$0.00";
            this.lblTotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(55, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "TOTAL";
            // 
            // groupBoxProductos
            // 
            this.groupBoxProductos.Controls.Add(this.btnAgregarProducto);
            this.groupBoxProductos.Controls.Add(this.txtCantidad);
            this.groupBoxProductos.Controls.Add(this.label5);
            this.groupBoxProductos.Controls.Add(this.cmbProducto);
            this.groupBoxProductos.Controls.Add(this.label4);
            this.groupBoxProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxProductos.Location = new System.Drawing.Point(315, 10);
            this.groupBoxProductos.Name = "groupBoxProductos";
            this.groupBoxProductos.Size = new System.Drawing.Size(290, 180);
            this.groupBoxProductos.TabIndex = 1;
            this.groupBoxProductos.TabStop = false;
            this.groupBoxProductos.Text = "Agregar Productos";
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.LightGreen;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProducto.Location = new System.Drawing.Point(15, 130);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(260, 35);
            this.btnAgregarProducto.TabIndex = 4;
            this.btnAgregarProducto.Text = "➕ Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCantidad.Location = new System.Drawing.Point(15, 95);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(260, 26);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cantidad:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(15, 45);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(260, 25);
            this.cmbProducto.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Producto:";
            // 
            // groupBoxDatosVenta
            // 
            this.groupBoxDatosVenta.Controls.Add(this.cmbTipoPago);
            this.groupBoxDatosVenta.Controls.Add(this.label3);
            this.groupBoxDatosVenta.Controls.Add(this.cmbSucursal);
            this.groupBoxDatosVenta.Controls.Add(this.label2);
            this.groupBoxDatosVenta.Controls.Add(this.cmbUsuario);
            this.groupBoxDatosVenta.Controls.Add(this.label1);
            this.groupBoxDatosVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxDatosVenta.Location = new System.Drawing.Point(10, 10);
            this.groupBoxDatosVenta.Name = "groupBoxDatosVenta";
            this.groupBoxDatosVenta.Size = new System.Drawing.Size(290, 180);
            this.groupBoxDatosVenta.TabIndex = 0;
            this.groupBoxDatosVenta.TabStop = false;
            this.groupBoxDatosVenta.Text = "Datos de la Venta";
            // 
            // cmbTipoPago
            // 
            this.cmbTipoPago.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbTipoPago.FormattingEnabled = true;
            this.cmbTipoPago.Location = new System.Drawing.Point(15, 140);
            this.cmbTipoPago.Name = "cmbTipoPago";
            this.cmbTipoPago.Size = new System.Drawing.Size(260, 25);
            this.cmbTipoPago.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Pago:";
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(15, 90);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(260, 25);
            this.cmbSucursal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sucursal:";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(15, 40);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(260, 25);
            this.cmbUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // panelCentral
            // 
            this.panelCentral.Controls.Add(this.splitContainer1);
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(0, 200);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(1032, 281);
            this.panelCentral.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxDetalles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxHistorial);
            this.splitContainer1.Size = new System.Drawing.Size(1032, 281);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxDetalles
            // 
            this.groupBoxDetalles.Controls.Add(this.dataGridViewDetalles);
            this.groupBoxDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetalles.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDetalles.Name = "groupBoxDetalles";
            this.groupBoxDetalles.Size = new System.Drawing.Size(1032, 135);
            this.groupBoxDetalles.TabIndex = 0;
            this.groupBoxDetalles.TabStop = false;
            this.groupBoxDetalles.Text = "Productos de la Venta Actual";
            // 
            // dataGridViewDetalles
            // 
            this.dataGridViewDetalles.AllowUserToAddRows = false;
            this.dataGridViewDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetalles.Location = new System.Drawing.Point(3, 20);
            this.dataGridViewDetalles.Name = "dataGridViewDetalles";
            this.dataGridViewDetalles.RowHeadersWidth = 51;
            this.dataGridViewDetalles.RowTemplate.Height = 24;
            this.dataGridViewDetalles.Size = new System.Drawing.Size(1026, 112);
            this.dataGridViewDetalles.TabIndex = 0;
            this.dataGridViewDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetalles_CellContentClick);
            // 
            // groupBoxHistorial
            // 
            this.groupBoxHistorial.Controls.Add(this.btnVerDetalles);
            this.groupBoxHistorial.Controls.Add(this.dataGridViewCompras);
            this.groupBoxHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxHistorial.Location = new System.Drawing.Point(0, 0);
            this.groupBoxHistorial.Name = "groupBoxHistorial";
            this.groupBoxHistorial.Size = new System.Drawing.Size(1032, 142);
            this.groupBoxHistorial.TabIndex = 0;
            this.groupBoxHistorial.TabStop = false;
            this.groupBoxHistorial.Text = "Historial de Ventas (Solo Lectura)";
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalles.BackColor = System.Drawing.Color.LightBlue;
            this.btnVerDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerDetalles.Location = new System.Drawing.Point(860, 15);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(160, 30);
            this.btnVerDetalles.TabIndex = 1;
            this.btnVerDetalles.Text = "📋 Ver Detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = false;
            this.btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);
            // 
            // dataGridViewCompras
            // 
            this.dataGridViewCompras.AllowUserToAddRows = false;
            this.dataGridViewCompras.AllowUserToDeleteRows = false;
            this.dataGridViewCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCompras.Location = new System.Drawing.Point(3, 20);
            this.dataGridViewCompras.Name = "dataGridViewCompras";
            this.dataGridViewCompras.ReadOnly = true;
            this.dataGridViewCompras.RowHeadersWidth = 51;
            this.dataGridViewCompras.RowTemplate.Height = 24;
            this.dataGridViewCompras.Size = new System.Drawing.Size(1026, 119);
            this.dataGridViewCompras.TabIndex = 0;
            // 
            // UC_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panelSuperior);
            this.Name = "UC_Ventas";
            this.Size = new System.Drawing.Size(1032, 481);
            this.panelSuperior.ResumeLayout(false);
            this.panelOpciones.ResumeLayout(false);
            this.panelOpciones.PerformLayout();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.groupBoxProductos.ResumeLayout(false);
            this.groupBoxProductos.PerformLayout();
            this.groupBoxDatosVenta.ResumeLayout(false);
            this.groupBoxDatosVenta.PerformLayout();
            this.panelCentral.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxDetalles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).EndInit();
            this.groupBoxHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.GroupBox groupBoxDatosVenta;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxProductos;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxDetalles;
        private System.Windows.Forms.DataGridView dataGridViewDetalles;
        private System.Windows.Forms.GroupBox groupBoxHistorial;
        private System.Windows.Forms.DataGridView dataGridViewCompras;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Button btnCancelar;
    }
}