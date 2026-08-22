using Discount.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.Commands
{
   public record DeleteDiscoundCommand(string ProductName) : IRequest<bool>;
    
    
}
