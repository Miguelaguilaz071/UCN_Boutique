using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_de_presentacion
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void CargarUserControl(UserControl uc)
        {
            panelCentral.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelCentral.Controls.Add(uc);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UC_Usuario ucUsuario = new UC_Usuario();
            CargarUserControl(ucUsuario);

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            UC_Productos ucProducto = new UC_Productos();
            CargarUserControl(ucProducto);
        }

        private void btnSucursales_Click(object sender, EventArgs e)
        {
            UC_Sucursales ucSucursales = new UC_Sucursales();
            CargarUserControl(ucSucursales);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            UC_Inventario ucInventario = new UC_Inventario();
            CargarUserControl(ucInventario);
        }
    }
}
