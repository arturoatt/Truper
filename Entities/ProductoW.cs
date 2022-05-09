using System;
using System.Collections.Generic;

namespace Truper.Entities
{
    public partial class ProductoW
    {
        public string Sku { get; set; }
        public string Nombre { get; set; }
        public int? Existencia { get; set; }
        public decimal? Price { get; set; }
    }
}
