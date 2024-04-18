using System.Linq.Expressions;
using EntityFramework.Exceptions.Common;
using Microsoft.EntityFrameworkCore;
using RegistrationDemo.Common;
using RegistrationDemo.Database.Models;

namespace RegistrationDemo.Database;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
{
	protected readonly UsersContext Context;

	public BaseRepository(UsersContext context)
	{
		Context = context;
	}

	public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		return CatchEfException(async () =>
		{
			if (entity == null)
				throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
			
			await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
			await Context.SaveChangesAsync(cancellationToken);

			return entity;
		});
	}

	public Task<TEntity> DeleteAsync(long id, CancellationToken cancellationToken = default)
	{
		return CatchEfException(async () => {
			var entity = await Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			return await DeleteAsync(entity, cancellationToken);
		});
	}

	public Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		return CatchEfException(async () =>
		{
			_ = entity ?? throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
			Context.Set<TEntity>().Remove(entity);
			await Context.SaveChangesAsync(cancellationToken);

			return entity;
		});
	}
	
	public Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
	{
		return CatchEfException(() => Context.Set<TEntity>().FirstOrDefaultAsync(filter, cancellationToken));
	}

	public Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default)
	{
		return FindFirstAsync(x => x.Id == id, cancellationToken);
	}

	public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		return CatchEfException(async () =>
		{
			if (entity == null)
				throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
			
			Context.Entry(entity).State = EntityState.Modified;
			await Context.SaveChangesAsync(cancellationToken);
			return entity;
		});
	}

	public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await Context.Set<TEntity>().ToArrayAsync(cancellationToken);
	}

	protected async Task<T> CatchEfException<T>(Func<Task<T>> func)
	{
		try
		{
			return await func.Invoke();
		}
		catch (UniqueConstraintException e)
		{
			throw new BlException(ErrorCode.DuplicateKey, "Trying to add existing entity", e);
		}
		catch (FormatException e)
		{
			throw new BlException(ErrorCode.NotFound, "Not found", e);
		}
		catch (ReferenceConstraintException e)
		{
			throw new BlException(ErrorCode.ReferenceConstraintError, "We cannot update or delete this data because it is connected to other information in our system.", e);
		}
		catch (DbUpdateException e)
		{
			throw new BlException(ErrorCode.DataAccess, "Data access error occured.", e);
		}
	}
}

public interface IBaseRepository<TEntity> where TEntity : class, IEntity
{
	public Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default);
	public Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	public Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
	public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
	public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
	
	public Task<TEntity> DeleteAsync(long id, CancellationToken cancellationToken = default);
	public Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}