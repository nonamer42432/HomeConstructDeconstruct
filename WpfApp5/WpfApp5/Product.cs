using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public Product(string name, double price) : this(name, price, 1) // Количество по умолчанию = 1
        {
        }

        public void Deconstruct(out string name, out double price, out int quantity)
        {
            name = Name;
            price = Price;
            quantity = Quantity;
        }

        public override string ToString()
        {
            return $"{Name} - Price: {Price:C} - Quantity: {Quantity}";
        }
    }
}
