using System;
using System.Collections.Generic;

namespace Truper.Entities
{
    public partial class PedidosDetalleW
    {
        public int Id { get; set; }
        public int? IdPedido { get; set; }
        public string Sku { get; set; }
        public decimal? Amout { get; set; }
        public decimal? Price { get; set; }

        public virtual PedidosW IdPedidoNavigation { get; set; }
    }
}
