using System;
using System.Windows.Forms;
using Capa_de_Negocios;

namespace Capa_de_presentacion
{
    public partial class UC_TiposDePago : UserControl
    {
        CN_TipoPago cn_tipoPago = new CN_TipoPago();

        public UC_TiposDePago()
        {
            InitializeComponent();
            modoLectura();
            CargarTiposPago();
        }

        // Cargas
        private void CargarTiposPago()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cn_tipoPago.MostrarTiposPago();
        }

        // Modos y estados
        enum EstadoFormulario
        {
            Lectura,
            Nuevo,
            Editar
        }
        EstadoFormulario estado = EstadoFormulario.Lectura;

        private void modoLectura()
        {
            btnEliminar.Enabled = true;
            txtNombre.Enabled = false;
        }

        private void modoEscritura()
        {
            btnEliminar.Enabled = false;
            txtNombre.Enabled = true;
        }

        private void vaciarCampos()
        {
            txtNombre.Clear();
        }

        // Botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estado = EstadoFormulario.Nuevo;
            vaciarCampos();
            modoEscritura();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            estado = EstadoFormulario.Lectura;
            modoLectura();

            if (txtNombre.Text != "")
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Deseas eliminar el tipo de pago seleccionado?\n\n" +
                    "Advertencia: No podrás eliminar este tipo si existen métodos de pago registrados con él.",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        cn_tipoPago.EliminarTipoPago(
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_TipoTarjeta"].Value)
                        );
                        CargarTiposPago();
                        MessageBox.Show("Tipo de pago eliminado con éxito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error al eliminar el tipo de pago.\n\n" +
                            "Posible causa: Existen métodos de pago registrados con este tipo.\n\n" +
                            "Detalle: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Eliminación cancelada");
                }
            }
            else
            {
                MessageBox.Show("Seleccione el tipo de pago a eliminar");
            }
            vaciarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un tipo de pago de la tabla para editar");
                return;
            }

            estado = EstadoFormulario.Editar;
            modoEscritura();
            MessageBox.Show("Modifique el nombre y haga clic en Guardar");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null &&
                    (estado == EstadoFormulario.Editar || estado == EstadoFormulario.Lectura))
                {
                    txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del tipo de pago: " + ex.Message);
            }
        }

        private void Guardar_Editar()
        {
            try
            {
                string nombre = txtNombre.Text.Trim();

                if (estado == EstadoFormulario.Nuevo)
                {
                    cn_tipoPago.AgregarTipoPago(nombre);
                    MessageBox.Show("Tipo de pago creado correctamente.");
                }
                else if (estado == EstadoFormulario.Editar)
                {
                    int idTipo = Convert.ToInt32(
                        dataGridView1.CurrentRow.Cells["Id_TipoTarjeta"].Value
                    );

                    cn_tipoPago.EditarTipoPago(idTipo, nombre);
                    MessageBox.Show("Tipo de pago modificado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el tipo de pago: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (estado)
            {
                case EstadoFormulario.Nuevo:
                    // Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("El nombre del tipo de pago es obligatorio.");
                        return;
                    }

                    // Validar longitud de nombre
                    if (txtNombre.Text.Length > 30)
                    {
                        MessageBox.Show("El nombre del tipo de pago no puede exceder 30 caracteres.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                case EstadoFormulario.Editar:
                    // Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("El nombre del tipo de pago es obligatorio.");
                        return;
                    }

                    // Validar longitud de nombre
                    if (txtNombre.Text.Length > 30)
                    {
                        MessageBox.Show("El nombre del tipo de pago no puede exceder 30 caracteres.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                default:
                    MessageBox.Show("Seleccione Nuevo o Editar antes de guardar");
                    break;
            }

            CargarTiposPago();
            vaciarCampos();
            modoLectura();
            estado = EstadoFormulario.Lectura;
        }
    }
}

