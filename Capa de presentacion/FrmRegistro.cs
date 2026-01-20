using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_de_Negocios;

namespace Capa_de_presentacion
{
    public partial class FrmRegistro : Form
    {
        CN_Usuario usuarioCN = new CN_Usuario();
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private readonly int rol = 1;
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //esta seccion me permite deslizar el formulario con el mouse
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //boton para iniciar sesion
        private void btnInicarSeision_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        //simulando placeholder
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre completo")
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre completo";
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Correo")
            {
                txtCorreo.Text = "";
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Correo";
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "Contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Contraseña";
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        private void txtConfirmar_Enter(object sender, EventArgs e)
        {
            if (txtConfirmar.Text == "Confirmar contraseña")
            {
                txtConfirmar.Text = "";
                txtConfirmar.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirmar_Leave(object sender, EventArgs e)
        {
            if (txtConfirmar.Text == "")
            {
                txtConfirmar.Text = "Confirmar contraseña";
                txtConfirmar.UseSystemPasswordChar = false;
            }
        }

        //validar formato de correo
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

        //agregar usuario

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //validar campos
            if (txtNombre.Text == "Nombre completo" || string.IsNullOrWhiteSpace(txtNombre.Text) ||
            txtCorreo.Text == "Correo" || string.IsNullOrWhiteSpace(txtCorreo.Text) ||
            txtContrasena.Text == "Contraseña" || string.IsNullOrWhiteSpace(txtContrasena.Text) ||
            txtConfirmar.Text == "Confirmar contraseña" || string.IsNullOrWhiteSpace(txtConfirmar.Text))
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

            //validar coincidencia de contraseña
            if (txtContrasena.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            try
            {
                usuarioCN.agregarUsuario(
                    rol,
                    txtNombre.Text.ToString(),
                    txtCorreo.Text.ToString(),
                    txtContrasena.Text.ToString()
                );

                MessageBox.Show("Cuenta creada correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la cuenta: " + ex.Message);
            }
        }

        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (txtContrasena.Text != "Contraseña")
            {
                txtContrasena.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
            }
            if (txtConfirmar.Text != "Confirmar contraseña")
            {
                txtConfirmar.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
            }
        }
    }
}
