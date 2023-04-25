using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Laboratorio_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            BProducto negocio = new BProducto();
            dgvDemo.DataSource = negocio.ListarTodo();
            dgvDemo.Columns.Remove("Estado");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos");
                    return;
                }

                BProducto negocio = new BProducto();
                decimal precio;
                if (decimal.TryParse(txtPrecio.Text, out precio))
                {
                    negocio.Insertar(new Producto
                    {
                        Nombre = txtNombre.Text,
                        Precio = precio,
                        FechaCreacion = dataTime.Value
                    });
                    MessageBox.Show("Registro exitoso");

                    txtNombre.Clear();
                    txtPrecio.Clear();

                    dgvDemo.DataSource = negocio.ListarTodo();
                    dgvDemo.Columns.Remove("Estado");
                }
                else
                {
                    MessageBox.Show("Precio inválido");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDemo.SelectedRows.Count > 0)
            {
                int id = (int)dgvDemo.SelectedRows[0].Cells["Id"].Value;
                try
                {
                    BProducto negocio = new BProducto();
                    negocio.Eliminar(id);
                    MessageBox.Show("Producto eliminado exitosamente");
                    dgvDemo.DataSource = negocio.ListarTodo();
                    dgvDemo.Columns.Remove("Estado");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al eliminar el producto");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar");
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvDemo.SelectedRows.Count > 0)
            {
                int id = (int)dgvDemo.SelectedRows[0].Cells["Id"].Value;
                string nombre = txtNombre.Text;
                decimal precio;
                if (decimal.TryParse(txtPrecio.Text, out precio))
                {
                    DateTime fechaCreacion = dataTime.Value;
                    Producto producto = new Producto { Id = id, Nombre = nombre, Precio = precio, FechaCreacion = fechaCreacion };
                    BProducto negocio = new BProducto();
                    negocio.Actualizar(producto);
                    MessageBox.Show("Producto actualizado exitosamente");
                    dgvDemo.DataSource = negocio.ListarTodo();
                    dgvDemo.Columns.Remove("Estado");
                }
                else
                {
                    MessageBox.Show("Precio inválido");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para actualizar");
            }
        }

        private void dgvDemo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDemo.SelectedRows.Count > 0)
            {
                
                string nombre = dgvDemo.SelectedRows[0].Cells["Nombre"].Value.ToString();
                decimal precio = Convert.ToDecimal(dgvDemo.SelectedRows[0].Cells["Precio"].Value);
                DateTime fechaCreacion = Convert.ToDateTime(dgvDemo.SelectedRows[0].Cells["FechaCreacion"].Value);

                txtNombre.Text = nombre;
                txtPrecio.Text = precio.ToString();
                dataTime.Value = fechaCreacion;
            }
        }
        private void dgvDemo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void dgvDemo_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre1.Text;
            BProducto negocio = new BProducto();
            dgvDemo.DataSource = negocio.BuscarProductoPorNombre(nombre);
            dgvDemo.Columns.Remove("Estado");
        }
    }
   
}
