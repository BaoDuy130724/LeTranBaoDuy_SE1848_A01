using BusinessObjects;
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
    /// Interaction logic for ProductEditWindow.xaml
    /// </summary>
    public partial class ProductEditWindow : Window
    {
        public Product currentProduct;
        public ProductEditWindow(Product product = null)
        {
            InitializeComponent();
            if (product == null)
            {
                currentProduct = new Product();
            }
            else
            {
                currentProduct = new Product
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    CategoryId = product.CategoryId,
                    SupplierId = product.SupplierId,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitsOnOrder = product.UnitsOnOrder,
                    UnitsInStock = product.UnitsInStock,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued,
                };
                loadData();
            }
            
        }
        private void loadData()
        {
            txtProductName.Text = currentProduct.ProductName;
            txtSupplier.Text = currentProduct.SupplierId?.ToString();
            txtCategory.Text = currentProduct.CategoryId?.ToString();
            txtQuantity.Text = currentProduct.QuantityPerUnit;
            txtUnitPrice.Text = currentProduct.UnitPrice?.ToString("F2");
            txtStock.Text = currentProduct.UnitsInStock.ToString();
            txtOnOrder.Text = currentProduct.UnitsOnOrder.ToString();
            txtReorder.Text = currentProduct.ReorderLevel.ToString(); 
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(txtQuantity.Text) ||
                string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtStock.Text) ||
                string.IsNullOrEmpty(txtCategory.Text) || string.IsNullOrEmpty(txtSupplier.Text) ||
                string.IsNullOrEmpty(txtOnOrder.Text) || string.IsNullOrEmpty(txtReorder.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            currentProduct.ProductName = txtProductName.Text;
            currentProduct.SupplierId = int.Parse(txtSupplier.Text);
            currentProduct.CategoryId = int.Parse(txtCategory.Text);
            currentProduct.QuantityPerUnit = txtQuantity.Text;
            currentProduct.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            currentProduct.UnitsInStock = int.Parse(txtStock.Text);
            currentProduct.ReorderLevel = int.Parse(txtReorder.Text);
            currentProduct.UnitsOnOrder = int.Parse(txtOnOrder.Text);
            DialogResult = true;
            Close();
        }

        public Product GetProduct()
        {
            return currentProduct;
        }
    }
}
