using BusinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LeTranBaoDuyWPF
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService;
        private List<Product> products;
        public ProductWindow()
        {
            InitializeComponent();
            productService = new ProductService();
            products = new List<Product>();
            Loadata();
        }
        private void Loadata()
        {
            products = productService.GetProducts();
            dgProducts.ItemsSource = null;
            dgProducts.ItemsSource = products;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var updateProduct = dgProducts.SelectedItem as Product;
            if (updateProduct == null || updateProduct.Discontinued)
            {
                MessageBox.Show("Please choose continued product!!!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var editWindow = new ProductEditWindow(updateProduct);
            if (editWindow.ShowDialog() == true)
            {
                var updatedProduct = editWindow.GetProduct();
                if (productService.UpdateProduct(updatedProduct))
                {
                    MessageBox.Show("Product updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Loadata();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var selectedProduct = dgProducts.SelectedItem as BusinessObjects.Product;
            if (selectedProduct != null)
            {
                var ret = MessageBox.Show($"Are you sure you want to delete product {selectedProduct.ProductName}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ret == MessageBoxResult.Yes)
                {
                    bool deleted = productService.DeleteProduct(selectedProduct);
                    if (deleted)
                    {
                        MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Loadata();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var ret = MessageBox.Show("Are you sure you want to go back?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ret == MessageBoxResult.Yes)
            {
                var mainWindow = new AdminMainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addProduct = new ProductEditWindow();
            if (addProduct.ShowDialog() == true)
            {
                var newProduct = addProduct.GetProduct();
                if (productService.AddProduct(newProduct))
                {
                    MessageBox.Show("Product added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Loadata();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgProducts.ItemsSource = products;
            }
            else
            {
                var filteredProducts = productService.GetProductByName(keyword);
                dgProducts.ItemsSource = filteredProducts;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Clear();
            dgProducts.ItemsSource = products;
        }
    }
}
