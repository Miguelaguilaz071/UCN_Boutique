using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_de_Negocios;

namespace Capa_de_presentacion
{
    public partial class Login : Form
    {
        CN_Usuario usuarioCN = new CN_Usuario();
        public Login()
        {
            InitializeComponent();
        }
        
        //los botones de minimizar y cerrar
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //simulando placeholder
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

        //se validan los textbox y se determina a que formulario accedera
        //el usuario
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            DataTable resultado = usuarioCN.LoginUsuario(
            txtCorreo.Text,
            txtContrasena.Text);

            if (resultado.Rows.Count > 0)
            {
                string rol = resultado.Rows[0]["Rol"].ToString();
                UserSession.UserId = resultado.Rows[0]["Id_usuario"].ToString();
                this.Hide();
                if (rol == "Cliente")
                {
                    Frm_Cliente cliente = new Frm_Cliente();
                    cliente.ShowDialog();
                }
                else if (rol == "Administrador")
                {
                    FrmAdmin admin = new FrmAdmin();
                    admin.ShowDialog();
                }
                else if (rol == "Vendedor")
                {
                    FrmVendedor vendedor = new FrmVendedor();
                    vendedor.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Rol no autorizado.");
                }
                this.Show();
                txtCorreo.Text = "Correo";
                txtContrasena.Text = "Contraseña";
                txtContrasena.UseSystemPasswordChar = false;
                chkMostrarContrasena.Checked = false;
            }
            else 
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        //esta seccion es para registrar un nuevo usuario de tipo cliente
        private void btnCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (FrmRegistro frmregistro = new FrmRegistro())
            {
                frmregistro.ShowDialog();
            }
            this.Show();
        }

        //esta seccion me permite deslizar el formulario con el mouse
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void checkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if(txtContrasena.Text != "Contraseña") 
            {
                txtContrasena.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
            }
        }
    }
    public static class UserSession
    {
        public static string UserId { get; set; }
    }
}
