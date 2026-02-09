namespace Capa_de_presentacion
{
    partial class UC_Tienda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Tienda));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCarrito = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCamisa = new System.Windows.Forms.Button();
            this.btnRopaInterior = new System.Windows.Forms.Button();
            this.btnPantalon = new System.Windows.Forms.Button();
            this.btnVestido = new System.Windows.Forms.Button();
            this.btnCalzado = new System.Windows.Forms.Button();
            this.btnShort = new System.Windows.Forms.Button();
            this.btnChaqueta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescripcion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.flechaIzquierda = new System.Windows.Forms.Button();
            this.flechaDerecha = new System.Windows.Forms.Button();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.panelCarrito = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalList = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCarrito)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            this.panelCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGreen;
            this.panel1.Controls.Add(this.btnCarrito);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 111);
            this.panel1.TabIndex = 0;
            // 
            // btnCarrito
            // 
            this.btnCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarrito.Image = ((System.Drawing.Image)(resources.GetObject("btnCarrito.Image")));
            this.btnCarrito.Location = new System.Drawing.Point(820, 24);
            this.btnCarrito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCarrito.Name = "btnCarrito";
            this.btnCarrito.Size = new System.Drawing.Size(40, 32);
            this.btnCarrito.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCarrito.TabIndex = 22;
            this.btnCarrito.TabStop = false;
            this.btnCarrito.Click += new System.EventHandler(this.btnCarrito_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.Controls.Add(this.btnCamisa);
            this.panel3.Controls.Add(this.btnRopaInterior);
            this.panel3.Controls.Add(this.btnPantalon);
            this.panel3.Controls.Add(this.btnVestido);
            this.panel3.Controls.Add(this.btnCalzado);
            this.panel3.Controls.Add(this.btnShort);
            this.panel3.Controls.Add(this.btnChaqueta);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 76);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(900, 35);
            this.panel3.TabIndex = 21;
            // 
            // btnCamisa
            // 
            this.btnCamisa.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnCamisa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCamisa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCamisa.Location = new System.Drawing.Point(11, 2);
            this.btnCamisa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCamisa.Name = "btnCamisa";
            this.btnCamisa.Size = new System.Drawing.Size(100, 29);
            this.btnCamisa.TabIndex = 14;
            this.btnCamisa.Text = "Camisa";
            this.btnCamisa.UseVisualStyleBackColor = false;
            this.btnCamisa.Click += new System.EventHandler(this.btnCamisa_Click);
            // 
            // btnRopaInterior
            // 
            this.btnRopaInterior.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnRopaInterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRopaInterior.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRopaInterior.Location = new System.Drawing.Point(768, 0);
            this.btnRopaInterior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRopaInterior.Name = "btnRopaInterior";
            this.btnRopaInterior.Size = new System.Drawing.Size(120, 30);
            this.btnRopaInterior.TabIndex = 20;
            this.btnRopaInterior.Text = "Ropa Interior";
            this.btnRopaInterior.UseVisualStyleBackColor = false;
            this.btnRopaInterior.Click += new System.EventHandler(this.btnRopaInterior_Click);
            // 
            // btnPantalon
            // 
            this.btnPantalon.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnPantalon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPantalon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPantalon.Location = new System.Drawing.Point(136, 1);
            this.btnPantalon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPantalon.Name = "btnPantalon";
            this.btnPantalon.Size = new System.Drawing.Size(105, 30);
            this.btnPantalon.TabIndex = 15;
            this.btnPantalon.Text = "Pantalón";
            this.btnPantalon.UseVisualStyleBackColor = false;
            this.btnPantalon.Click += new System.EventHandler(this.btnPantalon_Click);
            // 
            // btnVestido
            // 
            this.btnVestido.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnVestido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVestido.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnVestido.Location = new System.Drawing.Point(263, 2);
            this.btnVestido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVestido.Name = "btnVestido";
            this.btnVestido.Size = new System.Drawing.Size(100, 29);
            this.btnVestido.TabIndex = 16;
            this.btnVestido.Text = "Vestido";
            this.btnVestido.UseVisualStyleBackColor = false;
            this.btnVestido.Click += new System.EventHandler(this.btnVestido_Click);
            // 
            // btnCalzado
            // 
            this.btnCalzado.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnCalzado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalzado.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCalzado.Location = new System.Drawing.Point(643, 2);
            this.btnCalzado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalzado.Name = "btnCalzado";
            this.btnCalzado.Size = new System.Drawing.Size(100, 29);
            this.btnCalzado.TabIndex = 19;
            this.btnCalzado.Text = "Calzado";
            this.btnCalzado.UseVisualStyleBackColor = false;
            this.btnCalzado.Click += new System.EventHandler(this.btnCalzado_Click);
            // 
            // btnShort
            // 
            this.btnShort.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnShort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShort.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnShort.Location = new System.Drawing.Point(388, 2);
            this.btnShort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShort.Name = "btnShort";
            this.btnShort.Size = new System.Drawing.Size(100, 29);
            this.btnShort.TabIndex = 17;
            this.btnShort.Text = "Short";
            this.btnShort.UseVisualStyleBackColor = false;
            this.btnShort.Click += new System.EventHandler(this.btnShort_Click);
            // 
            // btnChaqueta
            // 
            this.btnChaqueta.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnChaqueta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChaqueta.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnChaqueta.Location = new System.Drawing.Point(511, 2);
            this.btnChaqueta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChaqueta.Name = "btnChaqueta";
            this.btnChaqueta.Size = new System.Drawing.Size(105, 29);
            this.btnChaqueta.TabIndex = 18;
            this.btnChaqueta.Text = "Chaqueta";
            this.btnChaqueta.UseVisualStyleBackColor = false;
            this.btnChaqueta.Click += new System.EventHandler(this.btnChaqueta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 76);
            this.label1.TabIndex = 15;
            this.label1.Text = "¡Bienvenido a \r\nUCN Boutique!";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.Location = new System.Drawing.Point(643, 24);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 30);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtBuscar.Location = new System.Drawing.Point(276, 24);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(320, 27);
            this.txtBuscar.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.flechaIzquierda);
            this.panel2.Controls.Add(this.flechaDerecha);
            this.panel2.Controls.Add(this.pbProducto);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 111);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 389);
            this.panel2.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic);
            this.txtDescripcion.Location = new System.Drawing.Point(418, 292);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(353, 74);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.Text = "Cargando...";
            this.txtDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtNombre.Location = new System.Drawing.Point(417, 12);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(353, 24);
            this.txtNombre.TabIndex = 8;
            this.txtNombre.Text = "Producto";
            this.txtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(422, 216);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(353, 74);
            this.panel7.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.btnAgregar);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(293, 389);
            this.panel4.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cmbSucursal);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtStock);
            this.panel5.Controls.Add(this.txtPrecio);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.txtTotal);
            this.panel5.Controls.Add(this.txtCantidad);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(11, 40);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(268, 281);
            this.panel5.TabIndex = 7;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(18, 32);
            this.cmbSucursal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(236, 25);
            this.cmbSucursal.TabIndex = 18;
            this.cmbSucursal.SelectedIndexChanged += new System.EventHandler(this.cmbSucursal_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(19, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "Sucursal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(19, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Cantidad en stock:";
            // 
            // txtStock
            // 
            this.txtStock.AutoSize = true;
            this.txtStock.ForeColor = System.Drawing.Color.Coral;
            this.txtStock.Location = new System.Drawing.Point(142, 123);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(12, 16);
            this.txtStock.TabIndex = 15;
            this.txtStock.Text = "*";
            // 
            // txtPrecio
            // 
            this.txtPrecio.AutoSize = true;
            this.txtPrecio.ForeColor = System.Drawing.Color.Coral;
            this.txtPrecio.Location = new System.Drawing.Point(16, 174);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(76, 16);
            this.txtPrecio.TabIndex = 14;
            this.txtPrecio.Text = "Cargando...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(15, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Precio unitario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(15, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.ForeColor = System.Drawing.Color.Coral;
            this.txtTotal.Location = new System.Drawing.Point(15, 232);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(172, 16);
            this.txtTotal.TabIndex = 11;
            this.txtTotal.Text = "Ingrese una cantidad valida";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Arial", 10.2F);
            this.txtCantidad.Location = new System.Drawing.Point(18, 93);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(236, 27);
            this.txtCantidad.TabIndex = 9;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(18, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cantidad";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Yellow;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.Location = new System.Drawing.Point(0, 357);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(291, 30);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar al carrito";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(56, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detalles de la compra";
            // 
            // flechaIzquierda
            // 
            this.flechaIzquierda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flechaIzquierda.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.flechaIzquierda.Location = new System.Drawing.Point(336, 117);
            this.flechaIzquierda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flechaIzquierda.Name = "flechaIzquierda";
            this.flechaIzquierda.Size = new System.Drawing.Size(60, 48);
            this.flechaIzquierda.TabIndex = 4;
            this.flechaIzquierda.Text = "◄";
            this.flechaIzquierda.UseVisualStyleBackColor = true;
            this.flechaIzquierda.Click += new System.EventHandler(this.flechaIzquierda_Click);
            // 
            // flechaDerecha
            // 
            this.flechaDerecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flechaDerecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.flechaDerecha.Location = new System.Drawing.Point(800, 117);
            this.flechaDerecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flechaDerecha.Name = "flechaDerecha";
            this.flechaDerecha.Size = new System.Drawing.Size(60, 48);
            this.flechaDerecha.TabIndex = 3;
            this.flechaDerecha.Text = "►";
            this.flechaDerecha.UseVisualStyleBackColor = true;
            this.flechaDerecha.Click += new System.EventHandler(this.flechaDerecha_Click);
            // 
            // pbProducto
            // 
            this.pbProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProducto.Location = new System.Drawing.Point(422, 54);
            this.pbProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(353, 160);
            this.pbProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProducto.TabIndex = 0;
            this.pbProducto.TabStop = false;
            // 
            // panelCarrito
            // 
            this.panelCarrito.BackColor = System.Drawing.Color.LightCyan;
            this.panelCarrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCarrito.Controls.Add(this.label8);
            this.panelCarrito.Controls.Add(this.txtTotalList);
            this.panelCarrito.Controls.Add(this.btnEliminar);
            this.panelCarrito.Controls.Add(this.btnComprar);
            this.panelCarrito.Controls.Add(this.label7);
            this.panelCarrito.Controls.Add(this.dataGridView1);
            this.panelCarrito.Location = new System.Drawing.Point(440, 60);
            this.panelCarrito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCarrito.Name = "panelCarrito";
            this.panelCarrito.Size = new System.Drawing.Size(420, 200);
            this.panelCarrito.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(13, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Total:";
            // 
            // txtTotalList
            // 
            this.txtTotalList.AutoSize = true;
            this.txtTotalList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotalList.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtTotalList.Location = new System.Drawing.Point(76, 156);
            this.txtTotalList.Name = "txtTotalList";
            this.txtTotalList.Size = new System.Drawing.Size(54, 20);
            this.txtTotalList.TabIndex = 3;
            this.txtTotalList.Text = "$0.00";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(280, 152);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnComprar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComprar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnComprar.ForeColor = System.Drawing.Color.White;
            this.btnComprar.Location = new System.Drawing.Point(154, 152);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(120, 30);
            this.btnComprar.TabIndex = 5;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = false;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(150, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tu Carrito";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 36);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(385, 108);
            this.dataGridView1.TabIndex = 0;
            // 
            // UC_Tienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCarrito);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Tienda";
            this.Size = new System.Drawing.Size(900, 500);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCarrito)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            this.panelCarrito.ResumeLayout(false);
            this.panelCarrito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.Button flechaDerecha;
        private System.Windows.Forms.Button flechaIzquierda;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtPrecio;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCamisa;
        private System.Windows.Forms.Button btnPantalon;
        private System.Windows.Forms.Button btnVestido;
        private System.Windows.Forms.Button btnShort;
        private System.Windows.Forms.Button btnChaqueta;
        private System.Windows.Forms.Button btnCalzado;
        private System.Windows.Forms.Button btnRopaInterior;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label txtDescripcion;
        private System.Windows.Forms.Label txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtStock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.PictureBox btnCarrito;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelCarrito;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtTotalList;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}