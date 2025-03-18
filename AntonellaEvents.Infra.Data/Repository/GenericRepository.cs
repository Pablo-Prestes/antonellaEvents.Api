using AntonellaEvents.Domain.Entities.EntitiesWrite;
using AntonellaEvents.Domain.Helpers.Pagination;
using AntonellaEvents.Domain.Interfaces;
using AntonellaEvents.Infra.Data.Context;
using AntonellaEvents.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AntonellaEvents.Infra.Data.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly AntonellaEventsWriteContext _writeContext;
		private readonly AntonellaEventsReadContext _readContext;
		private readonly DbSet<T> _writeDbSet;
		private readonly DbSet<T> _readDbSet;

		public GenericRepository(
			AntonellaEventsWriteContext writeContext,
			AntonellaEventsReadContext readContext)
		{
			_writeContext = writeContext;
			_readContext = readContext;

			_writeDbSet = _writeContext.Set<T>();
			_readDbSet = _readContext.Set<T>();
		}

		public async Task<T> PostAsync(T entity, string userId)
		{
			try
			{
				entity.Post(userId);
				await _writeDbSet.AddAsync(entity);
				await _writeContext.SaveChangesAsync();
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
				_writeDbSet.Update(entity);
				await _writeContext.SaveChangesAsync();
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
				if (entity == null) return null;

				entity.Delete(userId);
				_writeDbSet.Update(entity);
				await _writeContext.SaveChangesAsync();
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
				return await _readDbSet
					.Where(a => a.Id == id && a.Active)
					.FirstOrDefaultAsync();
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
				var query = _readDbSet.AsNoTracking().AsQueryable();
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
				return await _readDbSet.CountAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao contar objetos.", ex);
			}
		}
	}
}
