using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Enumerables;

namespace Tiendax.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool? Activo { get; set; } = Convert.ToBoolean((int)Estado.Activo);
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }
    }
}
