using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ExamenProgra
{
    public partial class MainWindow : Window
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private DataTable productosTable;
        private DataRowView selectedRow;

        public MainWindow()
        {
            InitializeComponent();
            LoadProductos();
        }

        private SqlConnection CrearConexion()
        {
            return new SqlConnection(connectionString);
        }

        private void LoadProductos()
        {
            try
            {
                using (SqlConnection connection = CrearConexion())
                {
                    string query = "SELECT Id, Nombre, Descripcion, Precio, Disponible FROM Productos";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    productosTable = new DataTable();
                    adapter.Fill(productosTable);

                    ProductosDataGrid.ItemsSource = productosTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProductosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductosDataGrid.SelectedItem != null)
            {
                selectedRow = (DataRowView)ProductosDataGrid.SelectedItem;

                TxtNombre.Text = selectedRow["Nombre"].ToString();
                TxtDescripcion.Text = selectedRow["Descripcion"].ToString();
                TxtPrecio.Text = selectedRow["Precio"].ToString();
                ChkDisponible.IsChecked = Convert.ToBoolean(selectedRow["Disponible"]);
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = CrearConexion())
                {
                    string query = "INSERT INTO Productos (Nombre, Descripcion, Precio, Disponible) VALUES (@nombre, @descripcion, @precio, @disponible)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@nombre", TxtNombre.Text);
                    command.Parameters.AddWithValue("@descripcion", TxtDescripcion.Text);
                    command.Parameters.AddWithValue("@precio", decimal.Parse(TxtPrecio.Text));
                    command.Parameters.AddWithValue("@disponible", ChkDisponible.IsChecked ?? false);

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadProductos();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRow != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = CrearConexion())
                        {
                            string query = "DELETE FROM Productos WHERE Id = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            int id = Convert.ToInt32(selectedRow["Id"]);
                            command.Parameters.AddWithValue("@id", id);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadProductos();
                            ClearInputs();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearInputs()
        {
            TxtNombre.Text = "";
            TxtDescripcion.Text = "";
            TxtPrecio.Text = "";
            ChkDisponible.IsChecked = false;
            selectedRow = null;
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRow != null)
            {
                try
                {
                    using (SqlConnection connection = CrearConexion())
                    {
                        string query = "UPDATE Productos SET Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Disponible = @disponible WHERE Id = @id";
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@nombre", TxtNombre.Text);
                        command.Parameters.AddWithValue("@descripcion", TxtDescripcion.Text);
                        command.Parameters.AddWithValue("@precio", decimal.Parse(TxtPrecio.Text));
                        command.Parameters.AddWithValue("@disponible", ChkDisponible.IsChecked ?? false);
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(selectedRow["Id"]));

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadProductos();
                        ClearInputs();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el producto: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
