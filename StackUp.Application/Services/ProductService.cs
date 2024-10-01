﻿using AutoMapper;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task AddProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
            // Save changes via Unit of Work or directly if using repositories with Save
        }

        // Update existing product
        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.Id);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            // Update properties
            product.UpdatePrice(productDto.Price);
            // Adjust quantity or other properties as needed

            _productRepository.Update(product);
            // Save changes via Unit of Work or directly if using repositories with Save
        }

        // Remove product
        public async Task RemoveProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            _productRepository.Remove(product);
        }
    }
}
