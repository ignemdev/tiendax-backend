using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<Categoria> UpdateAsync(Categoria categoria);

    Task<Categoria> ToggleActivoById(int categoriaId);

    void UpdateRange(IEnumerable<Categoria> categorias);
}
