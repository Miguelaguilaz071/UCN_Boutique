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
    public partial class UC_Roles : UserControl
    {
        CN_Rol cn_rol = new CN_Rol();

        public UC_Roles()
        {
            InitializeComponent();
            modoLectura();
            CargarRoles();
        }

        // Cargas
        private void CargarRoles()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cn_rol.mostrarRoles();
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

        // Validación
        private bool validarRolSistema(string nombreRol)
        {
            // Roles del sistema que no se pueden eliminar
            string[] rolesSistema = { "Administrador", "Cliente", "Vendedor" };
            return rolesSistema.Contains(nombreRol, StringComparer.OrdinalIgnoreCase);
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
                // Validar que no sea un rol del sistema
                if (validarRolSistema(txtNombre.Text))
                {
                    MessageBox.Show(
                        "No se puede eliminar este rol porque es un rol del sistema.\n\n" +
                        "Los roles 'Administrador', 'Cliente' y 'Vendedor' son necesarios para el funcionamiento de la aplicación.",
                        "Rol del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    vaciarCampos();
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                    "¿Deseas eliminar el rol seleccionado?\n\n" +
                    "Advertencia: No podrás eliminar este rol si existen usuarios asignados a él.",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        cn_rol.EliminarRol(
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_rol"].Value)
                        );
                        CargarRoles();
                        MessageBox.Show("Rol eliminado con éxito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error al eliminar el rol.\n\n" +
                            "Posible causa: Existen usuarios asignados a este rol.\n\n" +
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
                MessageBox.Show("Seleccione el rol a eliminar");
            }
            vaciarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un rol de la tabla para editar");
                return;
            }

            // Validar que no sea un rol del sistema
            string nombreRolActual = dataGridView1.CurrentRow.Cells["Rol"].Value?.ToString();
            if (validarRolSistema(nombreRolActual))
            {
                MessageBox.Show(
                    "No se puede editar este rol porque es un rol del sistema.\n\n" +
                    "Los roles 'Administrador', 'Cliente' y 'Vendedor' son necesarios para el funcionamiento de la aplicación.",
                    "Rol del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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
                    txtNombre.Text = dataGridView1.CurrentRow.Cells["Rol"].Value?.ToString();

                    // Deshabilitar botones si es un rol del sistema
                    if (estado == EstadoFormulario.Lectura)
                    {
                        string nombreRol = txtNombre.Text;
                        bool esRolSistema = validarRolSistema(nombreRol);

                        if (esRolSistema)
                        {
                            btnEditar.Enabled = false;
                            btnEliminar.Enabled = false;
                        }
                        else
                        {
                            btnEditar.Enabled = true;
                            btnEliminar.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del rol: " + ex.Message);
            }
        }

        private void Guardar_Editar()
        {
            try
            {
                string nombre = txtNombre.Text.Trim();

                if (estado == EstadoFormulario.Nuevo)
                {
                    // Validar que no se intente crear un rol con nombre de sistema
                    if (validarRolSistema(nombre))
                    {
                        MessageBox.Show(
                            "No se puede crear un rol con este nombre porque ya existe como rol del sistema.",
                            "Nombre Reservado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    cn_rol.AgregarRol(nombre);
                    MessageBox.Show("Rol creado correctamente.");
                }
                else if (estado == EstadoFormulario.Editar)
                {
                    int idRol = Convert.ToInt32(
                        dataGridView1.CurrentRow.Cells["Id_rol"].Value
                    );

                    cn_rol.EditarRoles(idRol, nombre);
                    MessageBox.Show("Rol modificado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el rol: " + ex.Message);
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
                        MessageBox.Show("El nombre del rol es obligatorio.");
                        return;
                    }

                    // Validar longitud de nombre
                    if (txtNombre.Text.Length > 50)
                    {
                        MessageBox.Show("El nombre del rol no puede exceder 50 caracteres.");
                        return;
                    }

                    // Validar caracteres permitidos (solo letras, números y espacios)
                    if (!System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9\s]+$"))
                    {
                        MessageBox.Show("El nombre del rol solo puede contener letras, números y espacios.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                case EstadoFormulario.Editar:
                    // Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("El nombre del rol es obligatorio.");
                        return;
                    }

                    // Validar longitud de nombre
                    if (txtNombre.Text.Length > 50)
                    {
                        MessageBox.Show("El nombre del rol no puede exceder 50 caracteres.");
                        return;
                    }

                    // Validar caracteres permitidos
                    if (!System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9\s]+$"))
                    {
                        MessageBox.Show("El nombre del rol solo puede contener letras, números y espacios.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                default:
                    MessageBox.Show("Seleccione Nuevo o Editar antes de guardar");
                    break;
            }

            CargarRoles();
            vaciarCampos();
            modoLectura();
            estado = EstadoFormulario.Lectura;

            // Rehabilitar botones
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}