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
    public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
