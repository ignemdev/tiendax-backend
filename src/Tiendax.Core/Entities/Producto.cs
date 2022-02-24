using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tiendax.Core.Entities;
public class Producto : BaseEntity
{
    public Producto()
    {
        ProductosCaracteristicas = new List<ProductoCaracteristica>();
        Variantes = new List<Variante>();
        Categorias = new List<Categoria>();
    }

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Nombre { get; set; } = null!;

    [MinLength(1)]
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;

    public int MarcaId { get; set; }

    public Marca Marca { get; set; } = null!;
    public IEnumerable<ProductoCaracteristica> ProductosCaracteristicas { get; set; }
    public IEnumerable<Variante> Variantes { get; set; }
    public IEnumerable<Categoria> Categorias { get; set; }
}
