using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Services;

public interface ICategoriaServices
{
    Task<IEnumerable<Categoria>> GetAllActiveCategorias();
    Task<Categoria> AddCategoria(Categoria categoria);
    Task<Categoria> UpdateCategoria(Categoria categoria);
    Task<Categoria> GetCategoriaById(int categoriaId);
    Task<Categoria> ToggleActivoById(int categoriaId);
}
