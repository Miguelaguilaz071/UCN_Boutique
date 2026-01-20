using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_de_Negocios;

namespace Capa_de_presentacion
{
    public partial class UC_Ventas : UserControl
    {
        CN_Compra cn_compra = new CN_Compra();
        CN_DetalleCompra cn_detalleCompra = new CN_DetalleCompra();
        CN_Usuario cn_usuario = new CN_Usuario();
        CN_Sucursal cn_sucursal = new CN_Sucursal();
        CN_MetodoDePago cn_metodoPago = new CN_MetodoDePago();
        CN_TipoPago cn_tipoPago = new CN_TipoPago();
        CN_Producto cn_producto = new CN_Producto();

        private List<DetalleVenta> detallesVenta = new List<DetalleVenta>();
        private decimal totalVenta = 0;

        public UC_Ventas()
        {
            InitializeComponent();
            CargarDatosIniciales();
            ConfigurarDataGridDetalles();
            modoLectura();
        }

        // Clase auxiliar para manejar los detalles de venta
        private class DetalleVenta
        {
            public int IdProducto { get; set; }
            public string NombreProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal { get; set; }
        }

        // Cargas iniciales
        private void CargarDatosIniciales()
        {
            CargarUsuarios();
            CargarSucursales();
            CargarTiposPago();
            CargarProductos();
            CargarCompras();
        }

        private void CargarUsuarios()
        {
            DataTable usuarios = cn_usuario.mostrarUsuario();
            cmbUsuario.DataSource = usuarios;
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "Id_usuario";
            cmbUsuario.SelectedIndex = -1;
        }

        private void CargarSucursales()
        {
            DataTable sucursales = cn_sucursal.mostrarSucursal();
            cmbSucursal.DataSource = sucursales;
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id_sucursal";
            cmbSucursal.SelectedIndex = -1;
        }

        private void CargarTiposPago()
        {
            DataTable tiposPago = cn_tipoPago.MostrarTiposPago();
            cmbTipoPago.DataSource = tiposPago;
            cmbTipoPago.DisplayMember = "Nombre";
            cmbTipoPago.ValueMember = "Id_tipoPago";
            cmbTipoPago.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            DataTable productos = cn_producto.mostrarProductos();
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id_producto";
            cmbProducto.SelectedIndex = -1;
        }

        private void CargarCompras()
        {
            dataGridViewCompras.DataSource = null;
            dataGridViewCompras.DataSource = cn_compra.MostrarCompra();

            if (dataGridViewCompras.Columns.Count > 0)
            {
                dataGridViewCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ConfigurarDataGridDetalles()
        {
            dataGridViewDetalles.AutoGenerateColumns = false;
            dataGridViewDetalles.Columns.Clear();

            dataGridViewDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Producto",
                Name = "NombreProducto",
                ReadOnly = true
            });

            dataGridViewDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Name = "Cantidad",
                ReadOnly = true
            });

            dataGridViewDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioUnitario",
                HeaderText = "Precio Unit.",
                Name = "PrecioUnitario",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dataGridViewDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Subtotal",
                HeaderText = "Subtotal",
                Name = "Subtotal",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            // Columna de acciones (eliminar item)
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Name = "btnEliminarItem",
                Text = "Quitar",
                UseColumnTextForButtonValue = true
            };
            dataGridViewDetalles.Columns.Add(btnEliminar);
        }

        // Modos
        enum EstadoFormulario
        {
            Lectura,
            Nueva
        }
        EstadoFormulario estado = EstadoFormulario.Lectura;

        private void modoLectura()
        {
            // Deshabilitar controles
            cmbUsuario.Enabled = false;
            cmbSucursal.Enabled = false;
            cmbTipoPago.Enabled = false;
            cmbProducto.Enabled = false;
            txtCantidad.Enabled = false;
            btnAgregarProducto.Enabled = false;

            // Limpiar detalles
            detallesVenta.Clear();
            dataGridViewDetalles.DataSource = null;
            ActualizarTotal();
        }

        private void modoNuevaVenta()
        {
            // Habilitar controles
            cmbUsuario.Enabled = true;
            cmbSucursal.Enabled = true;
            cmbTipoPago.Enabled = true;
            cmbProducto.Enabled = true;
            txtCantidad.Enabled = true;
            btnAgregarProducto.Enabled = true;
        }

        private void vaciarCampos()
        {
            cmbUsuario.SelectedIndex = -1;
            cmbSucursal.SelectedIndex = -1;
            cmbTipoPago.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            txtCantidad.Clear();
            detallesVenta.Clear();
            dataGridViewDetalles.DataSource = null;
            ActualizarTotal();
        }

        // Botones principales
        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            estado = EstadoFormulario.Nueva;
            vaciarCampos();
            modoNuevaVenta();
            MessageBox.Show("Complete los datos de la venta y agregue productos.\nLuego haga clic en 'Registrar Venta'.");
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Validar producto y cantidad
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0.");
                return;
            }

            try
            {
                // Obtener datos del producto
                int idProducto = Convert.ToInt32(cmbProducto.SelectedValue);
                string nombreProducto = cmbProducto.Text;

                // Buscar precio en la tabla de productos
                DataTable productos = (DataTable)cmbProducto.DataSource;
                DataRow[] rows = productos.Select($"Id_producto = {idProducto}");

                if (rows.Length == 0)
                {
                    MessageBox.Show("Error al obtener información del producto.");
                    return;
                }

                decimal precioUnitario = Convert.ToDecimal(rows[0]["Precio"]);
                decimal subtotal = cantidad * precioUnitario;

                // Verificar si el producto ya está en la lista
                var detalleExistente = detallesVenta.FirstOrDefault(d => d.IdProducto == idProducto);
                if (detalleExistente != null)
                {
                    // Actualizar cantidad
                    detalleExistente.Cantidad += cantidad;
                    detalleExistente.Subtotal = detalleExistente.Cantidad * detalleExistente.PrecioUnitario;
                }
                else
                {
                    // Agregar nuevo detalle
                    detallesVenta.Add(new DetalleVenta
                    {
                        IdProducto = idProducto,
                        NombreProducto = nombreProducto,
                        Cantidad = cantidad,
                        PrecioUnitario = precioUnitario,
                        Subtotal = subtotal
                    });
                }

                // Actualizar DataGrid
                ActualizarDataGridDetalles();
                ActualizarTotal();

                // Limpiar selección
                cmbProducto.SelectedIndex = -1;
                txtCantidad.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto: " + ex.Message);
            }
        }

        private void ActualizarDataGridDetalles()
        {
            dataGridViewDetalles.DataSource = null;
            dataGridViewDetalles.DataSource = detallesVenta.ToList();
        }

        private void ActualizarTotal()
        {
            totalVenta = detallesVenta.Sum(d => d.Subtotal);
            lblTotalValor.Text = totalVenta.ToString("C2");
        }

        private void dataGridViewDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en el botón de eliminar
            if (e.ColumnIndex == dataGridViewDetalles.Columns["btnEliminarItem"].Index && e.RowIndex >= 0)
            {
                if (estado == EstadoFormulario.Nueva)
                {
                    DialogResult resultado = MessageBox.Show(
                        "¿Desea quitar este producto de la venta?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        detallesVenta.RemoveAt(e.RowIndex);
                        ActualizarDataGridDetalles();
                        ActualizarTotal();
                    }
                }
            }
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (estado != EstadoFormulario.Nueva)
            {
                MessageBox.Show("Debe hacer clic en 'Nueva Venta' primero.");
                return;
            }

            // Validar datos principales
            if (cmbUsuario.SelectedIndex == -1 ||
                cmbSucursal.SelectedIndex == -1 ||
                cmbTipoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los datos de la venta.");
                return;
            }

            // Validar que haya productos
            if (detallesVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta.");
                return;
            }

            try
            {
                // Obtener datos
                int idUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);
                int idSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
                int idTipoPago = Convert.ToInt32(cmbTipoPago.SelectedValue);

                // Generar token único para el método de pago
                string token = Guid.NewGuid().ToString();

                // Crear método de pago
                cn_metodoPago.AgregarMetodoPago(idUsuario, idTipoPago, token);

                // Obtener el ID del método de pago recién creado
                DataTable metodosPago = cn_metodoPago.MostrarMetodosPago();
                if (metodosPago.Rows.Count > 0)
                {
                    // Buscar el método de pago con el token que acabamos de crear
                    DataRow[] metodosEncontrados = metodosPago.Select($"Token = '{token}'");

                    if (metodosEncontrados.Length > 0)
                    {
                        int idMetodoPago = Convert.ToInt32(metodosEncontrados[0]["Id_metodoPago"]);

                        // Registrar compra
                        cn_compra.AgregarCompra(idUsuario, idSucursal, idMetodoPago);

                        // Obtener el ID de la última compra
                        DataTable ultimaCompra = cn_compra.MostrarCompra();
                        if (ultimaCompra.Rows.Count > 0)
                        {
                            // Obtener la última compra
                            int idCompra = Convert.ToInt32(ultimaCompra.Rows[ultimaCompra.Rows.Count - 1]["Id_compra"]);

                            // Registrar detalles
                            foreach (var detalle in detallesVenta)
                            {
                                cn_detalleCompra.AgregarDetalleCompra(
                                    idCompra,
                                    detalle.IdProducto,
                                    idSucursal,
                                    detalle.Cantidad,
                                    Convert.ToDouble(detalle.PrecioUnitario)
                                );
                            }

                            MessageBox.Show($"Venta registrada exitosamente.\n\n" +
                                          $"ID Compra: {idCompra}\n" +
                                          $"Total: {totalVenta:C2}\n" +
                                          $"Productos: {detallesVenta.Count}\n" +
                                          $"Token de pago: {token.Substring(0, 8)}...",
                                          "Venta Exitosa",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);

                            // Recargar datos y volver a modo lectura
                            CargarCompras();
                            vaciarCampos();
                            modoLectura();
                            estado = EstadoFormulario.Lectura;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: No se pudo obtener el método de pago creado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta: " + ex.Message +
                              "\n\nVerifique que hay suficiente stock en la sucursal seleccionada.",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra para ver sus detalles.");
                return;
            }

            try
            {
                int idCompra = Convert.ToInt32(dataGridViewCompras.CurrentRow.Cells["Id_compra"].Value);
                DataTable detalles = cn_detalleCompra.mostrarDetallesporCompra();

                // Filtrar por ID de compra
                DataView dv = detalles.DefaultView;
                dv.RowFilter = $"Id_compra = {idCompra}";

                if (dv.Count == 0)
                {
                    MessageBox.Show("No se encontraron detalles para esta compra.");
                    return;
                }

                // Mostrar detalles en un mensaje
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Detalles de la Compra #{idCompra}");
                sb.AppendLine(new string('-', 50));

                decimal total = 0;
                foreach (DataRowView row in dv)
                {
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    decimal precioUnit = Convert.ToDecimal(row["PrecioUnitario"]);
                    decimal subtotal = Convert.ToDecimal(row["Subtotal"]);

                    sb.AppendLine($"Producto ID: {row["Id_producto"]}");
                    sb.AppendLine($"Cantidad: {cantidad}");
                    sb.AppendLine($"Precio Unit.: {precioUnit:C2}");
                    sb.AppendLine($"Subtotal: {subtotal:C2}");
                    sb.AppendLine(new string('-', 30));

                    total += subtotal;
                }

                sb.AppendLine($"\nTOTAL: {total:C2}");

                MessageBox.Show(sb.ToString(), "Detalles de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (estado == EstadoFormulario.Nueva)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Desea cancelar la venta actual?\nSe perderán todos los productos agregados.",
                    "Confirmar Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    vaciarCampos();
                    modoLectura();
                    estado = EstadoFormulario.Lectura;
                    MessageBox.Show("Venta cancelada.");
                }
            }
        }
    }
}
