using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Comands
{
    public record DeleteProductCommand(string Id):IRequest<bool>;
    
}
