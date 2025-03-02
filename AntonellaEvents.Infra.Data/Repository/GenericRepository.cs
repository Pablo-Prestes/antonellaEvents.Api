using AntonellaEvents.Domain.Entities;
using AntonellaEvents.Domain.Helpers.Pagination;
using AntonellaEvents.Domain.Interfaces;
using AntonellaEvents.Infra.Data.Context;
using AntonellaEvents.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AntonellaEvents.Infra.Data.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		protected readonly AntonellaEventsContext _context;
		protected readonly DbSet<T> _dbSet;

		public GenericRepository(AntonellaEventsContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task<T> PostAsync(T entity, string userId)
		{
			try
			{
				entity.Post(userId);
				await _dbSet.AddAsync(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao salvar objeto.", ex);
			}
		}

		public async Task<T> PutAsync(T entity, string userId)
		{
			try
			{
				entity.Update(userId);
				_dbSet.Update(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao atualizar objeto.", ex);
			}
		}

		public async Task<T?> DeleteAsync(int id, string userId)
		{
			try
			{
				var entity = await GetByIdAsync(id);
				if (entity == null)
					return null;

				entity.Delete(userId);
				_dbSet.Update(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao excluir objeto.", ex);
			}
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			try
			{
				return await _dbSet.Where(a => a.Id == id && a.Active ).FirstOrDefaultAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao selecionar objeto.", ex);
			}
		}

		public async Task<PagedList<T>> GetAllAsync(int pageNumber, int pageSize)
		{
			try
			{
				var query = _dbSet.AsNoTracking().AsQueryable();
				return await PaginationHelper.CreateAsync<T>(query, pageNumber, pageSize);
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao selecionar todos os objetos.", ex);
			}
		}

		public async Task<int> Count()
		{
			try
			{
				return await _dbSet.CountAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao contar objetos.", ex);
			}
		}
	}
}
