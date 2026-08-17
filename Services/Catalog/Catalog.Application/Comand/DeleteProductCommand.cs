using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Comand
{
    public record DeleteProductCommand(string Id):IRequest<bool>;
    
}
