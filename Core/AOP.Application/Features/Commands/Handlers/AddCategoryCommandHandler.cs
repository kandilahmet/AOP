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
    public class AddCategoryCommandHandler(IWriteRepository<Category> categoryWriteRepository) : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
    {
        public async Task<AddCategoryCommandResponse> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category category = new Domain.Entities.Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            await categoryWriteRepository.AddAsync(category);
            await categoryWriteRepository.SaveAsync();

            return new AddCategoryCommandResponse();
        }
    }
}
