﻿using ShoppingCart.Catalog.Dtos.ProductImageDtos;

namespace ShoppingCart.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();

        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);

        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);

        Task DeleteProductImageAsync(string id);

        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}