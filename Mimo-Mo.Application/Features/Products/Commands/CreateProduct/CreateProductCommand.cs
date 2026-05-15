using AutoMapper;
using FluentValidation;
using MediatR;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Core.Entities;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(CreateProductDto ProductDto) : IRequest<ProductResponseDto>;