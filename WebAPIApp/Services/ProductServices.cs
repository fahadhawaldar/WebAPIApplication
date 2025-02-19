using WebAPIApp.Models;

namespace WebAPIApp.Services
{
    public class ProductServices : IProcuctServices
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;
        public async Task<Product> AddProductAsync(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
            return await Task.FromResult(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var removed = _products.RemoveAll(p => p.Id == id) > 0;
            return await Task.FromResult(removed);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product?> GetProductByIdAsync(int id) // Add nullable reference type
        {
            return await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index == -1) return await Task.FromResult(false);

            _products[index] = product;
            return await Task.FromResult(true);
        }

    
    }
}
