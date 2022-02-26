using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendax.Core.Models;

namespace System;

public static class DataPagerExtension
{
    public static async Task<PagedModel<TModel>> PaginateAsync<TModel>(
                this IQueryable<TModel> query,
                int page,
                int limit,
                CancellationToken cancellationToken)
                where TModel : class
    {

        var paged = new PagedModel<TModel>();

        page = (page < 0) ? 1 : page;

        paged.CurrentPage = page;
        paged.PageSize = limit;

        var totalItemsCountTask = await query.CountAsync(cancellationToken);

        var startRow = (page - 1) * limit;
        paged.Items = await query
                   .Skip(startRow)
                   .Take(limit)
                   .ToListAsync(cancellationToken);

        paged.TotalItems = totalItemsCountTask;
        paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

        return paged;
    }
}
