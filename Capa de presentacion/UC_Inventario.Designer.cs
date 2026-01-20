namespace Capa_de_presentacion
{
    partial class UC_Inventario
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
            this.panelCampos = new System.Windows.Forms.Panel();
            this.panelAjuste = new System.Windows.Forms.Panel();
            this.lblNuevoStockValor = new System.Windows.Forms.Label();
            this.lblNuevoStock = new System.Windows.Forms.Label();
            this.lblStockActualValor = new System.Windows.Forms.Label();
            this.lblStockActual = new System.Windows.Forms.Label();
            this.rbEstablecer = new System.Windows.Forms.RadioButton();
            this.rbDisminuir = new System.Windows.Forms.RadioButton();
            this.rbAgregar = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCantidadAjuste = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAjustar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.panelInventario = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelCampos.SuspendLayout();
            this.panelAjuste.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCampos
            // 
            this.panelCampos.Controls.Add(this.panelAjuste);
            this.panelCampos.Controls.Add(this.panel1);
            this.panelCampos.Controls.Add(this.cmbProducto);
            this.panelCampos.Controls.Add(this.label4);
            this.panelCampos.Controls.Add(this.label3);
            this.panelCampos.Controls.Add(this.txtStockActual);
            this.panelCampos.Controls.Add(this.label2);
            this.panelCampos.Controls.Add(this.cmbSucursal);
            this.panelCampos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCampos.Location = new System.Drawing.Point(0, 0);
            this.panelCampos.Name = "panelCampos";
            this.panelCampos.Size = new System.Drawing.Size(1032, 230);
            this.panelCampos.TabIndex = 0;
            // 
            // panelAjuste
            // 
            this.panelAjuste.BackColor = System.Drawing.Color.LightYellow;
            this.panelAjuste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAjuste.Controls.Add(this.lblNuevoStockValor);
            this.panelAjuste.Controls.Add(this.lblNuevoStock);
            this.panelAjuste.Controls.Add(this.lblStockActualValor);
            this.panelAjuste.Controls.Add(this.lblStockActual);
            this.panelAjuste.Controls.Add(this.rbEstablecer);
            this.panelAjuste.Controls.Add(this.rbDisminuir);
            this.panelAjuste.Controls.Add(this.rbAgregar);
            this.panelAjuste.Controls.Add(this.label6);
            this.panelAjuste.Controls.Add(this.txtCantidadAjuste);
            this.panelAjuste.Controls.Add(this.label5);
            this.panelAjuste.Location = new System.Drawing.Point(30, 80);
            this.panelAjuste.Name = "panelAjuste";
            this.panelAjuste.Size = new System.Drawing.Size(620, 140);
            this.panelAjuste.TabIndex = 14;
            this.panelAjuste.Visible = false;
            // 
            // lblNuevoStockValor
            // 
            this.lblNuevoStockValor.AutoSize = true;
            this.lblNuevoStockValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblNuevoStockValor.ForeColor = System.Drawing.Color.Green;
            this.lblNuevoStockValor.Location = new System.Drawing.Point(530, 100);
            this.lblNuevoStockValor.Name = "lblNuevoStockValor";
            this.lblNuevoStockValor.Size = new System.Drawing.Size(27, 29);
            this.lblNuevoStockValor.TabIndex = 9;
            this.lblNuevoStockValor.Text = "0";
            // 
            // lblNuevoStock
            // 
            this.lblNuevoStock.AutoSize = true;
            this.lblNuevoStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblNuevoStock.Location = new System.Drawing.Point(390, 105);
            this.lblNuevoStock.Name = "lblNuevoStock";
            this.lblNuevoStock.Size = new System.Drawing.Size(120, 20);
            this.lblNuevoStock.TabIndex = 8;
            this.lblNuevoStock.Text = "Nuevo Stock:";
            // 
            // lblStockActualValor
            // 
            this.lblStockActualValor.AutoSize = true;
            this.lblStockActualValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblStockActualValor.Location = new System.Drawing.Point(530, 60);
            this.lblStockActualValor.Name = "lblStockActualValor";
            this.lblStockActualValor.Size = new System.Drawing.Size(27, 29);
            this.lblStockActualValor.TabIndex = 7;
            this.lblStockActualValor.Text = "0";
            // 
            // lblStockActual
            // 
            this.lblStockActual.AutoSize = true;
            this.lblStockActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblStockActual.Location = new System.Drawing.Point(390, 65);
            this.lblStockActual.Name = "lblStockActual";
            this.lblStockActual.Size = new System.Drawing.Size(121, 20);
            this.lblStockActual.TabIndex = 6;
            this.lblStockActual.Text = "Stock Actual:";
            // 
            // rbEstablecer
            // 
            this.rbEstablecer.AutoSize = true;
            this.rbEstablecer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.rbEstablecer.Location = new System.Drawing.Point(260, 95);
            this.rbEstablecer.Name = "rbEstablecer";
            this.rbEstablecer.Size = new System.Drawing.Size(106, 24);
            this.rbEstablecer.TabIndex = 5;
            this.rbEstablecer.Text = "Establecer";
            this.rbEstablecer.UseVisualStyleBackColor = true;
            this.rbEstablecer.CheckedChanged += new System.EventHandler(this.rbEstablecer_CheckedChanged);
            // 
            // rbDisminuir
            // 
            this.rbDisminuir.AutoSize = true;
            this.rbDisminuir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.rbDisminuir.Location = new System.Drawing.Point(140, 95);
            this.rbDisminuir.Name = "rbDisminuir";
            this.rbDisminuir.Size = new System.Drawing.Size(95, 24);
            this.rbDisminuir.TabIndex = 4;
            this.rbDisminuir.Text = "Disminuir";
            this.rbDisminuir.UseVisualStyleBackColor = true;
            this.rbDisminuir.CheckedChanged += new System.EventHandler(this.rbDisminuir_CheckedChanged);
            // 
            // rbAgregar
            // 
            this.rbAgregar.AutoSize = true;
            this.rbAgregar.Checked = true;
            this.rbAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.rbAgregar.Location = new System.Drawing.Point(30, 95);
            this.rbAgregar.Name = "rbAgregar";
            this.rbAgregar.Size = new System.Drawing.Size(87, 24);
            this.rbAgregar.TabIndex = 3;
            this.rbAgregar.TabStop = true;
            this.rbAgregar.Text = "Agregar";
            this.rbAgregar.UseVisualStyleBackColor = true;
            this.rbAgregar.CheckedChanged += new System.EventHandler(this.rbAgregar_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(25, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tipo de ajuste:";
            // 
            // txtCantidadAjuste
            // 
            this.txtCantidadAjuste.Font = new System.Drawing.Font("Arial Narrow", 10.2F);
            this.txtCantidadAjuste.Location = new System.Drawing.Point(30, 30);
            this.txtCantidadAjuste.Name = "txtCantidadAjuste";
            this.txtCantidadAjuste.Size = new System.Drawing.Size(150, 27);
            this.txtCantidadAjuste.TabIndex = 1;
            this.txtCantidadAjuste.TextChanged += new System.EventHandler(this.txtCantidadAjuste_TextChanged);
            this.txtCantidadAjuste.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadAjuste_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(25, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cantidad para el ajuste:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAjustar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(683, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 230);
            this.panel1.TabIndex = 13;
            // 
            // btnAjustar
            // 
            this.btnAjustar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAjustar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAjustar.Location = new System.Drawing.Point(26, 178);
            this.btnAjustar.Name = "btnAjustar";
            this.btnAjustar.Size = new System.Drawing.Size(287, 39);
            this.btnAjustar.TabIndex = 9;
            this.btnAjustar.Text = "⚙ Ajustar Stock";
            this.btnAjustar.UseVisualStyleBackColor = false;
            this.btnAjustar.Click += new System.EventHandler(this.btnAjustar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(193, 122);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 39);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(26, 122);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 39);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Opciones";
            // 
            // cmbProducto
            // 
            this.cmbProducto.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(290, 40);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(220, 28);
            this.cmbProducto.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(290, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Producto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(540, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Stock actual:";
            // 
            // txtStockActual
            // 
            this.txtStockActual.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockActual.Location = new System.Drawing.Point(540, 40);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(110, 27);
            this.txtStockActual.TabIndex = 9;
            this.txtStockActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockActual_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sucursal:";
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(30, 40);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(220, 28);
            this.cmbSucursal.TabIndex = 7;
            // 
            // panelInventario
            // 
            this.panelInventario.Controls.Add(this.dataGridView1);
            this.panelInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInventario.Location = new System.Drawing.Point(0, 230);
            this.panelInventario.Name = "panelInventario";
            this.panelInventario.Size = new System.Drawing.Size(1032, 251);
            this.panelInventario.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1032, 251);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(193, 65);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 39);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(26, 65);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 39);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // UC_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInventario);
            this.Controls.Add(this.panelCampos);
            this.Name = "UC_Inventario";
            this.Size = new System.Drawing.Size(1032, 481);
            this.panelCampos.ResumeLayout(false);
            this.panelCampos.PerformLayout();
            this.panelAjuste.ResumeLayout(false);
            this.panelAjuste.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCampos;
        private System.Windows.Forms.Panel panelInventario;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelAjuste;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantidadAjuste;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbEstablecer;
        private System.Windows.Forms.RadioButton rbDisminuir;
        private System.Windows.Forms.RadioButton rbAgregar;
        private System.Windows.Forms.Label lblStockActual;
        private System.Windows.Forms.Label lblStockActualValor;
        private System.Windows.Forms.Label lblNuevoStockValor;
        private System.Windows.Forms.Label lblNuevoStock;
        private System.Windows.Forms.Button btnAjustar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
    }
}