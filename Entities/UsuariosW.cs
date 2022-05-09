using System;
using System.Collections.Generic;

namespace Truper.Entities
{
    public partial class UsuariosW
    {
        public UsuariosW()
        {
            PedidosWs = new HashSet<PedidosW>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public virtual ICollection<PedidosW> PedidosWs { get; set; }
    }
}
