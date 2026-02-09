using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Capa_de_Negocios;

namespace Capa_de_presentacion
{
    public partial class UC_Tienda : UserControl
    {
        CN_Categoria cn_categoria = new CN_Categoria();
        CN_Producto cn_producto = new CN_Producto();
        CN_InventarioSucursal cn_inventario = new CN_InventarioSucursal();
        CN_Sucursal cn_sucursal = new CN_Sucursal();
        CN_Compra cn_compra = new CN_Compra();
        CN_DetalleCompra cn_detalleCompra = new CN_DetalleCompra();

        DataTable CategoriaProductos = new DataTable();
        DataTable ProductosBuscados = new DataTable();
        bool presionado;
        decimal resta;
        int fila;
        int stock;
        string stockOriginal;
        string id = "";
        decimal total = 0;

        public class ProductoCarrito
        {
            public string Id_producto { get; set; }
            public string Nombre { get; set; }
            public string Subtotal { get; set; }
            public string Cantidad { get; set; }
        }
        List<ProductoCarrito> listaCarrito = new List<ProductoCarrito>();

        public UC_Tienda()
        {
            InitializeComponent();
            ConfigurarDataGridCarrito();
            btnCamisa_Click(null, null);
            panelCarrito.Visible = false;
            CargarSucursales();
        }

