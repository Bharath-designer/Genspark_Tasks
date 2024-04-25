using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingTestCase
{
    public class ProductTests
    {
        IProductService _productService;

        [SetUp]
        public void Setup()
        {
            IRepository<int, Product> _repository = new Repository<int, Product>();
            _productService = new ProductBL(_repository);
        }

        [Test]
        public void AddProductSuccessTest()
        {
            Product product = new Product(1, "Laptop", Currency.Rupee, 40000);

            _productService.AddProduct(product.Id, product);

        }

        [Test]
        public void AddProductFailTest()
        {
            Product product = new Product(2, "Laptop", Currency.Rupee, 40000);

            _productService.AddProduct(product.Id, product);

            Assert.Throws<IdAlreadyFoundException>(() =>
            {
                _productService.AddProduct(product.Id, product);
            });
        }

        [Test]
        public void GetAllProductsSuccessTest()
        {
            Product product = new Product(3, "Laptop", Currency.Rupee, 40000);
            _productService.AddProduct(product.Id, product);

            List<Product> products = _productService.GetAllProducts();
            Assert.AreEqual(1, products.Count);
        }

        [Test]
        public void GetProductByIdSuccessTest()
        {
            Product product = new Product(4, "Laptop", Currency.Rupee, 40000);

            _productService.AddProduct(product.Id, product);

            Product retrievedProduct = _productService.GetProductById(product.Id);
            Assert.AreEqual(product, retrievedProduct);
        }

        [Test]
        public void GetProductByIdFailTest()
        {

            Assert.Throws<IdNotFoundException>(() =>
            {
                _productService.GetProductById(999);
            });
        }

        [Test]
        public void UpdateProductSuccessTest()
        {
            Product product = new Product(5, "Laptop", Currency.Rupee, 40000);
            _productService.AddProduct(product.Id, product);

            Product updatedProduct = new Product(5, "Phone", Currency.Rupee, 40000);

            _productService.UpdateProduct(product.Id, updatedProduct);

            Product retrievedProduct = _productService.GetProductById(product.Id);
            Assert.AreEqual(updatedProduct, retrievedProduct);
        }

        [Test]
        public void UpdateProductFailTest()
        {
            Product product = new Product(999, "Laptop", Currency.Rupee, 40000);

            Assert.Throws<IdNotFoundException>(() =>
            {
                _productService.UpdateProduct(product.Id, product);
            });
        }

        [Test]
        public void DeleteProductSuccessTest()
        {
            Product product = new Product(999, "Laptop", Currency.Rupee, 40000);
            _productService.AddProduct(product.Id, product);

            _productService.DeleteProduct(product.Id);

            Assert.Throws<IdNotFoundException>(() =>
            {
                _productService.GetProductById(product.Id);
            });
        }

        [Test]
        public void DeleteProductFailTest()
        {

            Assert.Throws<IdNotFoundException>(() =>
            {
                _productService.DeleteProduct(999);
            });
        }
    }
}
