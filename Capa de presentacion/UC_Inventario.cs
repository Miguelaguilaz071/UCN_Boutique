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
    public partial class UC_Inventario : UserControl
    {
        CN_InventarioSucursal cn_inventario = new CN_InventarioSucursal();
        CN_Sucursal cn_sucursal = new CN_Sucursal();
        CN_Producto cn_producto = new CN_Producto();

        public UC_Inventario()
        {
            InitializeComponent();
            modoLectura();
            CargarSucursales();
            CargarProductos();
            CargarInventario();
        }

        // Cargas
        private void CargarSucursales()
        {
            DataTable sucursales = cn_sucursal.mostrarSucursal();
            cmbSucursal.DataSource = sucursales;
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id_sucursal";
            cmbSucursal.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            DataTable productos = cn_producto.mostrarProductos();
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id_producto";
            cmbProducto.SelectedIndex = -1;
        }

        private void CargarInventario()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cn_inventario.mostrarStock();

            // Personalizar encabezados para mejor visualización
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // Modos y estados
        enum EstadoFormulario
        {
            Lectura,
            Nuevo,
            Editar,
            Ajustar
        }
        EstadoFormulario estado = EstadoFormulario.Lectura;

        private void modoLectura()
        {
            btnEliminar.Enabled = true;
            btnAjustar.Enabled = true;
            cmbSucursal.Enabled = false;
            cmbProducto.Enabled = false;
            txtStockActual.Enabled = false;
            txtCantidadAjuste.Enabled = false;
            rbAgregar.Enabled = false;
            rbDisminuir.Enabled = false;
            rbEstablecer.Enabled = false;

            // Ocultar panel de ajuste
            panelAjuste.Visible = false;
            lblStockActualValor.Text = "0";
            lblNuevoStockValor.Text = "0";
        }

        private void modoEscritura()
        {
            btnEliminar.Enabled = false;
            btnAjustar.Enabled = false;
            cmbSucursal.Enabled = true;
            cmbProducto.Enabled = true;
            txtStockActual.Enabled = true;
            txtCantidadAjuste.Enabled = false;
            rbAgregar.Enabled = false;
            rbDisminuir.Enabled = false;
            rbEstablecer.Enabled = false;

            panelAjuste.Visible = false;
        }

        private void modoAjuste()
        {
            btnEliminar.Enabled = false;
            btnAjustar.Enabled = false;
            cmbSucursal.Enabled = false;
            cmbProducto.Enabled = false;
            txtStockActual.Enabled = false;
            txtCantidadAjuste.Enabled = true;
            rbAgregar.Enabled = true;
            rbDisminuir.Enabled = true;
            rbEstablecer.Enabled = true;

            panelAjuste.Visible = true;
            rbAgregar.Checked = true;
        }

        private void vaciarCampos()
        {
            cmbSucursal.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            txtStockActual.Clear();
            txtCantidadAjuste.Clear();
            rbAgregar.Checked = true;
            lblStockActualValor.Text = "0";
            lblNuevoStockValor.Text = "0";
        }

        // Validaciones
        private bool validarStock(string stock)
        {
            int resultado;
            if (int.TryParse(stock, out resultado))
            {
                return resultado >= 0;
            }
            return false;
        }

        // Cálculo de nuevo stock
        private void calcularNuevoStock()
        {
            try
            {
                int stockActual = 0;
                int cantidad = 0;

                if (estado == EstadoFormulario.Ajustar && dataGridView1.CurrentRow != null)
                {
                    stockActual = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StockActual"].Value);
                    lblStockActualValor.Text = stockActual.ToString();
                }

                if (!string.IsNullOrWhiteSpace(txtCantidadAjuste.Text))
                {
                    if (int.TryParse(txtCantidadAjuste.Text, out cantidad))
                    {
                        int nuevoStock = stockActual;

                        if (rbAgregar.Checked)
                        {
                            nuevoStock = stockActual + cantidad;
                        }
                        else if (rbDisminuir.Checked)
                        {
                            nuevoStock = stockActual - cantidad;
                            if (nuevoStock < 0)
                            {
                                lblNuevoStockValor.Text = "ERROR: Stock negativo";
                                lblNuevoStockValor.ForeColor = Color.Red;
                                return;
                            }
                        }
                        else if (rbEstablecer.Checked)
                        {
                            nuevoStock = cantidad;
                        }

                        lblNuevoStockValor.Text = nuevoStock.ToString();
                        lblNuevoStockValor.ForeColor = nuevoStock < 10 ? Color.Orange : Color.Green;
                    }
                }
                else
                {
                    lblNuevoStockValor.Text = stockActual.ToString();
                    lblNuevoStockValor.ForeColor = Color.Black;
                }
            }
            catch
            {
                lblNuevoStockValor.Text = "ERROR";
                lblNuevoStockValor.ForeColor = Color.Red;
            }
        }

        // Eventos de cambio para cálculo en tiempo real
        private void txtCantidadAjuste_TextChanged(object sender, EventArgs e)
        {
            calcularNuevoStock();
        }

        private void rbAgregar_CheckedChanged(object sender, EventArgs e)
        {
            calcularNuevoStock();
        }

        private void rbDisminuir_CheckedChanged(object sender, EventArgs e)
        {
            calcularNuevoStock();
        }

        private void rbEstablecer_CheckedChanged(object sender, EventArgs e)
        {
            calcularNuevoStock();
        }

        // Botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estado = EstadoFormulario.Nuevo;
            vaciarCampos();
            modoEscritura();
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro de inventario para ajustar");
                return;
            }

            estado = EstadoFormulario.Ajustar;
            modoAjuste();
            txtCantidadAjuste.Clear();
            calcularNuevoStock();
            MessageBox.Show("Ingrese la cantidad y seleccione el tipo de ajuste.\nLuego haga clic en Guardar.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            estado = EstadoFormulario.Lectura;
            modoLectura();

            if (dataGridView1.CurrentRow != null)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Deseas eliminar este registro de inventario?\n\nAdvertencia: Esto eliminará permanentemente el stock de este producto en esta sucursal.",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        int idSucursal = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_sucursal"].Value);
                        int idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_producto"].Value);

                        cn_inventario.EliminarStock(idSucursal, idProducto);
                        CargarInventario();
                        MessageBox.Show("Registro de inventario eliminado con éxito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el registro: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Eliminación cancelada");
                }
            }
            else
            {
                MessageBox.Show("Seleccione el registro a eliminar");
            }
            vaciarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro de la tabla para editar");
                return;
            }

            estado = EstadoFormulario.Editar;
            modoEscritura();
            MessageBox.Show("Modifique el stock y haga clic en Guardar");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null &&
                    (estado == EstadoFormulario.Editar || estado == EstadoFormulario.Lectura))
                {
                    cmbSucursal.SelectedValue = dataGridView1.CurrentRow.Cells["Id_sucursal"].Value;
                    cmbProducto.SelectedValue = dataGridView1.CurrentRow.Cells["Id_producto"].Value;
                    txtStockActual.Text = dataGridView1.CurrentRow.Cells["StockActual"].Value?.ToString();
                }

                if (estado == EstadoFormulario.Ajustar)
                {
                    calcularNuevoStock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void Guardar_Editar()
        {
            try
            {
                int idSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
                int idProducto = Convert.ToInt32(cmbProducto.SelectedValue);
                int stock = Convert.ToInt32(txtStockActual.Text);

                if (estado == EstadoFormulario.Nuevo)
                {
                    cn_inventario.AgregarStock(idSucursal, idProducto, stock);
                    MessageBox.Show("Registro de inventario creado correctamente.");
                }
                else if (estado == EstadoFormulario.Editar)
                {
                    cn_inventario.EditarStock(idSucursal, idProducto, stock);
                    MessageBox.Show("Stock actualizado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void GuardarAjuste()
        {
            try
            {
                int idSucursal = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_sucursal"].Value);
                int idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_producto"].Value);
                int stockActual = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StockActual"].Value);
                int cantidad = Convert.ToInt32(txtCantidadAjuste.Text);
                int nuevoStock = stockActual;

                if (rbAgregar.Checked)
                {
                    nuevoStock = stockActual + cantidad;
                }
                else if (rbDisminuir.Checked)
                {
                    nuevoStock = stockActual - cantidad;
                    if (nuevoStock < 0)
                    {
                        MessageBox.Show("Error: El stock no puede ser negativo.");
                        return;
                    }
                }
                else if (rbEstablecer.Checked)
                {
                    nuevoStock = cantidad;
                }

                cn_inventario.EditarStock(idSucursal, idProducto, nuevoStock);

                string tipoAjuste = rbAgregar.Checked ? "agregadas" : rbDisminuir.Checked ? "disminuidas" : "establecidas";
                MessageBox.Show($"Ajuste realizado correctamente.\n\n" +
                               $"Stock anterior: {stockActual}\n" +
                               $"Unidades {tipoAjuste}: {cantidad}\n" +
                               $"Stock nuevo: {nuevoStock}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el ajuste: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (estado)
            {
                case EstadoFormulario.Nuevo:
                    // Validar campos obligatorios
                    if (cmbSucursal.SelectedIndex == -1 ||
                        cmbProducto.SelectedIndex == -1 ||
                        string.IsNullOrWhiteSpace(txtStockActual.Text))
                    {
                        MessageBox.Show("Todos los campos son obligatorios.");
                        return;
                    }

                    // Validar stock
                    if (!validarStock(txtStockActual.Text))
                    {
                        MessageBox.Show("El stock debe ser un número entero mayor o igual a 0.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                case EstadoFormulario.Editar:
                    // Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(txtStockActual.Text))
                    {
                        MessageBox.Show("El campo de stock es obligatorio.");
                        return;
                    }

                    // Validar stock
                    if (!validarStock(txtStockActual.Text))
                    {
                        MessageBox.Show("El stock debe ser un número entero mayor o igual a 0.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                case EstadoFormulario.Ajustar:
                    // Validar cantidad de ajuste
                    if (string.IsNullOrWhiteSpace(txtCantidadAjuste.Text))
                    {
                        MessageBox.Show("Ingrese la cantidad a ajustar.");
                        return;
                    }

                    if (!validarStock(txtCantidadAjuste.Text))
                    {
                        MessageBox.Show("La cantidad debe ser un número entero mayor o igual a 0.");
                        return;
                    }

                    GuardarAjuste();
                    break;

                default:
                    MessageBox.Show("Seleccione una opción antes de guardar");
                    break;
            }

            CargarInventario();
            vaciarCampos();
            modoLectura();
            estado = EstadoFormulario.Lectura;
        }

        // Validación de entrada solo números
        private void txtStockActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCantidadAjuste_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}