using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API.Utilities
{
    public static class HttpContextExtensions
    {
        public async static Task insertPaginationHeaderValues <T> (this HttpContext httpContext, IQueryable<T> queryable)
        {
            if (httpContext == null) { throw new ArgumentException(nameof(httpContext)); }

            double quantity = await queryable.CountAsync();

            httpContext.Response.Headers.Add("TotalItems", quantity.ToString());
        }
    }
}
