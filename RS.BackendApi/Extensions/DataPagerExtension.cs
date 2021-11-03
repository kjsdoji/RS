using Microsoft.EntityFrameworkCore;
using RS.Utilities.Constants;
using RS.ViewModels.Dto;
using RS.ViewModels.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace RS.BackendApi.Extensions
{
    public static class DataPagerExtension
    {
        public static async Task<PagedModelDto<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            BaseQueryCriteriaDto criteriaDto,
            CancellationToken cancellationToken)
            where TModel : class
        {

            var paged = new PagedModelDto<TModel>();

            paged.CurrentPage = (criteriaDto.Page < 0) ? 1 : criteriaDto.Page;
            paged.PageSize = criteriaDto.Limit;

            if (!string.IsNullOrEmpty(criteriaDto.SortOrder.ToString()) &&
                !string.IsNullOrEmpty(criteriaDto.SortColumn))
            {
                var sortOrder = criteriaDto.SortOrder == SortOrderEnum.Accsending ?
                                    PagingSortingConstants.ASC :
                                    PagingSortingConstants.DESC;
                var orderString = $"{criteriaDto.SortColumn} {sortOrder}";
                query = query.OrderBy(orderString);
            }

            var startRow = (paged.CurrentPage - 1) * paged.PageSize;

            paged.Items = await query
                        .Skip(startRow)
                        .Take(paged.PageSize)
                        .ToListAsync(cancellationToken);

            paged.TotalItems = await query.CountAsync(cancellationToken);
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }
    }
}
