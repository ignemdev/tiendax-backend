using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendax.Core.Models;

public class ResponsePaginationModel<TModel>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public TModel Data { get; set; } = default!;
    public string ErrorMessage { get; private set; } = null!;
    public bool HasError { get; set; }
    public void SetErrorMessage(string message)
    {
        ErrorMessage = message;
        HasError = true;
    }
}
