using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendax.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Creado { get; set; }
        public DateTime? Modificado { get; set; }
    }
}
