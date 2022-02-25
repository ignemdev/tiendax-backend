using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiendax.Core.Models;

public class ResponsePaginationModel<TModel>
{
    private int _count;
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public TModel Data { get; set; } = default!;
    public string ErrorMessage { get; private set; } = null!;
    public bool HasError { get; set; }
    public void SetErrorMessage(string message)
    {
        ErrorMessage = message;
        HasError = true;
    }
    public void SetPagination<T>(IEnumerable<T> list, PaginationParams paginationParams)
    {
        _count = list.Count();

        if (paginationParams.PageSize == 0 || paginationParams.PageNumber == 0)
            return;

        TotalPages = (int)Math.Ceiling(_count / (double)paginationParams.PageSize);

        if (paginationParams.PageNumber > TotalPages)
            return;

        TotalCount = _count;
        PageSize = paginationParams.PageSize;
        CurrentPage = paginationParams.PageNumber;

    }
}
