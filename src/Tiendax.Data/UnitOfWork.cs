using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core;
using Tiendax.Core.Repositories;
using Tiendax.Data.Repositories;

namespace Tiendax.Data;

public class UnitOfWork : IUnitOfWork
{

    private readonly TiendaxContext _db;

    public UnitOfWork(TiendaxContext db)
    {
        _db = db;
        Caracteristica = new CaracteristicaRepository(_db);
        Categoria = new CategoriaRepository(_db);
        Color = new ColorRepository(_db);
        Imagen = new ImagenRepository(_db);
        Marca = new MarcaRepository(_db);
        Producto = new ProductoRepository(_db);
        Variante = new VarianteRepository(_db);
        ProductoCaracteristica = new ProductoCaracteristicaRepository(_db);

    }

    public ICaracteristicaRepository Caracteristica { get; private set; }

    public ICategoriaRepository Categoria { get; private set; }

    public IColorRepository Color { get; private set; }

    public IImagenRepository Imagen { get; private set; }

    public IMarcaRepository Marca { get; private set; }

    public IProductoRepository Producto { get; private set; }

    public IVarianteRepository Variante { get; private set; }

    public IProductoCaracteristicaRepository ProductoCaracteristica { get; private set; }

    public void Dispose()
    {
        _db.Dispose();
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
