﻿using FluentValidation;
using OnlineMarket.Application.Common.Exceptions;
using OnlineMarket.Application.Common.Validators;
using OnlineMarket.Application.DTOs.CategoryDTOs;
using OnlineMarket.Application.Interafces;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;
using System.Net;

namespace OnlineMarket.Application.Services;

public class CategoryService(IUnitOfWork unitOfWork,
                             IValidator<Category> validator) 
    : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Category> _validator = validator;

    public async Task CreateAsync(AddCategoryDto dto)
    {
        var category = await _unitOfWork.Category.IsCategoryExistsAsync(dto.CategoryName);
        if (category)
            throw new StatusCodeException(HttpStatusCode.AlreadyReported, "This category already exists!");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Category.CreateAsync((Category)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        if (category is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Category not found");

        await _unitOfWork.Category.DeleteAsync(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _unitOfWork.Category.GetAllAsync(x => x.CategoryName != null);
        return categories.Select(x => (CategoryDto)x).ToList();
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        if (category is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Category with this is not found");

        return (CategoryDto)category;
    }

    public async Task<IEnumerable<CategoryDto>> GetByNameAsync(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new StatusCodeException(HttpStatusCode.BadGateway, "Category can not be empty");
        var categories = await _unitOfWork.Category.GetByNameAsync(name);

        return categories.Select(x => (CategoryDto)x!).ToList();
    }

    public async Task UpdateAsync(CategoryDto dto)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(dto.Id);
        if (category is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Category not found");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        await _unitOfWork.Category.UpdateAsync(category);
    }
}
