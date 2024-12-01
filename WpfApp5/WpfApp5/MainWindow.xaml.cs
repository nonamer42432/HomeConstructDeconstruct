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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        private List<Product> products = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || !double.TryParse(txtPrice.Text, out double price))
            {
                MessageBox.Show("Пожалуйста, введите действительное название продукта и цену.");
                return;
            }

            int quantity = 1;
            if (!string.IsNullOrEmpty(txtQuantity.Text) && int.TryParse(txtQuantity.Text, out int parsedQuantity))
            {
                quantity = parsedQuantity;
            }

            // Использование различных конструкторов на основе ввода
            Product product;
            if (string.IsNullOrEmpty(txtQuantity.Text))
                product = new Product(txtName.Text, price);
            else
                product = new Product(txtName.Text, price, quantity);


            products.Add(product);
            lstProducts.ItemsSource = products;
            ClearInputFields();
        }


        private void lstProducts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            btnDeconstruct.IsEnabled = lstProducts.SelectedItem != null;
        }

        private void btnDeconstruct_Click(object sender, RoutedEventArgs e)
        {
            if (lstProducts.SelectedItem is Product selectedProduct)
            {
                selectedProduct.Deconstruct(out string name, out double price, out int quantity);
                txtDeconstructedData.Text = $"Name: {name}, Price: {price:C}, Quantity: {quantity}";
            }
        }

        private void ClearInputFields()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }
    }
}
