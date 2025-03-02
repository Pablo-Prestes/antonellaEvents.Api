using AntonellaEvents.Domain.Helpers.Pagination;

namespace AntonellaEvents.Domain.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> PostAsync(T entity, string userId);
		Task<T> PutAsync(T entity, string userId);
		Task<T?> DeleteAsync(int id, string userId);
		Task<T?> GetByIdAsync(int id);
		Task<PagedList<T>> GetAllAsync(int pageNumber, int pageSize);
		Task<int> Count();
	}
}
