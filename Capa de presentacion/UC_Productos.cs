using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Capa_de_Negocios;

namespace Capa_de_presentacion
{
    public partial class UC_Productos : UserControl
    {
        CN_Categoria cn_categoria = new CN_Categoria();
        CN_Marca cn_marca = new CN_Marca();
        CN_Producto cn_producto = new CN_Producto();
        private byte[] imagenBytes = null;

        public UC_Productos()
        {
            InitializeComponent();
            modoLectura();
            CargarCategorias();
            CargarMarcas();
            CargarProductos();
        }

        // Cargas
        private void CargarCategorias()
        {
            DataTable categorias = cn_categoria.mostrarCategorias();
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id_categoria";
            cmbCategoria.SelectedIndex = -1;
        }

        private void CargarMarcas()
        {
            DataTable marcas = cn_marca.mostrarMarcas();
            cmbMarca.DataSource = marcas;
            cmbMarca.DisplayMember = "Nombre";
            cmbMarca.ValueMember = "Id_marca";
            cmbMarca.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cn_producto.mostrarProductos();

            // Ocultar columna de imagen binaria
            if (dataGridView1.Columns.Contains("imagen"))
            {
                dataGridView1.Columns["imagen"].Visible = false;
            }
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
            btnSeleccionarImagen.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            cmbCategoria.Enabled = false;
            cmbMarca.Enabled = false;
        }

        private void modoEscritura()
        {
            btnEliminar.Enabled = false;
            btnSeleccionarImagen.Enabled = true;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            cmbCategoria.Enabled = true;
            cmbMarca.Enabled = true;
        }

        private void vaciarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            pictureBoxProducto.Image = null;
            imagenBytes = null;
        }

        // Validaciones
        private bool validarPrecio(string precio)
        {
            double resultado;
            if (double.TryParse(precio, out resultado))
            {
                return resultado > 0;
            }
            return false;
        }

        // Manejo de imagen
        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Seleccionar imagen del producto";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Cargar imagen en el PictureBox
                        pictureBoxProducto.Image = Image.FromFile(openFileDialog.FileName);
                        pictureBoxProducto.SizeMode = PictureBoxSizeMode.Zoom;

                        // Convertir imagen a bytes
                        using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            imagenBytes = new byte[fs.Length];
                            fs.Read(imagenBytes, 0, (int)fs.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    }
                }
            }
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
                    "¿Deseas eliminar el producto seleccionado?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        cn_producto.EliminarProducto(
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_producto"].Value)
                        );
                        CargarProductos();
                        MessageBox.Show("Producto eliminado con éxito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Eliminación cancelada");
                }
            }
            else
            {
                MessageBox.Show("Seleccione el producto a eliminar");
            }
            vaciarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la tabla para editar");
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
                    txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value?.ToString();
                    txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value?.ToString();
                    cmbCategoria.SelectedValue = dataGridView1.CurrentRow.Cells["Id_categoria"].Value;
                    cmbMarca.SelectedValue = dataGridView1.CurrentRow.Cells["Id_marca"].Value;

                    // Cargar imagen si existe
                    if (dataGridView1.CurrentRow.Cells["imagen"].Value != DBNull.Value)
                    {
                        imagenBytes = (byte[])dataGridView1.CurrentRow.Cells["imagen"].Value;
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            pictureBoxProducto.Image = Image.FromStream(ms);
                            pictureBoxProducto.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        pictureBoxProducto.Image = null;
                        imagenBytes = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del producto: " + ex.Message);
            }
        }

        private void Guardar_Editar()
        {
            try
            {
                int categoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                int marca = Convert.ToInt32(cmbMarca.SelectedValue);
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                double precio = Convert.ToDouble(txtPrecio.Text);

                // Si no hay imagen nueva, usar la existente o null
                byte[] imagenFinal = imagenBytes;

                if (estado == EstadoFormulario.Nuevo)
                {
                    cn_producto.agregarProducto(
                        categoria,
                        marca,
                        nombre,
                        descripcion,
                        precio,
                        imagenFinal
                    );
                    MessageBox.Show("Producto creado correctamente.");
                }
                else if (estado == EstadoFormulario.Editar)
                {
                    int idProducto = Convert.ToInt32(
                        dataGridView1.CurrentRow.Cells["Id_producto"].Value
                    );

                    // Si no se seleccionó una nueva imagen, mantener la anterior
                    if (imagenFinal == null && dataGridView1.CurrentRow.Cells["imagen"].Value != DBNull.Value)
                    {
                        imagenFinal = (byte[])dataGridView1.CurrentRow.Cells["imagen"].Value;
                    }

                    cn_producto.editarProducto(
                        idProducto,
                        categoria,
                        marca,
                        nombre,
                        descripcion,
                        precio,
                        imagenFinal
                    );
                    MessageBox.Show("Producto modificado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (estado)
            {
                case EstadoFormulario.Nuevo:
                    // Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                        string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                        cmbCategoria.SelectedIndex == -1 ||
                        cmbMarca.SelectedIndex == -1)
                    {
                        MessageBox.Show("Todos los campos son obligatorios.");
                        return;
                    }

                    // Validar precio
                    if (!validarPrecio(txtPrecio.Text))
                    {
                        MessageBox.Show("El precio debe ser un número mayor a 0.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                case EstadoFormulario.Editar:
                    // Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                        string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                        cmbCategoria.SelectedIndex == -1 ||
                        cmbMarca.SelectedIndex == -1)
                    {
                        MessageBox.Show("Todos los campos son obligatorios.");
                        return;
                    }

                    // Validar precio
                    if (!validarPrecio(txtPrecio.Text))
                    {
                        MessageBox.Show("El precio debe ser un número mayor a 0.");
                        return;
                    }

                    Guardar_Editar();
                    break;

                default:
                    MessageBox.Show("Seleccione Nuevo o Editar antes de guardar");
                    break;
            }

            CargarProductos();
            vaciarCampos();
            modoLectura();
            estado = EstadoFormulario.Lectura;
        }
    }
}