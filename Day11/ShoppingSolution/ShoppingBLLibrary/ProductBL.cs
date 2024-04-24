﻿using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class ProductBL : IProductService
    {
        IRepository<int, Product> _repository;

        public ProductBL(IRepository<int, Product> repository)
        {
            _repository = repository;
        }

        public void AddProduct(int id, Product product)
        {
            _repository.Add(id, product);
        }

        public void DeleteProduct(int productId)
        {
            _repository.Delete(productId);
        }

        public List<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public Product GetProductById(int productId)
        {
            return _repository.GetById(productId);
        }

        public void UpdateProduct(int productId, Product product)
        {
            _repository.Update(productId, product);
        }
    }

}
