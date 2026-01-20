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
using Capa_de_presentacion;

namespace Capa_de_presentacion
{
    public partial class UC_Usuario : UserControl
    {
        CN_Rol cn_rol = new CN_Rol();
        CN_Usuario cn_usuario = new CN_Usuario();
        public UC_Usuario()
        {
            InitializeComponent();
            modoLectura();
            CargarRoles();
            CargarUsuarios();
        }

        //cargas
        private void CargarRoles()
        {
            DataTable roles = cn_rol.mostrarRoles();
            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Rol";
            cmbRol.ValueMember = "Id_rol";
            cmbRol.SelectedIndex = -1;
        }

        private void CargarUsuarios()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cn_usuario.mostrarUsuario();
            dataGridView1.Columns["Contrasena"].Visible = false;
        }

        //modos y estados
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
            txtContrasena.Enabled = false;
            txtNombre.Enabled = false;
            txtCorreo.Enabled = false;
            cmbRol.Enabled = false;
        }

        private void modoEscritura()
        {
            btnEliminar.Enabled = false;
            txtContrasena.Enabled = true;
            txtNombre.Enabled = true;
            txtCorreo.Enabled = true;
            cmbRol.Enabled = true;
        }

        private void vaciarCampos()
        {
            txtContrasena.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
            cmbRol.SelectedIndex = -1;
        }

        //validaciones
        private bool CorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        //botones
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
                "¿Deseas eliminar el elemento seleccionado?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
                if (resultado == DialogResult.Yes)
                {
                    cn_usuario.EliminarUsuario(
                        Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_usuario"].Value)
                    );
                    CargarUsuarios();
                    MessageBox.Show("Eliminado con exito");
                }
                else
                {
                    MessageBox.Show("Eliminación cancelada");
                }
            }
            else
            {
                MessageBox.Show("Seleccione la fila del usuario a eliminar");
            }
            vaciarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estado = EstadoFormulario.Editar;
            modoEscritura();
            MessageBox.Show("Seleccione una fila para rellenar campos automaticamente" +
                            " y de click en guardar cuando haya terminado");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null &&
                (estado == EstadoFormulario.Editar || estado == EstadoFormulario.Lectura))
                {
                    vaciarCampos();
                    txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value?.ToString();
                    //txtContrasena.Text = dataGridView1.CurrentRow.Cells["Contrasena"].Value?.ToString();
                    txtCorreo.Text = dataGridView1.CurrentRow.Cells["Correo"].Value?.ToString();
                    cmbRol.SelectedValue = dataGridView1.CurrentRow.Cells["Id_rol"].Value?.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Error al rellenar los campos");
            }
        }

        private void Guardar_Editar()
        {
            try
            {
                int rol = Convert.ToInt32(cmbRol.SelectedValue);
                if (estado == EstadoFormulario.Nuevo)
                {
                    cn_usuario.agregarUsuario(
                        rol,
                        txtNombre.Text.ToString(),
                        txtCorreo.Text.ToString(),
                        txtContrasena.Text.ToString()
                    );
                    MessageBox.Show("Usuario creado correctamente.");
                }
                if (estado == EstadoFormulario.Editar)
                {
                    int Id_usuario = Convert.ToInt32(
                        dataGridView1.CurrentRow.Cells["Id_usuario"].Value?.ToString()
                        );
                    string contrasena;
                    if (txtContrasena.Text == "")
                    {
                        contrasena = dataGridView1.CurrentRow.Cells["Contrasena"].Value?.ToString();
                    }
                    else
                    {
                        contrasena = txtContrasena.Text;
                    }
                    cn_usuario.editarUsuario(
                        Id_usuario,
                        rol,
                        txtNombre.Text.ToString(),
                        txtCorreo.Text.ToString(),
                        contrasena
                        );
                    MessageBox.Show("Usuario modificado correctamente.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la cuenta: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            switch (estado)
            {
                case EstadoFormulario.Nuevo:
                    //validar campos
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                        string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                        cmbRol.SelectedIndex == -1)
                    {
                        MessageBox.Show("Todos los campos son obligatorios.");
                        return;
                    }

                    //validar formato de correo
                    if (!CorreoValido(txtCorreo.Text))
                    {
                        MessageBox.Show("El correo no tiene un formato válido.");
                        return;
                    }

                    //validar longitud de contraseña
                    if (txtContrasena.Text.Length < 8)
                    {
                        MessageBox.Show("La contraseña debe tener al menos 8 caracteres.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                case EstadoFormulario.Editar:
                    //validar campos
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                        cmbRol.SelectedIndex == -1)
                    {
                        MessageBox.Show("Estos campos son obligatorios.");
                        return;
                    }

                    //validar formato de correo
                    if (!CorreoValido(txtCorreo.Text))
                    {
                        MessageBox.Show("El correo no tiene un formato válido.");
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(txtContrasena.Text))
                    {
                        //validar longitud de contraseña
                        if (txtContrasena.Text.Length < 8)
                        {
                            MessageBox.Show("La contraseña debe tener al menos 8 caracteres.");
                            return;
                        }
                    }

                    Guardar_Editar();
                    break;

                default:
                    MessageBox.Show("Seleccione Nuevo o editar antes de guardar");
                    break;
            }
            CargarUsuarios();
            vaciarCampos();
            modoLectura();
            estado = EstadoFormulario.Lectura;
        }
    }
}
