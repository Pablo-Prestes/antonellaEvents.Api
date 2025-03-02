using AntonellaEvents.Domain.Helpers.Pagination;
using Microsoft.EntityFrameworkCore;

namespace AntonellaEvents.Infra.Data.Helpers
{
	internal class PaginationHelper
	{
		public static async Task<PagedList<T>> CreateAsync<T>(IQueryable<T> source,
															  int pageNumber,
															  int pageSize) where T : class
		{
			var count = await source.CountAsync();
			var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

			return new PagedList<T>(items, pageNumber, pageSize, count);
		}

		public static async Task<PagedList<T>> CreateInMemoryAsync<T>(IEnumerable<T> source,
													  int pageNumber,
													  int pageSize) where T : class
		{
			var count = source.Count();
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			return await Task.FromResult(new PagedList<T>(items, pageNumber, pageSize, count));
		}
	}
}
