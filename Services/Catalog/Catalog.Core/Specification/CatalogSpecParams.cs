using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Catalog.Core.Specification
{
    public class CatalogSpecParams
    {
        public int MaxPageSize { get; set; } = 70;

        public int _PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }


        public string? BrandId { get; set; }
        public string? TypeId { get; set; }
        public string? Sort { get; set; }
        public string? Search { get; set; }


    }
}
