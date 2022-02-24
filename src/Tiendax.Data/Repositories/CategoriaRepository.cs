﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;
using Tiendax.Core.Repositories;

namespace Tiendax.Data.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    private readonly TiendaxContext _db;

    public CategoriaRepository(TiendaxContext db) : base(db) => _db = db;

    public async Task<Categoria> UpdateAsync(Categoria categoria)
    {
        var dbCategoria = await _db.Categorias.FirstOrDefaultAsync(c => c.Id == categoria.Id);

        dbCategoria!.Descripcion = categoria.Descripcion ?? dbCategoria.Descripcion;

        return dbCategoria;
    }

    public async Task<Categoria> ToggleActivoById(int categoriaId)
    {
        var dbCategoria = await _db.Categorias.FirstOrDefaultAsync(c => c.Id == categoriaId);

        dbCategoria!.Activo = !dbCategoria.Activo;

        return dbCategoria;
    }

    public void UpdateRange(IEnumerable<Categoria> categorias)
    {
        if (!categorias.Any())
            return;

        _db.Categorias.UpdateRange(categorias);
    }
}
