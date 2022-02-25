using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class Producto : BaseEntity
{
    public Producto()
    {
        ProductosCaracteristicas = new Collection<ProductoCaracteristica>();
        Variantes = new Collection<Variante>();
        Categorias = new Collection<Categoria>();
    }

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Nombre { get; set; } = null!;

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;

    public int MarcaId { get; set; }

    public Marca Marca { get; set; } = null!;
    public ICollection<ProductoCaracteristica> ProductosCaracteristicas { get; set; }
    public ICollection<Variante> Variantes { get; set; }
    public ICollection<Categoria> Categorias { get; set; }
}
