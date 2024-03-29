using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOP.Application.Features.Commands.Response;
using AOP.Domain.Entities;
using MediatR;

namespace AOP.Application.Features.Commands.Requests
{
    public class AddCategoryCommandRequest : IRequest<AddCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
