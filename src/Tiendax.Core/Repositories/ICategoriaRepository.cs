﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Repositories;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task UpdateAsync(Categoria categoria);
    void UpdateRange(IEnumerable<Categoria> categorias);
}