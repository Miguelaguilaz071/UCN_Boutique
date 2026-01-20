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
    public partial class UC_Marcas : UserControl
    {
        CN_Marca cn_marca = new CN_Marca();

        public UC_Marcas()
        {
            InitializeComponent();
            modoLectura();
            CargarMarcas();
        }

        // Cargas
        private void CargarMarcas()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cn_marca.mostrarMarcas();
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
                    "¿Deseas eliminar la marca seleccionada?\n\nAdvertencia: Esto puede afectar los productos asociados a esta marca.",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        cn_marca.EliminarMarca(
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_marca"].Value)
                        );
                        CargarMarcas();
                        MessageBox.Show("Marca eliminada con éxito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la marca: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Eliminación cancelada");
                }
            }
            else
            {
                MessageBox.Show("Seleccione la marca a eliminar");
            }
            vaciarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una marca de la tabla para editar");
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
                MessageBox.Show("Error al cargar los datos de la marca: " + ex.Message);
            }
        }

        private void Guardar_Editar()
        {
            try
            {
                string nombre = txtNombre.Text.Trim();

                if (estado == EstadoFormulario.Nuevo)
                {
                    cn_marca.AgregarMarca(nombre);
                    MessageBox.Show("Marca creada correctamente.");
                }
                else if (estado == EstadoFormulario.Editar)
                {
                    int idMarca = Convert.ToInt32(
                        dataGridView1.CurrentRow.Cells["Id_marca"].Value
                    );

                    cn_marca.EditarMarca(idMarca, nombre);
                    MessageBox.Show("Marca modificada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la marca: " + ex.Message);
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
                        MessageBox.Show("El nombre de la marca es obligatorio.");
                        return;
                    }

                    // Validar longitud de nombre
                    if (txtNombre.Text.Length > 100)
                    {
                        MessageBox.Show("El nombre de la marca no puede exceder 100 caracteres.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                case EstadoFormulario.Editar:
                    // Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("El nombre de la marca es obligatorio.");
                        return;
                    }

                    // Validar longitud de nombre
                    if (txtNombre.Text.Length > 100)
                    {
                        MessageBox.Show("El nombre de la marca no puede exceder 100 caracteres.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                default:
                    MessageBox.Show("Seleccione Nuevo o Editar antes de guardar");
                    break;
            }

            CargarMarcas();
            vaciarCampos();
            modoLectura();
            estado = EstadoFormulario.Lectura;
        }
    }
}