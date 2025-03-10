﻿using ShoppingCart.Catalog.Dtos.ProductDetailDtos;

namespace ShoppingCart.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();

        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);

        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);

        Task DeleteProductDetailAsync(string id);

        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}