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
    public partial class UC_Sucursales : UserControl
    {
        CN_Sucursal cn_sucursal = new CN_Sucursal();

        public UC_Sucursales()
        {
            InitializeComponent();
            modoLectura();
            CargarSucursales();
        }

        // Cargas
        private void CargarSucursales()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cn_sucursal.mostrarSucursal();
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
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
        }

        private void modoEscritura()
        {
            btnEliminar.Enabled = false;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
        }

        private void vaciarCampos()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        // Validaciones
        private bool validarTelefono(string telefono)
        {
            // Verificar que solo contenga números, guiones, espacios y paréntesis
            foreach (char c in telefono)
            {
                if (!char.IsDigit(c) && c != '-' && c != ' ' && c != '(' && c != ')' && c != '+')
                {
                    return false;
                }
            }

            // Verificar longitud mínima (al menos 8 dígitos sin contar símbolos)
            string soloNumeros = new string(telefono.Where(char.IsDigit).ToArray());
            return soloNumeros.Length >= 8;
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
                    "¿Deseas eliminar la sucursal seleccionada?\n\nAdvertencia: Esto también eliminará el inventario asociado a esta sucursal.",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        cn_sucursal.EliminarSucursal(
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_sucursal"].Value)
                        );
                        CargarSucursales();
                        MessageBox.Show("Sucursal eliminada con éxito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la sucursal: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Eliminación cancelada");
                }
            }
            else
            {
                MessageBox.Show("Seleccione la sucursal a eliminar");
            }
            vaciarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una sucursal de la tabla para editar");
                return;
            }

            estado = EstadoFormulario.Editar;
            modoEscritura();
            MessageBox.Show("Modifique los campos y haga clic en Guardar");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null &&
                    (estado == EstadoFormulario.Editar || estado == EstadoFormulario.Lectura))
                {
                    txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value?.ToString();
                    txtDireccion.Text = dataGridView1.CurrentRow.Cells["Direccion"].Value?.ToString();
                    txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la sucursal: " + ex.Message);
            }
        }

        private void Guardar_Editar()
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                if (estado == EstadoFormulario.Nuevo)
                {
                    cn_sucursal.AgregarSucursales(
                        nombre,
                        direccion,
                        telefono
                    );
                    MessageBox.Show("Sucursal creada correctamente.");
                }
                else if (estado == EstadoFormulario.Editar)
                {
                    int idSucursal = Convert.ToInt32(
                        dataGridView1.CurrentRow.Cells["Id_sucursal"].Value
                    );

                    cn_sucursal.EditarSucursal(
                        idSucursal,
                        nombre,
                        direccion,
                        telefono
                    );
                    MessageBox.Show("Sucursal modificada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la sucursal: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (estado)
            {
                case EstadoFormulario.Nuevo:
                    // Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                        string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        MessageBox.Show("Todos los campos son obligatorios.");
                        return;
                    }

                    // Validar teléfono
                    if (!validarTelefono(txtTelefono.Text))
                    {
                        MessageBox.Show("El teléfono debe tener un formato válido y al menos 8 dígitos.\n\nFormatos aceptados:\n- 2234-5678\n- (506) 2234-5678\n- +506 2234 5678");
                        return;
                    }

                    // Validar longitud de nombre
                    if (txtNombre.Text.Length > 50)
                    {
                        MessageBox.Show("El nombre de la sucursal no puede exceder 50 caracteres.");
                        return;
                    }

                    // Validar longitud de dirección
                    if (txtDireccion.Text.Length > 250)
                    {
                        MessageBox.Show("La dirección no puede exceder 250 caracteres.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                case EstadoFormulario.Editar:
                    // Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                        string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        MessageBox.Show("Todos los campos son obligatorios.");
                        return;
                    }

                    // Validar teléfono
                    if (!validarTelefono(txtTelefono.Text))
                    {
                        MessageBox.Show("El teléfono debe tener un formato válido y al menos 8 dígitos.\n\nFormatos aceptados:\n- 2234-5678\n- (506) 2234-5678\n- +506 2234 5678");
                        return;
                    }

                    // Validar longitud de nombre
                    if (txtNombre.Text.Length > 50)
                    {
                        MessageBox.Show("El nombre de la sucursal no puede exceder 50 caracteres.");
                        return;
                    }

                    // Validar longitud de dirección
                    if (txtDireccion.Text.Length > 250)
                    {
                        MessageBox.Show("La dirección no puede exceder 250 caracteres.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                default:
                    MessageBox.Show("Seleccione Nuevo o Editar antes de guardar");
                    break;
            }

            CargarSucursales();
            vaciarCampos();
            modoLectura();
            estado = EstadoFormulario.Lectura;
        }

        // Evento para formatear el teléfono mientras se escribe (opcional)
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, backspace, guión, espacio, paréntesis y signo +
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '-' &&
                e.KeyChar != ' ' &&
                e.KeyChar != '(' &&
                e.KeyChar != ')' &&
                e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }
    }
}
