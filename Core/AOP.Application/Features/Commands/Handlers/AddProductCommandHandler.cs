using AOP.Application.Abstractions.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOP.Domain.Entities;
using AOP.Application.Features.Commands.Requests;
using AOP.Application.Features.Commands.Response;

namespace AOP.Application.Features.Commands.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IWriteRepository<Product> _productWriteRepository;
        private readonly IReadRepository<Category> _categoryReadRepository;
        public AddProductCommandHandler(
            IWriteRepository<Product> productWriteRepository
            , IReadRepository<Category> categoryReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetSingleAsync(x => x.Id == request.CategoryId);
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                Category = category,
            };
            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveAsync();


            return new AddProductCommandResponse();
        }
    }
}
