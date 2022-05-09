using System;
using System.Collections.Generic;

namespace Truper.Entities
{
    public partial class PedidosW
    {
        public PedidosW()
        {
            PedidosDetalleWs = new HashSet<PedidosDetalleW>();
        }

        public int Id { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DateSale { get; set; }
        public string Username { get; set; }

        public virtual UsuariosW UsernameNavigation { get; set; }
        public virtual ICollection<PedidosDetalleW> PedidosDetalleWs { get; set; }
    }
}
