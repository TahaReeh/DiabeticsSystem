using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Product Name: {Name}; Number: {Number}; Details: {Details}";
        }
    }
}