        private void ConfigurarDataGridCarrito()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Producto",
                Name = "Nombre",
                ReadOnly = true,
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cant.",
                Name = "Cantidad",
                ReadOnly = true,
                Width = 50
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Subtotal",
                HeaderText = "Subtotal",
                Name = "Subtotal",
                ReadOnly = true,
                Width = 80
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id_producto",
                HeaderText = "Id_producto",
                Name = "Id_producto",
                Visible = false
            });
        }

        private void CargarSucursales()
        {
            DataTable sucursales = cn_sucursal.mostrarSucursal();
            cmbSucursal.DataSource = sucursales;
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id_sucursal";
            cmbSucursal.SelectedIndex = -1;
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            if (panelCarrito.Visible == false)
            {
                panelCarrito.Visible = true;
                panelCarrito.BringToFront();
            }
            else
            {
                panelCarrito.Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbSucursal.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione una sucursal antes de agregar productos.");
                return;
            }

            txtCantidad_TextChanged(null, null);
            AgregarCarrito();
            StockActual();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Por favor escriba el nombre del producto");
                return;
            }

            id = "";
            fila = 0;
            CategoriaProductos.Reset();
            ProductosBuscados.Reset();

            // Buscar productos por nombre
            DataTable todosProductos = cn_producto.mostrarProductos();
            ProductosBuscados = todosProductos.Clone();

            foreach (DataRow row in todosProductos.Rows)
            {
                if (row["Nombre"].ToString().ToLower().Contains(txtBuscar.Text.ToLower()))
                {
                    ProductosBuscados.ImportRow(row);
                }
            }

            if (ProductosBuscados.Rows.Count > 0)
            {
                MostrarProductoActual();
                return;
            }
            MessageBox.Show("No se encontro el producto");
        }

        private void CargarCategoria(string categoriaId)
        {
            id = "";
            fila = 0;
            ProductosBuscados.Reset();
            CategoriaProductos.Reset();

            DataTable todosProductos = cn_producto.mostrarProductos();
            CategoriaProductos = todosProductos.Clone();

            foreach (DataRow row in todosProductos.Rows)
            {
                if (row["Id_categoria"].ToString() == categoriaId)
                {
                    CategoriaProductos.ImportRow(row);
                }
            }

            if (CategoriaProductos.Rows.Count > 0)
            {
                MostrarProductoActual();
            }
            else
            {
                MessageBox.Show("No hay productos en esta categoría");
            }
        }

        private void MostrarProductoActual()
        {
            try
            {
                DataTable tablaActual = ProductosBuscados.Rows.Count > 0 ? ProductosBuscados : CategoriaProductos;

                if (tablaActual.Rows.Count == 0)
                {
                    MessageBox.Show("No hay productos disponibles");
                    return;
                }

                txtPrecio.Text = tablaActual.Rows[fila]["Precio"].ToString();
                txtDescripcion.Text = tablaActual.Rows[fila]["Descripcion"].ToString();
                txtNombre.Text = tablaActual.Rows[fila]["Nombre"].ToString();
                id = tablaActual.Rows[fila]["Id_producto"].ToString();

                // Cargar imagen
                if (tablaActual.Rows[fila]["imagen"] != DBNull.Value)
                {
                    byte[] imageByte = (byte[])tablaActual.Rows[fila]["imagen"];
                    using (MemoryStream ms = new MemoryStream(imageByte))
                    {
                        pbProducto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbProducto.Image = null;
                }

                stock = StockActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar producto: " + ex.Message);
            }
        }

        private void flechaDerecha_Click(object sender, EventArgs e)
        {
            DataTable tablaActual = ProductosBuscados.Rows.Count > 0 ? ProductosBuscados : CategoriaProductos;

            if (tablaActual.Rows.Count > 0)
            {
                if (fila < tablaActual.Rows.Count - 1)
                {
                    fila++;
                    MostrarProductoActual();
                }
            }
        }

        private void flechaIzquierda_Click(object sender, EventArgs e)
        {
            DataTable tablaActual = ProductosBuscados.Rows.Count > 0 ? ProductosBuscados : CategoriaProductos;

            if (tablaActual.Rows.Count > 0)
            {
                if (fila > 0)
                {
                    fila--;
                    MostrarProductoActual();
                }
            }
        }

        private void btnCamisa_Click(object sender, EventArgs e)
        {
            CargarCategoria("1");
        }

        private void btnPantalon_Click(object sender, EventArgs e)
        {
            CargarCategoria("2");
        }

        private void btnVestido_Click(object sender, EventArgs e)
        {
            CargarCategoria("3");
        }

        private void btnShort_Click(object sender, EventArgs e)
        {
            CargarCategoria("4");
        }

        private void btnChaqueta_Click(object sender, EventArgs e)
        {
            CargarCategoria("5");
        }

        private void btnCalzado_Click(object sender, EventArgs e)
        {
            CargarCategoria("6");
        }

        private void btnRopaInterior_Click(object sender, EventArgs e)
        {
            CargarCategoria("7");
        }

        private decimal totalProducto(decimal precio, string entrada, int stock)
        {
            decimal total = 0;
            int n = 0;
            if (int.TryParse(entrada, out n) && n <= stock && n > 0)
            {
                stock = n;
                total = n * precio;
            }
            return total;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                return;
            }

            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            string entrada = txtCantidad.Text;

            decimal retorno = totalProducto(precio, entrada, stock);
            if (retorno != 0)
            {
                txtTotal.Text = retorno.ToString("C2");
            }
            else
            {
                txtTotal.Text = "Ingrese una cantidad valida";
            }
        }

        private void AgregarCarrito()
        {
            string totalProducto = txtTotal.Text;
            string cantidad = txtCantidad.Text;
            string nombre = txtNombre.Text;

            if (calcularTotal(totalProducto))
            {
                foreach (ProductoCarrito p in listaCarrito)
                {
                    if (p.Id_producto == id)
                    {
                        int NuevaCantidad = Convert.ToInt32(p.Cantidad);
                        NuevaCantidad = NuevaCantidad + Convert.ToInt32(cantidad);
                        p.Cantidad = NuevaCantidad.ToString();
                        double NuevaSuma = NuevaCantidad * Convert.ToDouble(txtPrecio.Text);
                        p.Subtotal = NuevaSuma.ToString("C2");

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = listaCarrito;
                        return;
                    }
                }

                ProductoCarrito Prod = new ProductoCarrito();
                Prod.Id_producto = id;
                Prod.Cantidad = cantidad;
                Prod.Nombre = nombre;
                Prod.Subtotal = totalProducto;

                dataGridView1.DataSource = null;
                listaCarrito.Add(Prod);
                dataGridView1.DataSource = listaCarrito;
            }
        }

        private bool calcularTotal(string totalProducto)
        {
            try
            {
                totalProducto = totalProducto.Replace("$", "").Replace(",", "");
                decimal n = Convert.ToDecimal(totalProducto);
                total = total + n;
                txtTotalList.Text = total.ToString("C2");
                return true;
            }
            catch
            {
                MessageBox.Show("Por favor ingrese una cantidad valida");
                return false;
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            presionado = true;
            resta = 0;
            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
            id = fila.Cells["Id_producto"]?.Value?.ToString() ?? string.Empty;

            string subtotalStr = fila.Cells["Subtotal"]?.Value?.ToString() ?? "0";
            subtotalStr = subtotalStr.Replace("$", "").Replace(",", "");
            resta = Convert.ToDecimal(subtotalStr);
        }

        private void EliminarDeLista(bool presionado)
        {
            if (presionado)
            {
                ProductoCarrito productoAEliminar = listaCarrito.FirstOrDefault(p => p.Id_producto == id);

                if (productoAEliminar != null)
                {
                    listaCarrito.Remove(productoAEliminar);
                    total = total - resta;
                    txtTotalList.Text = total.ToString("C2");
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = listaCarrito;
                }
                else
                {
                    MessageBox.Show("Producto no encontrado");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione la fila del producto a eliminar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarDeLista(presionado);
            StockActual();
            presionado = false;
        }

        private int StockActual()
        {
            if (cmbSucursal.SelectedIndex == -1 || string.IsNullOrEmpty(id))
            {
                txtStock.Text = "Seleccione sucursal";
                return 0;
            }

            try
            {
                int idSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
                int idProducto = Convert.ToInt32(id);

                DataTable inventario = cn_inventario.mostrarStock();
                DataRow[] rows = inventario.Select($"Id_sucursal = {idSucursal} AND Id_producto = {idProducto}");

                if (rows.Length > 0)
                {
                    stock = Convert.ToInt32(rows[0]["StockActual"]);

                    foreach (ProductoCarrito p in listaCarrito)
                    {
                        if (p.Id_producto == id)
                        {
                            stock = stock - Convert.ToInt32(p.Cantidad);
                        }
                    }

                    txtStock.Text = stock.ToString();
                    return stock;
                }
                else
                {
                    txtStock.Text = "Sin stock";
                    stock = 0;
                    return 0;
                }
            }
            catch
            {
                txtStock.Text = "Error";
                return 0;
            }
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            StockActual();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (listaCarrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos antes de comprar.");
                return;
            }

            if (cmbSucursal.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione una sucursal.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                $"¿Confirmar compra por un total de {txtTotalList.Text}?",
                "Confirmar Compra",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // Solicitar método de pago al usuario
                    int idMetodoPago = SolicitarMetodoPago();

                    if (idMetodoPago == 0)
                    {
                        MessageBox.Show("Debe seleccionar un método de pago válido.");
                        return;
                    }

                    // Obtener el ID del usuario (asume que tienes una variable global o sesión)
                    // Por ahora usaré 1 como ejemplo, debes ajustarlo según tu sistema de login
                    int idUsuario = 1; // CAMBIAR ESTO según tu sistema de autenticación

                    int idSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);

                    // 1. Registrar la compra principal
                    cn_compra.AgregarCompra(idUsuario, idSucursal, idMetodoPago);

                    // 2. Obtener el ID de la compra recién creada
                    DataTable compras = cn_compra.MostrarCompra();
                    int idCompra = 0;
                    if (compras.Rows.Count > 0)
                    {
                        // Obtener el último ID (la compra recién insertada)
                        idCompra = Convert.ToInt32(compras.Rows[compras.Rows.Count - 1]["Id_compra"]);
                    }

                    // 3. Registrar todos los detalles de la compra
                    foreach (ProductoCarrito producto in listaCarrito)
                    {
                        int idProducto = Convert.ToInt32(producto.Id_producto);
                        int cantidad = Convert.ToInt32(producto.Cantidad);

                        // Obtener el precio del producto
                        DataTable productos = cn_producto.mostrarProductos();
                        DataRow[] productoEncontrado = productos.Select($"Id_producto = {idProducto}");

                        if (productoEncontrado.Length > 0)
                        {
                            double precioUnitario = Convert.ToDouble(productoEncontrado[0]["Precio"]);

                            // Agregar detalle de compra
                            cn_detalleCompra.AgregarDetalleCompra(
                                idCompra,
                                idProducto,
                                idSucursal,
                                cantidad,
                                precioUnitario
                            );
                        }
                    }

                    MessageBox.Show("¡Compra realizada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar carrito
                    listaCarrito.Clear();
                    total = 0;
                    txtTotalList.Text = "$0.00";
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = listaCarrito;
                    StockActual();

                    // Actualizar la visualización del producto actual
                    MostrarProductoActual();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int SolicitarMetodoPago()
        {
            // Crear un formulario simple para seleccionar método de pago
            Form formPago = new Form();
            formPago.Text = "Seleccionar Método de Pago";
            formPago.Size = new Size(350, 180);
            formPago.StartPosition = FormStartPosition.CenterParent;
            formPago.FormBorderStyle = FormBorderStyle.FixedDialog;
            formPago.MaximizeBox = false;
            formPago.MinimizeBox = false;

            Label lblMetodo = new Label();
            lblMetodo.Text = "Método de Pago:";
            lblMetodo.Location = new Point(20, 20);
            lblMetodo.Size = new Size(120, 20);

            ComboBox cmbMetodoPago = new ComboBox();
            cmbMetodoPago.Location = new Point(20, 45);
            cmbMetodoPago.Size = new Size(290, 25);
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargar métodos de pago disponibles
            CN_MetodoDePago cn_metodoPago = new CN_MetodoDePago();
            DataTable metodosPago = cn_metodoPago.MostrarMetodosPago();

            cmbMetodoPago.DataSource = metodosPago;
            cmbMetodoPago.DisplayMember = "Nombre"; // Ajusta según el nombre de columna en tu tabla
            cmbMetodoPago.ValueMember = "Id_metodoPago";
            cmbMetodoPago.SelectedIndex = -1;

            Button btnAceptar = new Button();
            btnAceptar.Text = "Aceptar";
            btnAceptar.Location = new Point(150, 90);
            btnAceptar.Size = new Size(80, 30);
            btnAceptar.DialogResult = DialogResult.OK;

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(240, 90);
            btnCancelar.Size = new Size(80, 30);
            btnCancelar.DialogResult = DialogResult.Cancel;

            formPago.Controls.Add(lblMetodo);
            formPago.Controls.Add(cmbMetodoPago);
            formPago.Controls.Add(btnAceptar);
            formPago.Controls.Add(btnCancelar);

            formPago.AcceptButton = btnAceptar;
            formPago.CancelButton = btnCancelar;

            int idMetodoPago = 0;
            if (formPago.ShowDialog() == DialogResult.OK && cmbMetodoPago.SelectedIndex != -1)
            {
                idMetodoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue);
            }

            return idMetodoPago;
        }
    }
}