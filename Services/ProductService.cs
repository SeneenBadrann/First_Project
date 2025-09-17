using First_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Services
{
    internal class ProductService
    {
        public List<Product> products { get; set; }
        public CartService cartService { get; set; }
        public ProductService() {
            products = new List<Product>();
        }
        public void addProduct(Product product)
        {
            var newProduct = products.FirstOrDefault(x => x.Id == product.Id);
            if (newProduct == null) {
                products.Add(product);
                Console.WriteLine($"Product With Name {product.Name} & Price {product.Price} Added");
        }
            else
                Console.WriteLine("This Product Is Already Exist");
        }
        public void removeProduct(int id)
        {
            var product = products.FirstOrDefault(b => b.Id == id);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine($"Product {product.Name} Removed");
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }
        }
        public void updateProduct(int id,String name,int quantity,double price) {
            var product = products.FirstOrDefault(b => b.Id == id);
            if (product != null)
            {
                product.Name = name;
                product.Price = price;
                product.Quantity = quantity;
                Console.WriteLine($"Product {product.Name} Updated");
            }
            else
                Console.WriteLine("Product Not Found");
        }
        public void showAllProduct()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"Product Name : {products[i].Name}      Product Price : {products[i].Price}     Product Quantity : {products[i].Quantity}");
            }
        }
        public List<Product> getProducts(Func<Product, bool> fillter)
        {
            return products.Where(fillter).ToList();
        }
        public void updateQuantity(int id,int quantity)
        {
            var product=products.FirstOrDefault(b => b.Id == id);
            if (product != null)
            {
                product.Quantity -= quantity;
                Console.WriteLine(product.Quantity);
            }
            else
            {
                Console.WriteLine("This Product Is Not Exist");
            }
        }
    }
}
