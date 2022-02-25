using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Entities;

namespace Tiendax.Core.Services;

public interface IColorServices
{
    Task<IEnumerable<Color>> GetAllColores();
    Task<Color> AddColor(Color color);
    Task<Color> UpdateColor(Color color);
    Task<Color> GetColorById(int colorId);
    Task<Color> ToggleActivoById(int colorId);
}
